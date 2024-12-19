//Thanks to ReVanced/RvX Team for the original code

package uTools.uStreamSpoofing;

import android.support.annotation.Nullable;

public enum uClientType {
    ANDROID_VR(
        28,
        "Quest 3",
        "14",
        "com.google.android.apps.youtube.vr.oculus/1.60.19 (Linux; U; Android 14; GB) gzip",
        "34",
        "1.61.48"
    ),
    ANDROID_UNPLUGGED(
        29,
        "Google TV Streamer",
        "14",
        "com.google.android.apps.youtube.unplugged/8.45.3 (Linux; U; Android 14; GB) gzip",
        "34",
        "8.49.0"
    );

    public final int id;
    public final String model;
    public final String osVersion;
    public final String userAgent;
    @Nullable
    public final String androidSdkVersion;
    public final String appVersion;

    uClientType(int id, String model, String osVersion, String userAgent, @Nullable String androidSdkVersion, String appVersion) {
        this.id = id;
        this.model = model;
        this.osVersion = osVersion;
        this.userAgent = userAgent;
        this.androidSdkVersion = androidSdkVersion;
        this.appVersion = appVersion;
    }
}