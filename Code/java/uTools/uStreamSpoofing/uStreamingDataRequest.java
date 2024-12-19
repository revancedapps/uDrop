//Thanks to ReVanced/RvX Team for the original code

package uTools.uStreamSpoofing;

import static uTools.uStreamSpoofing.uPlayerRoutes.GET_STREAMING_DATA;

import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.util.Log;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.nio.ByteBuffer;
import java.nio.charset.StandardCharsets;
import java.util.*;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.stream.Stream;

public class uStreamingDataRequest {
    private static final String[] REQUEST_HEADER_KEYS = {
        "Authorization",
        "X-GOOG-API-FORMAT-VERSION",
        "X-Goog-Visitor-Id"
    };
    private static final int HTTP_TIMEOUT_MILLISECONDS = 10 * 1000;
    private static final int MAX_MILLISECONDS_TO_WAIT_FOR_FETCH = 20 * 1000;
    private static final int READ_BUFFER_SIZE = 8192;
    private static final List<uClientType> CLIENT_TYPES_ORDER_TO_USE = new ArrayList<>();

    private static final Map<String, uStreamingDataRequest> cache = Collections.synchronizedMap(
        new LinkedHashMap<>(100) {
            private static final int CACHE_LIMIT = 50;
            @Override
            protected boolean removeEldestEntry(Entry eldest) {
                return size() > CACHE_LIMIT;
            }
        }
    );

    public static void fetchRequest(String videoId, Map<String, String> fetchHeaders) {
        cache.put(videoId, new uStreamingDataRequest(videoId, fetchHeaders));
    }

    @Nullable
    public static uStreamingDataRequest getRequestForVideoId(String videoId) {
        return cache.get(videoId);
    }

    @Nullable
    private static HttpURLConnection send(uClientType clientType, String videoId, Map<String, String> playerHeaders) {
        Objects.requireNonNull(clientType);
        Objects.requireNonNull(videoId);
        Objects.requireNonNull(playerHeaders);

        try {
            HttpURLConnection connection = uPlayerRoutes.getPlayerResponseConnectionFromRoute(GET_STREAMING_DATA, clientType);
            connection.setConnectTimeout(HTTP_TIMEOUT_MILLISECONDS);
            connection.setReadTimeout(HTTP_TIMEOUT_MILLISECONDS);

            for (String key : REQUEST_HEADER_KEYS) {
                String value = playerHeaders.get(key);
                if (value != null) {
                    connection.setRequestProperty(key, value);
                }
            }

            String innerTubeBody = String.format(uPlayerRoutes.createInnertubeBody(clientType), videoId);
            byte[] requestBody = innerTubeBody.getBytes(StandardCharsets.UTF_8);
            connection.setFixedLengthStreamingMode(requestBody.length);
            connection.getOutputStream().write(requestBody);

            final int responseCode = connection.getResponseCode();
            if (responseCode == 200) return connection;
        } catch (Exception ignore) {}

        return null;
    }

    static {
        uClientType[] clientTypes = uClientType.values();
        uClientType preferredClientType = uClientType.ANDROID_UNPLUGGED;

        CLIENT_TYPES_ORDER_TO_USE.add(preferredClientType);

        for (uClientType clientType : clientTypes) {
            if (clientType != preferredClientType) {
                CLIENT_TYPES_ORDER_TO_USE.add(clientType);
            }
        }
    }

    private static ByteBuffer fetch(String videoId, Map<String, String> playerHeaders) {
        for (uClientType clientType : CLIENT_TYPES_ORDER_TO_USE) {
            Log.d("uStreamingDataRequest", clientType.name());

            HttpURLConnection connection = send(clientType, videoId, playerHeaders);
            if (connection != null) {
                try {
                    int contentLength = connection.getContentLength();
                    if (contentLength != 0) {
                        try (
                            InputStream inputStream = new BufferedInputStream(connection.getInputStream());
                            ByteArrayOutputStream bAOS = new ByteArrayOutputStream(Math.max(contentLength, READ_BUFFER_SIZE))
                        ) {
                            byte[] buffer = new byte[READ_BUFFER_SIZE];
                            int bytesRead;

                            while ((bytesRead = inputStream.read(buffer)) >= 0) {
                                bAOS.write(buffer, 0, bytesRead);
                            }

                            return ByteBuffer.wrap(bAOS.toByteArray());
                        }
                    }
                } catch (Exception ignore) {}
            }
        }

        return null;
    }

    private static boolean isLiveStreamWithPreferredClient(byte[] buffer, int bytesRead, uClientType clientType) {
        return Stream.of(
                    "yt_live_broadcast",
                    "yt_premiere_broadcast"
                )
                .anyMatch(new String(buffer, 0, Math.min(bytesRead, 512))::contains)
                &&
                !clientType.name().equals("ANDROID_VR");
    }

    private final String videoId;
    private final Future<ByteBuffer> future;

    private uStreamingDataRequest(String videoId, Map<String, String> playerHeaders) {
        Objects.requireNonNull(playerHeaders);
        this.videoId = videoId;
        this.future = uSpoofingUtils.submitOnBackgroundThread(() -> fetch(videoId, playerHeaders));
    }

    @Nullable
    public ByteBuffer getStream() {
        try {
            return future.get(MAX_MILLISECONDS_TO_WAIT_FOR_FETCH, TimeUnit.MILLISECONDS);
        } catch (Exception ignore) {}

        return null;
    }

    @NonNull
    @Override
    public String toString() {
        return "StreamingDataRequest{" + "videoId='" + videoId + '\'' + '}';
    }
}
