package uTools;

import static uTools.uBlocker.currentNavBarIndex;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.support.annotation.NonNull;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Toast;

import java.lang.ref.WeakReference;
import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.Objects;

@SuppressLint("StaticFieldLeak")
@SuppressWarnings({"ConstantConditions", "SameParameterValue"})
public class uUtils {
    public static boolean ByteBufferContainsString(ByteBuffer byteBuffer, String str) {
        byte[] bArrSource = byteBuffer.array();
        byte[] bArrTarget = str.getBytes();

        for (int i = 0; i <= bArrSource.length - bArrTarget.length; i++) {
            if (Arrays.equals(Arrays.copyOfRange(bArrSource, i, i + bArrTarget.length), bArrTarget)) {
                return true;
            }
        }
        return false;
    }

    public static boolean CheckDarkTheme() {
        return isDarkTheme;
    }

    public static String currentPlayerID = "";
    public static boolean CheckIsShortsPlayer() {
        return currentPlayerID.startsWith("8AEB");
    }

    public static Context appContext;
    public static Context GetAppContext() {
        if (appContext == null) {
            Log.e("uContext", "App Context is null");

            return null;
        } else {
            return appContext;
        }
    }

    public static Activity GetMainActivity() {
        if (mainActivity == null) {
            Log.e("uActivity", "Main Activity is null");

            return null;
        } else {
            return mainActivity;
        }
    }

    public static void SetNavBarIndexByMainActivity(Activity activity) {
        String intentAction = activity.getIntent().getAction();

        try {
            if (intentAction.equals("com.google.android.youtube.action.open.shorts")) {
                currentNavBarIndex = 1;
            } else if (intentAction.equals("com.google.android.youtube.action.open.subscriptions")) {
                currentNavBarIndex = 2;
            }
        } catch (Exception ignore) {}
    }

    public static Context GetMainActivityContext() {
        Context mainActivityContext = mainActivityRef.get();

        if (mainActivityContext == null) {
            Log.e("uContext", "Main Activity Context is null");

            return null;
        } else {
            return mainActivityContext;
        }
    }

    public static void HideImageView(ImageView imageView) {
        imageView.setVisibility(View.GONE);
    }

    public static void HideInstanceViewByLayoutParams(View view) {
        if (view instanceof ViewGroup) {
            view.setLayoutParams(new ViewGroup.LayoutParams(1, 1));
        }
    }

    public static void HideView(View view) {
        view.setVisibility(View.GONE);
    }

    public static void HideViewByLinearLayoutParams(View view) {
        view.setLayoutParams(new LinearLayout.LayoutParams(0, 0));
    }

    public static void HideViewGroupByLayoutParams(ViewGroup viewGroup) {
        viewGroup.setLayoutParams(new ViewGroup.LayoutParams(0, 0));
    }

    public static void HideViewGroupByMarginLayout(ViewGroup viewGroup) {
        viewGroup.setVisibility(View.GONE);
    }

    public static boolean IsCurrentlyOnMainThread() {
        return Looper.getMainLooper().isCurrentThread();
    }

    public static void RunOnMainThread(@NonNull Runnable runnable) {
        RunOnMainThreadDelayed(runnable, 0);
    }

    public static void RunOnMainThreadDelayed(@NonNull Runnable runnable, long delayMillis) {
        Runnable loggingRunnable = () -> {
            try {
                runnable.run();
            } catch (Exception ignore) {}
        };
        new Handler(Looper.getMainLooper()).postDelayed(loggingRunnable, delayMillis);
    }

    public static void RunOnMainThreadNowOrLater(@NonNull Runnable runnable) {
        if (IsCurrentlyOnMainThread()) {
            runnable.run();
        } else {
            RunOnMainThread(runnable);
        }
    }

    private static Activity mainActivity = new Activity();
    private static WeakReference<Activity> mainActivityRef = new WeakReference<>(null);
    public static void SetMainActivity(Activity activity) {
        mainActivity = activity;

        mainActivityRef = new WeakReference<>(activity);

        SetNavBarIndexByMainActivity(activity);
    }

    private static boolean isDarkTheme = false;
    public static void SetSystemTheme(Enum<?> e) {
        isDarkTheme = Integer.valueOf(e.ordinal()).equals(1);
    }
    public static void SetAppTheme(boolean value) {
        isDarkTheme = value;
    }

    public static void ShowToastLong(@NonNull String messageToToast) {
        ShowToast(messageToToast, Toast.LENGTH_LONG);
    }

    private static void ShowToast(@NonNull String messageToToast, int toastDuration) {
        Objects.requireNonNull(messageToToast);
        RunOnMainThreadNowOrLater(() -> {
            Toast.makeText(GetAppContext(), messageToToast, toastDuration).show();
        });
    }
}
