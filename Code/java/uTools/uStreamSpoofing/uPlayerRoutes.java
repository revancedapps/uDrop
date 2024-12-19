//Thanks to ReVanced/RvX Team for the original code

package uTools.uStreamSpoofing;

import org.json.JSONObject;

import java.io.IOException;
import java.net.HttpURLConnection;

final class uPlayerRoutes {
    private static final String YT_API_URL = "https://youtubei.googleapis.com/youtubei/v1/";
    private static final int CONNECTION_TIMEOUT_MILLISECONDS = 10 * 1000;

    static final uRoute.CompiledRoute GET_STREAMING_DATA = new uRoute(
        uRoute.Method.POST,
        String.format(
            "%s%s%s",

            "player",
            "?fields=streamingData",
            "&alt=proto"
        )
    ).compile();

    static String createInnertubeBody(uClientType clientType) {
    	JSONObject innerTubeBody = new JSONObject();

        try {
            JSONObject client = new JSONObject();
            client.put("clientName", clientType.name());
            client.put("clientVersion", clientType.appVersion);
            client.put("deviceModel", clientType.model);
            client.put("osVersion", clientType.osVersion);
            if (clientType.androidSdkVersion != null) {
                client.put("androidSdkVersion", clientType.androidSdkVersion);
            }

            innerTubeBody.put("context", new JSONObject() {{
                put("client", client);
            }});
            innerTubeBody.put("contentCheckOk", true);
            innerTubeBody.put("racyCheckOk", true);
            innerTubeBody.put("videoId", "%s");
        } catch (Exception ignore) {}

        return innerTubeBody.toString();
    }

    /** @noinspection SameParameterValue*/
    static HttpURLConnection getPlayerResponseConnectionFromRoute(uRoute.CompiledRoute route, uClientType clientType) throws IOException {
        var connection = uRequester.getConnectionFromCompiledRoute(YT_API_URL, route);
        connection.setRequestProperty("Content-Type", "application/json");
        connection.setRequestProperty("User-Agent", clientType.userAgent);
        connection.setUseCaches(false);
        connection.setDoOutput(true);
        connection.setConnectTimeout(CONNECTION_TIMEOUT_MILLISECONDS);
        connection.setReadTimeout(CONNECTION_TIMEOUT_MILLISECONDS);

        return connection;
    }
}