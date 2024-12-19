package uTools;

import static uTools.uUtils.ByteBufferContainsString;
import static uTools.uUtils.CheckDarkTheme;
import static uTools.uUtils.GetMainActivityContext;
import static uTools.uUtils.HideView;
import static uTools.uUtils.HideViewByLinearLayoutParams;
import static uTools.uUtils.HideViewGroupByLayoutParams;
import static uTools.uUtils.HideViewGroupByMarginLayout;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewParent;

import com.google.android.apps.youtube.app.watchwhile.MainActivity;

import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;
import java.util.stream.Stream;

@SuppressWarnings({"ConstantConditions", "ArraysAsListWithZeroOrOneArgument"})
public class uBlocker {
    public static boolean captionsButton = false;
    public static boolean initVideoPanel = false;

    private static final Set<Integer> DARK_CONSTANTS = new HashSet<>(Arrays.asList(
        -14145496, // explore drawer background
        -14606047, // comments chip background
        -15198184, // music related results panel background
        -15790321, // comments chip background (new layout)
        -98492127 // video chapters list background
    ));
    private static final int WHITE_COLOR = 16777215;
    private static final Set<Integer> WHITE_CONSTANTS = new HashSet<>(Arrays.asList(
        -1, // comments chip background
        -394759, // music related results panel background
        -83886081 // video chapters list background
    ));
    public static synchronized int ChangeLithoUIColor(int originalValue) {
        return (CheckDarkTheme()
                ?
                    DARK_CONSTANTS
                :
                    WHITE_CONSTANTS)
                .stream()
                .anyMatch(val -> val.equals(originalValue))
                ?
                    CheckDarkTheme()
                    ?
                        -WHITE_COLOR
                    :
                        WHITE_COLOR
                :
                    originalValue;
    }

    public static void CheckMicroGPackage(Activity activity) {
        try {
            PackageManager manager = activity.getPackageManager();
            manager.getPackageInfo(
                "app.revanced.android.gms",

                PackageManager.GET_ACTIVITIES
            );
        } catch (PackageManager.NameNotFoundException exception) {
            uUtils.ShowToastLong("Error: No MicroG Installed");
        }
    }

    public static boolean isTopView = false;
    private static long lastTimeBackPressed = 0;
    public static void CloseActivityOnBackPressed(MainActivity activity) {
        if (isTopView) {
            long time = System.currentTimeMillis();

            if ((time - lastTimeBackPressed) >= 1000) {
                lastTimeBackPressed = time;
            } else {
                isTopView = false;

                lastTimeBackPressed = 0;

                activity.finish();
            }
        }
    }

    public static void DisableAutoPlayCountdown(View view) {
        try {
            view.callOnClick();
        } catch (Exception ignored) {}
    }

    public static boolean HideHighBitrateResolution(String originalValue) {
        return originalValue.contains("Premium");
    }

    private static final Set<String> blockedIdentifiers = new HashSet<>(Arrays.asList(
        //--------------------------------------ADS--------------------------------------//
            "carousel_footered_layout",
            "carousel_headered_layout",
            "full_width_portrait_image_layout",
            "full_width_square_image_layout",
            "landscape_image_wide_button_layout",
            "square_image_layout",
            "text_image_button_group_layout",
            "text_image_button_layout",
            "video_display_button_group_layout",
            "video_display_full_buttoned_layout",
            "video_display_full_layout",
            "video_display_carousel_button_group_layout",
        //------------------------------------GENERICS-----------------------------------//
            "brand_video_singleton",
            "browsy_bar",
            "cell_expandable_metadata",
            "channel_guidelines_entry_banner",
            "chips_shelf",
            "community_guidelines",
            "compact_tvfilm_item",
            "composer_short_creation_button",
            "composer_timestamp_button",
            "emergency_onebox",
            "expandable_list",
            "featured_channel_watermark_overlay",
            "feed_nudge",
            "fullscreen_related_videos_entry_point",
            "grid_channel_shelf",
            "hero_carousel",
            "horizontal_gaming_shelf",
            "horizontal_tile_shelf",
            "image_shelf",
            "images_post_root_slim",
            "info_card_teaser_overlay",
            "infocards_section",
            "live_chat_sponsorships_new_member_announcement",
            "live_chat_text_message_banner",
            "macro_markers_carousel",
            "medical_panel",
            "member_recognition_shelf",
            "music_recap_banner",
            "offer_module_root",
            "paid_content_overlay",
            "playlist_section",
            "post_base_wrapper",
            "post_base_wrapper_slim",
            "post_shelf",
            "product_carousel",
            "products_in_video_with_preview",
            "publisher_transparency_panel",
            "reel_multi_format_link",
            "reel_pivot_button",
            "reel_player_disclosure",
            "reel_sound_metadata",
            "search_friction",
            "shelf_header",
            "shorts_info_panel_overview",
            "shorts_paused_state",
            "shorts_shelf",
            "single_item_information_panel",
            "statement_banner",
            "super_chat_item",
            "super_thanks_button",
            "text_post_root_slim",
            "timed_reaction",
            "topic_with_thumbnail_view_model",
            "transcript_section",
            "video_attributes_section",
            "|suggested_action."
    ));
    private static final Set<String> commentSubIdentifiers = new HashSet<>(Arrays.asList(
        "sponsorships_comments_footer",
        "sponsorships_comments_header",
        "sponsorships_comments_upsell",
        "|carousel_item."
    ));
    private static final Set<String> videoLockupSubIdentifiers = new HashSet<>(Arrays.asList(
        "endorsement_header_footer",
        "expandable_metadata",
        "set_reminder_button",
        "slimline_survey_video_with_context",
        "snappy_horizontal_shelf",
        "video_metadata_carousel"
    ));

    public static int currentNavBarIndex = 0;
    private static final int libraryNavButtonIndex = 4;
    public static int liveChatSubscribersShelf = 0;
    public static int liveChatCommunityRulesBox = 0;
    private static boolean moreDrawerAppsAndInfo = false;
    private static boolean quickQualityBottomSheet = false;
    public static ByteBuffer protoBufferComponents = ByteBuffer.allocate(0);
    public static synchronized boolean HideLithoTemplate(StringBuilder templateTreeComponents) {
        String strTemplateTreeComponents = templateTreeComponents.toString();

        //-----------------------------Comment Reply Emoji Panel-----------------------------//
            if (Stream.of(
                    "comment_composer",
                    "|CellType|ContainerType|ContainerType|ContainerType|ContainerType|ContainerType|"
                )
                .allMatch(strTemplateTreeComponents::contains)) {
                    return true;
            }
        //-----------------------------------------------------------------------------------//
        //--------------------------------Comments Components--------------------------------//
            if (Stream.of(
                    "comment_thread",
                    "metadata_carousel",
                    "|comment."
                )
                .anyMatch(strTemplateTreeComponents::contains)) {
                    return commentSubIdentifiers
                            .stream()
                            .anyMatch(strTemplateTreeComponents::contains);
        }
        //-----------------------------------------------------------------------------------//
        //----------------------------------Horizontal Shelf---------------------------------//
            if (strTemplateTreeComponents.contains("account_header")) {
                currentNavBarIndex = libraryNavButtonIndex;

                return false;
            } else if (Stream.of(
                        "cell_divider",
                        "horizontal_video_shelf",
                        "horizontal_shelf."
                    )
                    .anyMatch(strTemplateTreeComponents::contains)) {
                        return currentNavBarIndex != libraryNavButtonIndex;
            }
        //-----------------------------------------------------------------------------------//
        //----------------------------------Live Chat Panel----------------------------------//
            if (strTemplateTreeComponents.contains("live_chat_text_message")) {
                if (liveChatSubscribersShelf == 0) {
                    liveChatSubscribersShelf++;
                }
                if (liveChatCommunityRulesBox == 0) {
                    liveChatCommunityRulesBox++;
                }

                return false;
            }
        //-----------------------------------------------------------------------------------//
        //---------------------------------More Drawer Panel---------------------------------//
            if (strTemplateTreeComponents.contains("more_drawer.")) {
                if (strTemplateTreeComponents.contains("divider")) {
                    moreDrawerAppsAndInfo = true;
                }

                return moreDrawerAppsAndInfo;
            } else {
                moreDrawerAppsAndInfo = false;
            }
        //-----------------------------------------------------------------------------------//
        //--------------------------Multi-Selection Comments Button--------------------------//
            if (Stream.of(
                    "carousel_header",
                    "|ContainerType|ContainerType|ContainerType|"
                )
                .allMatch(strTemplateTreeComponents::contains)) {
                    return true;
            }
        //-----------------------------------------------------------------------------------//
        //-----------------------------Quick Quality Bottom Sheet----------------------------//
            if (strTemplateTreeComponents.contains("quick_quality_sheet_content")) {
                quickQualityBottomSheet = true;

                return false;
            }
        //-----------------------------------------------------------------------------------//
        //----------------------------Stable Volume Flyout Button----------------------------//
            if (strTemplateTreeComponents.contains("overflow_menu_item")) {
                return ByteBufferContainsString(protoBufferComponents, "yt_outline_volume_stable");
            }
        //-----------------------------------------------------------------------------------//
        //-------------------------------Video Lockup Components-----------------------------//
            if (videoLockupSubIdentifiers.stream().anyMatch(strTemplateTreeComponents::contains)) {
                return strTemplateTreeComponents.contains("video_lockup_with_attachment");
            }
        //-----------------------------------------------------------------------------------//





        return blockedIdentifiers.stream().anyMatch(strTemplateTreeComponents::contains);
    }

    public static void HideLiveChatCommunityRulesBox(View view) {
        if (liveChatCommunityRulesBox == 1) {
            ViewParent viewParent = view.getParent();

            try {
                HideViewByLinearLayoutParams((View) viewParent);

                liveChatCommunityRulesBox++;
            } catch (Exception ignored) { }
        }
    }

    public static void HideLiveChatSubscribersShelf(View view) {
        if (liveChatSubscribersShelf == 1) {
            view.getViewTreeObserver().addOnGlobalLayoutListener(() -> {
                ViewParent parent = view.getParent();

                try {
                    if (parent instanceof RecyclerView) {
                        ((RecyclerView) parent).setVisibility(RecyclerView.GONE);

                        liveChatSubscribersShelf++;
                    }
                } catch (Exception ignored) {}
            });
        }
    }

    public static void HideTabMyAccountGetPremium(View view, CharSequence charSequence) {
        try {
            if ((view.getParent().getParent() instanceof ViewGroup viewGroup)) {
                if (charSequence.toString().contains("Premium")) {
                    if (viewGroup.getLayoutParams() instanceof ViewGroup.MarginLayoutParams) {
                        HideViewGroupByMarginLayout(viewGroup);
                    } else {
                        HideViewGroupByLayoutParams(viewGroup);
                    }
                }
            }
        } catch (Exception ignored) {}
    }

    public static Enum<?> navigationBarPivot;
    private static final Set<String> navigationButtonsNames = new HashSet<>(Arrays.asList(
        "TAB_SHORTS"
    ));
    public static void HideNavigationbarButtons(View view) {
        try {
            if (navigationButtonsNames.stream().anyMatch(navigationBarPivot.name()::contains)) {
                HideView(view);
            }
        } catch (Exception ignored) {}
    }

    public static Enum<?> topBarPivot;
    private static final Set<String> topButtonsNames = new HashSet<>(Arrays.asList(
        "CREATION_ENTRY",
        "TAB_ACTIVITY_CAIRO"
    ));
    public static void HideTopbarButtons(View view) {
        try {
            if (topButtonsNames.stream().anyMatch(topBarPivot.name()::contains)) {
                HideView(view);
            }
        } catch (Exception ignored) {}
    }

    public static boolean HideVideoSearchBarSuggestions(String str) {
        return str.isEmpty();
    }

    public static Uri OverrideTrackingUrl(Uri trackingUrl) {
        return trackingUrl.buildUpon().authority("www.youtube.com").build();
    }

    public static void OpenVideoResolutionsFlyout(RecyclerView recyclerView) {
        recyclerView.getViewTreeObserver().addOnDrawListener(() -> {
            try {
                if (quickQualityBottomSheet) {
                    quickQualityBottomSheet = false;

                    ((ViewGroup) recyclerView.getParent().getParent().getParent()).setVisibility(View.GONE);
                    ((ViewGroup) recyclerView.getChildAt(0)).getChildAt(3).performClick();
                }
            } catch (Exception ignored) {}
        });
    }

    public static boolean ShortsPlayerBypassing(String shortsVideoID) {
        Context context = GetMainActivityContext();

        if (currentNavBarIndex != 1) {
            try {
                Intent videoPlayerIntent = new Intent(
                    Intent.ACTION_VIEW,

                    Uri.parse("https://www.youtube.com/watch?v=" + shortsVideoID)
                );
                videoPlayerIntent.setPackage(context.getPackageName());

                context.startActivity(videoPlayerIntent);

                return true;
            } catch (Exception ignore) {}
        }

        return false;
    }
}
