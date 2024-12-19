//Thanks to ReVanced/RvX Team for the original code

package uTools.uStreamSpoofing;

import android.net.Uri;
import android.support.annotation.Nullable;

import java.nio.ByteBuffer;
import java.util.Map;
import java.util.Objects;

public class uSpoofing {
    private static final String UNREACHABLE_HOST_URI_STRING = "https://127.0.0.0";
    private static final Uri UNREACHABLE_HOST_URI = Uri.parse(UNREACHABLE_HOST_URI_STRING);

    public static Uri blockGetWatchRequest(Uri playerRequestUri) {
        try {
            String path = playerRequestUri.getPath();

            if (path != null && path.contains("get_watch")) {
                return UNREACHABLE_HOST_URI;
            }
        } catch (Exception ignored) {}

        return playerRequestUri;
    }

    public static String blockInitPlaybackRequest(String originalUrlString) {
        try {
            Uri originalUri = Uri.parse(originalUrlString);
            String path = originalUri.getPath();

            if (path != null && path.contains("initplayback")) {
                return originalUri.buildUpon().clearQuery().build().toString();
            }
        } catch (Exception ignore) {}

        return originalUrlString;
    }

    public static void fetchStreams(String url, Map<String, String> requestHeaders) {
        try {
            Uri uri = Uri.parse(url);
            String path = uri.getPath();
            if (path != null && path.contains("player") && !path.contains("heartbeat")) {
                String videoId = Objects.requireNonNull(uri.getQueryParameter("id"));
                uStreamingDataRequest.fetchRequest(videoId, requestHeaders);
            }
        } catch (Exception ignore) {}
    }

    @Nullable
    public static ByteBuffer getStreamingData(String videoId) {
        try {
            uStreamingDataRequest request = uStreamingDataRequest.getRequestForVideoId(videoId);
            if (request != null) {
                var stream = request.getStream();
                if (stream != null) {
                    return stream;
                }
            }
        } catch (Exception ignore) {}

        return null;
    }

    @Nullable
    public static byte[] removeVideoPlaybackPostBody(Uri uri, int method, byte[] postData) {
        try {
            if (method == 2) {
                String path = uri.getPath();
                if (path != null && path.contains("videoplayback")) {
                    return null;
                }
            }
        } catch (Exception ignore) {}

        return postData;
    }
}