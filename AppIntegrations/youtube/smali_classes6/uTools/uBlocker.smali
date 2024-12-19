.class public LuTools/uBlocker;
.super Ljava/lang/Object;
.source "uBlocker.java"


# static fields
.field private static final DARK_CONSTANTS:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end field

.field private static final WHITE_COLOR:I = 0xffffff

.field private static final WHITE_CONSTANTS:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/Integer;",
            ">;"
        }
    .end annotation
.end field

.field private static final blockedIdentifiers:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field public static captionsButton:Z = false

.field private static final commentSubIdentifiers:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field public static currentNavBarIndex:I = 0x0

.field public static initVideoPanel:Z = false

.field public static isTopView:Z = false

.field private static lastTimeBackPressed:J = 0x0L

.field private static final libraryNavButtonIndex:I = 0x4

.field public static liveChatCommunityRulesBox:I

.field public static liveChatSubscribersShelf:I

.field private static moreDrawerAppsAndInfo:Z

.field public static navigationBarPivot:Ljava/lang/Enum;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/Enum<",
            "*>;"
        }
    .end annotation
.end field

.field private static final navigationButtonsNames:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field public static protoBufferComponents:Ljava/nio/ByteBuffer;

.field private static quickQualityBottomSheet:Z

.field public static topBarPivot:Ljava/lang/Enum;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/Enum<",
            "*>;"
        }
    .end annotation
.end field

.field private static final topButtonsNames:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private static final videoLockupSubIdentifiers:Ljava/util/Set;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Set<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public static synthetic $r8$lambda$40yWSUzeLiR0N6W93Rr05xn1FW4(Ljava/lang/String;Ljava/lang/CharSequence;)Z
    .locals 0

    invoke-virtual {p0, p1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result p0

    return p0
.end method

.method static constructor <clinit>()V
    .locals 11

    .line 31
    const/4 v0, 0x0

    sput-boolean v0, LuTools/uBlocker;->captionsButton:Z

    .line 32
    sput-boolean v0, LuTools/uBlocker;->initVideoPanel:Z

    .line 34
    new-instance v1, Ljava/util/HashSet;

    const/4 v2, 0x5

    new-array v3, v2, [Ljava/lang/Integer;

    .line 35
    const v4, -0xd7d7d8

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v0

    .line 36
    const v4, -0xdededf

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    const/4 v5, 0x1

    aput-object v4, v3, v5

    .line 37
    const v4, -0xe7e7e8

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    const/4 v6, 0x2

    aput-object v4, v3, v6

    .line 38
    const v4, -0xf0f0f1

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    const/4 v7, 0x3

    aput-object v4, v3, v7

    .line 39
    const v4, -0x5dededf

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    const/4 v8, 0x4

    aput-object v4, v3, v8

    .line 34
    invoke-static {v3}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v3

    invoke-direct {v1, v3}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->DARK_CONSTANTS:Ljava/util/Set;

    .line 42
    new-instance v1, Ljava/util/HashSet;

    new-array v3, v7, [Ljava/lang/Integer;

    .line 43
    const/4 v4, -0x1

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v0

    .line 44
    const v4, -0x60607

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v5

    .line 45
    const v4, -0x5000001

    invoke-static {v4}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    aput-object v4, v3, v6

    .line 42
    invoke-static {v3}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v3

    invoke-direct {v1, v3}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->WHITE_CONSTANTS:Ljava/util/Set;

    .line 78
    sput-boolean v0, LuTools/uBlocker;->isTopView:Z

    .line 79
    const-wide/16 v3, 0x0

    sput-wide v3, LuTools/uBlocker;->lastTimeBackPressed:J

    .line 106
    new-instance v1, Ljava/util/HashSet;

    const/16 v3, 0x44

    new-array v3, v3, [Ljava/lang/String;

    const-string v4, "carousel_footered_layout"

    aput-object v4, v3, v0

    const-string v4, "carousel_headered_layout"

    aput-object v4, v3, v5

    const-string v4, "full_width_portrait_image_layout"

    aput-object v4, v3, v6

    const-string v4, "full_width_square_image_layout"

    aput-object v4, v3, v7

    const-string v4, "landscape_image_wide_button_layout"

    aput-object v4, v3, v8

    const-string v4, "square_image_layout"

    aput-object v4, v3, v2

    const-string v4, "text_image_button_group_layout"

    const/4 v9, 0x6

    aput-object v4, v3, v9

    const/4 v4, 0x7

    const-string v10, "text_image_button_layout"

    aput-object v10, v3, v4

    const/16 v4, 0x8

    const-string v10, "video_display_button_group_layout"

    aput-object v10, v3, v4

    const/16 v4, 0x9

    const-string v10, "video_display_full_buttoned_layout"

    aput-object v10, v3, v4

    const/16 v4, 0xa

    const-string v10, "video_display_full_layout"

    aput-object v10, v3, v4

    const/16 v4, 0xb

    const-string v10, "video_display_carousel_button_group_layout"

    aput-object v10, v3, v4

    const/16 v4, 0xc

    const-string v10, "brand_video_singleton"

    aput-object v10, v3, v4

    const/16 v4, 0xd

    const-string v10, "browsy_bar"

    aput-object v10, v3, v4

    const/16 v4, 0xe

    const-string v10, "cell_expandable_metadata"

    aput-object v10, v3, v4

    const/16 v4, 0xf

    const-string v10, "channel_guidelines_entry_banner"

    aput-object v10, v3, v4

    const/16 v4, 0x10

    const-string v10, "chips_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x11

    const-string v10, "community_guidelines"

    aput-object v10, v3, v4

    const/16 v4, 0x12

    const-string v10, "compact_tvfilm_item"

    aput-object v10, v3, v4

    const/16 v4, 0x13

    const-string v10, "composer_short_creation_button"

    aput-object v10, v3, v4

    const/16 v4, 0x14

    const-string v10, "composer_timestamp_button"

    aput-object v10, v3, v4

    const/16 v4, 0x15

    const-string v10, "emergency_onebox"

    aput-object v10, v3, v4

    const/16 v4, 0x16

    const-string v10, "expandable_list"

    aput-object v10, v3, v4

    const/16 v4, 0x17

    const-string v10, "featured_channel_watermark_overlay"

    aput-object v10, v3, v4

    const/16 v4, 0x18

    const-string v10, "feed_nudge"

    aput-object v10, v3, v4

    const/16 v4, 0x19

    const-string v10, "fullscreen_related_videos_entry_point"

    aput-object v10, v3, v4

    const/16 v4, 0x1a

    const-string v10, "grid_channel_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x1b

    const-string v10, "hero_carousel"

    aput-object v10, v3, v4

    const/16 v4, 0x1c

    const-string v10, "horizontal_gaming_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x1d

    const-string v10, "horizontal_tile_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x1e

    const-string v10, "image_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x1f

    const-string v10, "images_post_root_slim"

    aput-object v10, v3, v4

    const/16 v4, 0x20

    const-string v10, "info_card_teaser_overlay"

    aput-object v10, v3, v4

    const/16 v4, 0x21

    const-string v10, "infocards_section"

    aput-object v10, v3, v4

    const/16 v4, 0x22

    const-string v10, "live_chat_sponsorships_new_member_announcement"

    aput-object v10, v3, v4

    const/16 v4, 0x23

    const-string v10, "live_chat_text_message_banner"

    aput-object v10, v3, v4

    const/16 v4, 0x24

    const-string v10, "macro_markers_carousel"

    aput-object v10, v3, v4

    const/16 v4, 0x25

    const-string v10, "medical_panel"

    aput-object v10, v3, v4

    const/16 v4, 0x26

    const-string v10, "member_recognition_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x27

    const-string v10, "music_recap_banner"

    aput-object v10, v3, v4

    const/16 v4, 0x28

    const-string v10, "offer_module_root"

    aput-object v10, v3, v4

    const/16 v4, 0x29

    const-string v10, "paid_content_overlay"

    aput-object v10, v3, v4

    const/16 v4, 0x2a

    const-string v10, "playlist_section"

    aput-object v10, v3, v4

    const/16 v4, 0x2b

    const-string v10, "post_base_wrapper"

    aput-object v10, v3, v4

    const/16 v4, 0x2c

    const-string v10, "post_base_wrapper_slim"

    aput-object v10, v3, v4

    const/16 v4, 0x2d

    const-string v10, "post_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x2e

    const-string v10, "product_carousel"

    aput-object v10, v3, v4

    const/16 v4, 0x2f

    const-string v10, "products_in_video_with_preview"

    aput-object v10, v3, v4

    const/16 v4, 0x30

    const-string v10, "publisher_transparency_panel"

    aput-object v10, v3, v4

    const/16 v4, 0x31

    const-string v10, "reel_multi_format_link"

    aput-object v10, v3, v4

    const/16 v4, 0x32

    const-string v10, "reel_pivot_button"

    aput-object v10, v3, v4

    const/16 v4, 0x33

    const-string v10, "reel_player_disclosure"

    aput-object v10, v3, v4

    const/16 v4, 0x34

    const-string v10, "reel_sound_metadata"

    aput-object v10, v3, v4

    const/16 v4, 0x35

    const-string v10, "search_friction"

    aput-object v10, v3, v4

    const/16 v4, 0x36

    const-string v10, "shelf_header"

    aput-object v10, v3, v4

    const/16 v4, 0x37

    const-string v10, "shorts_info_panel_overview"

    aput-object v10, v3, v4

    const/16 v4, 0x38

    const-string v10, "shorts_paused_state"

    aput-object v10, v3, v4

    const/16 v4, 0x39

    const-string v10, "shorts_shelf"

    aput-object v10, v3, v4

    const/16 v4, 0x3a

    const-string v10, "single_item_information_panel"

    aput-object v10, v3, v4

    const/16 v4, 0x3b

    const-string v10, "statement_banner"

    aput-object v10, v3, v4

    const/16 v4, 0x3c

    const-string v10, "super_chat_item"

    aput-object v10, v3, v4

    const/16 v4, 0x3d

    const-string v10, "super_thanks_button"

    aput-object v10, v3, v4

    const/16 v4, 0x3e

    const-string v10, "text_post_root_slim"

    aput-object v10, v3, v4

    const/16 v4, 0x3f

    const-string v10, "timed_reaction"

    aput-object v10, v3, v4

    const/16 v4, 0x40

    const-string v10, "topic_with_thumbnail_view_model"

    aput-object v10, v3, v4

    const/16 v4, 0x41

    const-string v10, "transcript_section"

    aput-object v10, v3, v4

    const/16 v4, 0x42

    const-string v10, "video_attributes_section"

    aput-object v10, v3, v4

    const/16 v4, 0x43

    const-string v10, "|suggested_action."

    aput-object v10, v3, v4

    invoke-static {v3}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v3

    invoke-direct {v1, v3}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->blockedIdentifiers:Ljava/util/Set;

    .line 178
    new-instance v1, Ljava/util/HashSet;

    new-array v3, v8, [Ljava/lang/String;

    const-string v4, "sponsorships_comments_footer"

    aput-object v4, v3, v0

    const-string v4, "sponsorships_comments_header"

    aput-object v4, v3, v5

    const-string v4, "sponsorships_comments_upsell"

    aput-object v4, v3, v6

    const-string v4, "|carousel_item."

    aput-object v4, v3, v7

    invoke-static {v3}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v3

    invoke-direct {v1, v3}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->commentSubIdentifiers:Ljava/util/Set;

    .line 184
    new-instance v1, Ljava/util/HashSet;

    new-array v3, v9, [Ljava/lang/String;

    const-string v4, "endorsement_header_footer"

    aput-object v4, v3, v0

    const-string v4, "expandable_metadata"

    aput-object v4, v3, v5

    const-string v4, "set_reminder_button"

    aput-object v4, v3, v6

    const-string v4, "slimline_survey_video_with_context"

    aput-object v4, v3, v7

    const-string v4, "snappy_horizontal_shelf"

    aput-object v4, v3, v8

    const-string v4, "video_metadata_carousel"

    aput-object v4, v3, v2

    invoke-static {v3}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->videoLockupSubIdentifiers:Ljava/util/Set;

    .line 193
    sput v0, LuTools/uBlocker;->currentNavBarIndex:I

    .line 195
    sput v0, LuTools/uBlocker;->liveChatSubscribersShelf:I

    .line 196
    sput v0, LuTools/uBlocker;->liveChatCommunityRulesBox:I

    .line 197
    sput-boolean v0, LuTools/uBlocker;->moreDrawerAppsAndInfo:Z

    .line 198
    sput-boolean v0, LuTools/uBlocker;->quickQualityBottomSheet:Z

    .line 199
    invoke-static {v0}, Ljava/nio/ByteBuffer;->allocate(I)Ljava/nio/ByteBuffer;

    move-result-object v1

    sput-object v1, LuTools/uBlocker;->protoBufferComponents:Ljava/nio/ByteBuffer;

    .line 338
    new-instance v1, Ljava/util/HashSet;

    new-array v2, v5, [Ljava/lang/String;

    const-string v3, "TAB_SHORTS"

    aput-object v3, v2, v0

    invoke-static {v2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->navigationButtonsNames:Ljava/util/Set;

    .line 350
    new-instance v1, Ljava/util/HashSet;

    new-array v2, v6, [Ljava/lang/String;

    const-string v3, "CREATION_ENTRY"

    aput-object v3, v2, v0

    const-string v0, "TAB_ACTIVITY_CAIRO"

    aput-object v0, v2, v5

    invoke-static {v2}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    invoke-direct {v1, v0}, Ljava/util/HashSet;-><init>(Ljava/util/Collection;)V

    sput-object v1, LuTools/uBlocker;->topButtonsNames:Ljava/util/Set;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 30
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static declared-synchronized ChangeLithoUIColor(I)I
    .locals 3
    .param p0, "originalValue"    # I

    const-class v0, LuTools/uBlocker;

    monitor-enter v0

    .line 48
    :try_start_0
    invoke-static {}, LuTools/uUtils;->CheckDarkTheme()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 50
    sget-object v1, LuTools/uBlocker;->DARK_CONSTANTS:Ljava/util/Set;

    goto :goto_0

    .line 52
    :cond_0
    sget-object v1, LuTools/uBlocker;->WHITE_CONSTANTS:Ljava/util/Set;

    .line 53
    :goto_0
    invoke-interface {v1}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v1

    new-instance v2, LuTools/uBlocker$$ExternalSyntheticLambda1;

    invoke-direct {v2, p0}, LuTools/uBlocker$$ExternalSyntheticLambda1;-><init>(I)V

    .line 54
    invoke-interface {v1, v2}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v1

    if-eqz v1, :cond_2

    .line 56
    invoke-static {}, LuTools/uUtils;->CheckDarkTheme()Z

    move-result v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v1, :cond_1

    .line 58
    const v1, -0xffffff

    goto :goto_1

    .line 60
    :cond_1
    const v1, 0xffffff

    goto :goto_1

    .line 62
    :cond_2
    move v1, p0

    .line 48
    :goto_1
    monitor-exit v0

    return v1

    .line 47
    .end local p0    # "originalValue":I
    :catchall_0
    move-exception p0

    :try_start_1
    monitor-exit v0
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw p0
.end method

.method public static CheckMicroGPackage(Landroid/app/Activity;)V
    .locals 3
    .param p0, "activity"    # Landroid/app/Activity;

    .line 67
    :try_start_0
    invoke-virtual {p0}, Landroid/app/Activity;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    .line 68
    .local v0, "manager":Landroid/content/pm/PackageManager;
    const-string v1, "app.revanced.android.gms"

    const/4 v2, 0x1

    invoke-virtual {v0, v1, v2}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;
    :try_end_0
    .catch Landroid/content/pm/PackageManager$NameNotFoundException; {:try_start_0 .. :try_end_0} :catch_0

    .line 75
    nop

    .end local v0    # "manager":Landroid/content/pm/PackageManager;
    goto :goto_0

    .line 73
    :catch_0
    move-exception v0

    .line 74
    .local v0, "exception":Landroid/content/pm/PackageManager$NameNotFoundException;
    const-string v1, "Error: No MicroG Installed"

    invoke-static {v1}, LuTools/uUtils;->ShowToastLong(Ljava/lang/String;)V

    .line 76
    .end local v0    # "exception":Landroid/content/pm/PackageManager$NameNotFoundException;
    :goto_0
    return-void
.end method

.method public static CloseActivityOnBackPressed(Lcom/google/android/apps/youtube/app/watchwhile/MainActivity;)V
    .locals 6
    .param p0, "activity"    # Lcom/google/android/apps/youtube/app/watchwhile/MainActivity;

    .line 81
    sget-boolean v0, LuTools/uBlocker;->isTopView:Z

    if-eqz v0, :cond_1

    .line 82
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    .line 84
    .local v0, "time":J
    sget-wide v2, LuTools/uBlocker;->lastTimeBackPressed:J

    sub-long v2, v0, v2

    const-wide/16 v4, 0x3e8

    cmp-long v2, v2, v4

    if-ltz v2, :cond_0

    .line 85
    sput-wide v0, LuTools/uBlocker;->lastTimeBackPressed:J

    goto :goto_0

    .line 87
    :cond_0
    const/4 v2, 0x0

    sput-boolean v2, LuTools/uBlocker;->isTopView:Z

    .line 89
    const-wide/16 v2, 0x0

    sput-wide v2, LuTools/uBlocker;->lastTimeBackPressed:J

    .line 91
    invoke-virtual {p0}, Lcom/google/android/apps/youtube/app/watchwhile/MainActivity;->finish()V

    .line 94
    .end local v0    # "time":J
    :cond_1
    :goto_0
    return-void
.end method

.method public static DisableAutoPlayCountdown(Landroid/view/View;)V
    .locals 1
    .param p0, "view"    # Landroid/view/View;

    .line 98
    :try_start_0
    invoke-virtual {p0}, Landroid/view/View;->callOnClick()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 99
    :goto_0
    goto :goto_1

    :catch_0
    move-exception v0

    goto :goto_0

    .line 100
    :goto_1
    return-void
.end method

.method public static HideHighBitrateResolution(Ljava/lang/String;)Z
    .locals 1
    .param p0, "originalValue"    # Ljava/lang/String;

    .line 103
    const-string v0, "Premium"

    invoke-virtual {p0, v0}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v0

    return v0
.end method

.method public static declared-synchronized HideLithoTemplate(Ljava/lang/StringBuilder;)Z
    .locals 8
    .param p0, "templateTreeComponents"    # Ljava/lang/StringBuilder;

    const-class v0, LuTools/uBlocker;

    monitor-enter v0

    .line 201
    :try_start_0
    invoke-virtual {p0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 204
    .local v1, "strTemplateTreeComponents":Ljava/lang/String;
    const/4 v2, 0x2

    new-array v3, v2, [Ljava/lang/String;

    const-string v4, "comment_composer"

    const/4 v5, 0x0

    aput-object v4, v3, v5

    const-string v4, "|CellType|ContainerType|ContainerType|ContainerType|ContainerType|ContainerType|"

    const/4 v6, 0x1

    aput-object v4, v3, v6

    invoke-static {v3}, Ljava/util/stream/Stream;->of([Ljava/lang/Object;)Ljava/util/stream/Stream;

    move-result-object v3

    .line 208
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v4, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v4, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v3, v4}, Ljava/util/stream/Stream;->allMatch(Ljava/util/function/Predicate;)Z

    move-result v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v3, :cond_0

    .line 209
    monitor-exit v0

    return v6

    .line 213
    :cond_0
    const/4 v3, 0x3

    :try_start_1
    new-array v4, v3, [Ljava/lang/String;

    const-string v7, "comment_thread"

    aput-object v7, v4, v5

    const-string v7, "metadata_carousel"

    aput-object v7, v4, v6

    const-string v7, "|comment."

    aput-object v7, v4, v2

    invoke-static {v4}, Ljava/util/stream/Stream;->of([Ljava/lang/Object;)Ljava/util/stream/Stream;

    move-result-object v4

    .line 218
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v7, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v7, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v4, v7}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 219
    sget-object v2, LuTools/uBlocker;->commentSubIdentifiers:Ljava/util/Set;

    .line 220
    invoke-interface {v2}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v2

    .line 221
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v3, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v3, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v2
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 219
    monitor-exit v0

    return v2

    .line 225
    :cond_1
    :try_start_2
    const-string v4, "account_header"

    invoke-virtual {v1, v4}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v4

    const/4 v7, 0x4

    if-eqz v4, :cond_2

    .line 226
    sput v7, LuTools/uBlocker;->currentNavBarIndex:I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 228
    monitor-exit v0

    return v5

    .line 229
    :cond_2
    :try_start_3
    new-array v3, v3, [Ljava/lang/String;

    const-string v4, "cell_divider"

    aput-object v4, v3, v5

    const-string v4, "horizontal_video_shelf"

    aput-object v4, v3, v6

    const-string v4, "horizontal_shelf."

    aput-object v4, v3, v2

    invoke-static {v3}, Ljava/util/stream/Stream;->of([Ljava/lang/Object;)Ljava/util/stream/Stream;

    move-result-object v3

    .line 234
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v4, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v4, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v3, v4}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v3

    if-eqz v3, :cond_4

    .line 235
    sget v2, LuTools/uBlocker;->currentNavBarIndex:I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    if-eq v2, v7, :cond_3

    move v5, v6

    :cond_3
    monitor-exit v0

    return v5

    .line 239
    :cond_4
    :try_start_4
    const-string v3, "live_chat_text_message"

    invoke-virtual {v1, v3}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-eqz v3, :cond_7

    .line 240
    sget v2, LuTools/uBlocker;->liveChatSubscribersShelf:I

    if-nez v2, :cond_5

    .line 241
    sget v2, LuTools/uBlocker;->liveChatSubscribersShelf:I

    add-int/2addr v2, v6

    sput v2, LuTools/uBlocker;->liveChatSubscribersShelf:I

    .line 243
    :cond_5
    sget v2, LuTools/uBlocker;->liveChatCommunityRulesBox:I

    if-nez v2, :cond_6

    .line 244
    sget v2, LuTools/uBlocker;->liveChatCommunityRulesBox:I

    add-int/2addr v2, v6

    sput v2, LuTools/uBlocker;->liveChatCommunityRulesBox:I
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 247
    :cond_6
    monitor-exit v0

    return v5

    .line 251
    :cond_7
    :try_start_5
    const-string v3, "more_drawer."

    invoke-virtual {v1, v3}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v3

    if-eqz v3, :cond_9

    .line 252
    const-string v2, "divider"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_8

    .line 253
    sput-boolean v6, LuTools/uBlocker;->moreDrawerAppsAndInfo:Z

    .line 256
    :cond_8
    sget-boolean v2, LuTools/uBlocker;->moreDrawerAppsAndInfo:Z
    :try_end_5
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    monitor-exit v0

    return v2

    .line 258
    :cond_9
    :try_start_6
    sput-boolean v5, LuTools/uBlocker;->moreDrawerAppsAndInfo:Z

    .line 262
    new-array v2, v2, [Ljava/lang/String;

    const-string v3, "carousel_header"

    aput-object v3, v2, v5

    const-string v3, "|ContainerType|ContainerType|ContainerType|"

    aput-object v3, v2, v6

    invoke-static {v2}, Ljava/util/stream/Stream;->of([Ljava/lang/Object;)Ljava/util/stream/Stream;

    move-result-object v2

    .line 266
    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v3, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v3, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/stream/Stream;->allMatch(Ljava/util/function/Predicate;)Z

    move-result v2
    :try_end_6
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    if-eqz v2, :cond_a

    .line 267
    monitor-exit v0

    return v6

    .line 271
    :cond_a
    :try_start_7
    const-string v2, "quick_quality_sheet_content"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_b

    .line 272
    sput-boolean v6, LuTools/uBlocker;->quickQualityBottomSheet:Z
    :try_end_7
    .catchall {:try_start_7 .. :try_end_7} :catchall_0

    .line 274
    monitor-exit v0

    return v5

    .line 278
    :cond_b
    :try_start_8
    const-string v2, "overflow_menu_item"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_c

    .line 279
    sget-object v2, LuTools/uBlocker;->protoBufferComponents:Ljava/nio/ByteBuffer;

    const-string v3, "yt_outline_volume_stable"

    invoke-static {v2, v3}, LuTools/uUtils;->ByteBufferContainsString(Ljava/nio/ByteBuffer;Ljava/lang/String;)Z

    move-result v2
    :try_end_8
    .catchall {:try_start_8 .. :try_end_8} :catchall_0

    monitor-exit v0

    return v2

    .line 283
    :cond_c
    :try_start_9
    sget-object v2, LuTools/uBlocker;->videoLockupSubIdentifiers:Ljava/util/Set;

    invoke-interface {v2}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v2

    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v3, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v3, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v2

    if-eqz v2, :cond_d

    .line 284
    const-string v2, "video_lockup_with_attachment"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v2
    :try_end_9
    .catchall {:try_start_9 .. :try_end_9} :catchall_0

    monitor-exit v0

    return v2

    .line 292
    :cond_d
    :try_start_a
    sget-object v2, LuTools/uBlocker;->blockedIdentifiers:Ljava/util/Set;

    invoke-interface {v2}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v2

    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v3, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v3, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v2
    :try_end_a
    .catchall {:try_start_a .. :try_end_a} :catchall_0

    monitor-exit v0

    return v2

    .line 200
    .end local v1    # "strTemplateTreeComponents":Ljava/lang/String;
    .end local p0    # "templateTreeComponents":Ljava/lang/StringBuilder;
    :catchall_0
    move-exception p0

    :try_start_b
    monitor-exit v0
    :try_end_b
    .catchall {:try_start_b .. :try_end_b} :catchall_0

    throw p0
.end method

.method public static HideLiveChatCommunityRulesBox(Landroid/view/View;)V
    .locals 3
    .param p0, "view"    # Landroid/view/View;

    .line 296
    sget v0, LuTools/uBlocker;->liveChatCommunityRulesBox:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 297
    invoke-virtual {p0}, Landroid/view/View;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    .line 300
    .local v0, "viewParent":Landroid/view/ViewParent;
    :try_start_0
    move-object v2, v0

    check-cast v2, Landroid/view/View;

    invoke-static {v2}, LuTools/uUtils;->HideViewByLinearLayoutParams(Landroid/view/View;)V

    .line 302
    sget v2, LuTools/uBlocker;->liveChatCommunityRulesBox:I

    add-int/2addr v2, v1

    sput v2, LuTools/uBlocker;->liveChatCommunityRulesBox:I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 303
    :catch_0
    move-exception v1

    :goto_0
    nop

    .line 305
    .end local v0    # "viewParent":Landroid/view/ViewParent;
    :cond_0
    return-void
.end method

.method public static HideLiveChatSubscribersShelf(Landroid/view/View;)V
    .locals 2
    .param p0, "view"    # Landroid/view/View;

    .line 308
    sget v0, LuTools/uBlocker;->liveChatSubscribersShelf:I

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 309
    invoke-virtual {p0}, Landroid/view/View;->getViewTreeObserver()Landroid/view/ViewTreeObserver;

    move-result-object v0

    new-instance v1, LuTools/uBlocker$$ExternalSyntheticLambda3;

    invoke-direct {v1, p0}, LuTools/uBlocker$$ExternalSyntheticLambda3;-><init>(Landroid/view/View;)V

    invoke-virtual {v0, v1}, Landroid/view/ViewTreeObserver;->addOnGlobalLayoutListener(Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;)V

    .line 321
    :cond_0
    return-void
.end method

.method public static HideNavigationbarButtons(Landroid/view/View;)V
    .locals 3
    .param p0, "view"    # Landroid/view/View;

    .line 343
    :try_start_0
    sget-object v0, LuTools/uBlocker;->navigationButtonsNames:Ljava/util/Set;

    invoke-interface {v0}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v0

    sget-object v1, LuTools/uBlocker;->navigationBarPivot:Ljava/lang/Enum;

    invoke-virtual {v1}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v2, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v2, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v0, v2}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 344
    invoke-static {p0}, LuTools/uUtils;->HideView(Landroid/view/View;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 346
    :catch_0
    move-exception v0

    :cond_0
    :goto_0
    nop

    .line 347
    return-void
.end method

.method public static HideTabMyAccountGetPremium(Landroid/view/View;Ljava/lang/CharSequence;)V
    .locals 3
    .param p0, "view"    # Landroid/view/View;
    .param p1, "charSequence"    # Ljava/lang/CharSequence;

    .line 325
    :try_start_0
    invoke-virtual {p0}, Landroid/view/View;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    invoke-interface {v0}, Landroid/view/ViewParent;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    instance-of v1, v0, Landroid/view/ViewGroup;

    if-eqz v1, :cond_1

    check-cast v0, Landroid/view/ViewGroup;

    .line 326
    .local v0, "viewGroup":Landroid/view/ViewGroup;
    invoke-interface {p1}, Ljava/lang/CharSequence;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "Premium"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 327
    invoke-virtual {v0}, Landroid/view/ViewGroup;->getLayoutParams()Landroid/view/ViewGroup$LayoutParams;

    move-result-object v1

    instance-of v1, v1, Landroid/view/ViewGroup$MarginLayoutParams;

    if-eqz v1, :cond_0

    .line 328
    invoke-static {v0}, LuTools/uUtils;->HideViewGroupByMarginLayout(Landroid/view/ViewGroup;)V

    goto :goto_0

    .line 330
    :cond_0
    invoke-static {v0}, LuTools/uUtils;->HideViewGroupByLayoutParams(Landroid/view/ViewGroup;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 334
    .end local v0    # "viewGroup":Landroid/view/ViewGroup;
    :catch_0
    move-exception v0

    :cond_1
    :goto_0
    nop

    .line 335
    return-void
.end method

.method public static HideTopbarButtons(Landroid/view/View;)V
    .locals 3
    .param p0, "view"    # Landroid/view/View;

    .line 356
    :try_start_0
    sget-object v0, LuTools/uBlocker;->topButtonsNames:Ljava/util/Set;

    invoke-interface {v0}, Ljava/util/Set;->stream()Ljava/util/stream/Stream;

    move-result-object v0

    sget-object v1, LuTools/uBlocker;->topBarPivot:Ljava/lang/Enum;

    invoke-virtual {v1}, Ljava/lang/Enum;->name()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    new-instance v2, LuTools/uBlocker$$ExternalSyntheticLambda0;

    invoke-direct {v2, v1}, LuTools/uBlocker$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;)V

    invoke-interface {v0, v2}, Ljava/util/stream/Stream;->anyMatch(Ljava/util/function/Predicate;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 357
    invoke-static {p0}, LuTools/uUtils;->HideView(Landroid/view/View;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 359
    :catch_0
    move-exception v0

    :cond_0
    :goto_0
    nop

    .line 360
    return-void
.end method

.method public static HideVideoSearchBarSuggestions(Ljava/lang/String;)Z
    .locals 1
    .param p0, "str"    # Ljava/lang/String;

    .line 363
    invoke-virtual {p0}, Ljava/lang/String;->isEmpty()Z

    move-result v0

    return v0
.end method

.method public static OpenVideoResolutionsFlyout(Landroid/support/v7/widget/RecyclerView;)V
    .locals 2
    .param p0, "recyclerView"    # Landroid/support/v7/widget/RecyclerView;

    .line 371
    invoke-virtual {p0}, Landroid/support/v7/widget/RecyclerView;->getViewTreeObserver()Landroid/view/ViewTreeObserver;

    move-result-object v0

    new-instance v1, LuTools/uBlocker$$ExternalSyntheticLambda2;

    invoke-direct {v1, p0}, LuTools/uBlocker$$ExternalSyntheticLambda2;-><init>(Landroid/support/v7/widget/RecyclerView;)V

    invoke-virtual {v0, v1}, Landroid/view/ViewTreeObserver;->addOnDrawListener(Landroid/view/ViewTreeObserver$OnDrawListener;)V

    .line 381
    return-void
.end method

.method public static OverrideTrackingUrl(Landroid/net/Uri;)Landroid/net/Uri;
    .locals 2
    .param p0, "trackingUrl"    # Landroid/net/Uri;

    .line 367
    invoke-virtual {p0}, Landroid/net/Uri;->buildUpon()Landroid/net/Uri$Builder;

    move-result-object v0

    const-string v1, "www.youtube.com"

    invoke-virtual {v0, v1}, Landroid/net/Uri$Builder;->authority(Ljava/lang/String;)Landroid/net/Uri$Builder;

    move-result-object v0

    invoke-virtual {v0}, Landroid/net/Uri$Builder;->build()Landroid/net/Uri;

    move-result-object v0

    return-object v0
.end method

.method public static ShortsPlayerBypassing(Ljava/lang/String;)Z
    .locals 6
    .param p0, "shortsVideoID"    # Ljava/lang/String;

    .line 384
    invoke-static {}, LuTools/uUtils;->GetMainActivityContext()Landroid/content/Context;

    move-result-object v0

    .line 386
    .local v0, "context":Landroid/content/Context;
    sget v1, LuTools/uBlocker;->currentNavBarIndex:I

    const/4 v2, 0x1

    if-eq v1, v2, :cond_0

    .line 388
    :try_start_0
    new-instance v1, Landroid/content/Intent;

    const-string v3, "android.intent.action.VIEW"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "https://www.youtube.com/watch?v="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 391
    invoke-static {v4}, Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;

    move-result-object v4

    invoke-direct {v1, v3, v4}, Landroid/content/Intent;-><init>(Ljava/lang/String;Landroid/net/Uri;)V

    .line 393
    .local v1, "videoPlayerIntent":Landroid/content/Intent;
    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Landroid/content/Intent;->setPackage(Ljava/lang/String;)Landroid/content/Intent;

    .line 395
    invoke-virtual {v0, v1}, Landroid/content/Context;->startActivity(Landroid/content/Intent;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 397
    return v2

    .line 398
    .end local v1    # "videoPlayerIntent":Landroid/content/Intent;
    :catch_0
    move-exception v1

    .line 401
    :cond_0
    const/4 v1, 0x0

    return v1
.end method

.method static synthetic lambda$ChangeLithoUIColor$0(ILjava/lang/Integer;)Z
    .locals 1
    .param p0, "originalValue"    # I
    .param p1, "val"    # Ljava/lang/Integer;

    .line 54
    invoke-static {p0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/Integer;->equals(Ljava/lang/Object;)Z

    move-result v0

    return v0
.end method

.method static synthetic lambda$HideLiveChatSubscribersShelf$1(Landroid/view/View;)V
    .locals 3
    .param p0, "view"    # Landroid/view/View;

    .line 310
    invoke-virtual {p0}, Landroid/view/View;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    .line 313
    .local v0, "parent":Landroid/view/ViewParent;
    :try_start_0
    instance-of v1, v0, Landroid/support/v7/widget/RecyclerView;

    if-eqz v1, :cond_0

    .line 314
    move-object v1, v0

    check-cast v1, Landroid/support/v7/widget/RecyclerView;

    const/16 v2, 0x8

    invoke-virtual {v1, v2}, Landroid/support/v7/widget/RecyclerView;->setVisibility(I)V

    .line 316
    sget v1, LuTools/uBlocker;->liveChatSubscribersShelf:I

    add-int/lit8 v1, v1, 0x1

    sput v1, LuTools/uBlocker;->liveChatSubscribersShelf:I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 318
    :catch_0
    move-exception v1

    :cond_0
    :goto_0
    nop

    .line 319
    return-void
.end method

.method static synthetic lambda$OpenVideoResolutionsFlyout$2(Landroid/support/v7/widget/RecyclerView;)V
    .locals 3
    .param p0, "recyclerView"    # Landroid/support/v7/widget/RecyclerView;

    .line 373
    :try_start_0
    sget-boolean v0, LuTools/uBlocker;->quickQualityBottomSheet:Z

    if-eqz v0, :cond_0

    .line 374
    const/4 v0, 0x0

    sput-boolean v0, LuTools/uBlocker;->quickQualityBottomSheet:Z

    .line 376
    invoke-virtual {p0}, Landroid/support/v7/widget/RecyclerView;->getParent()Landroid/view/ViewParent;

    move-result-object v1

    invoke-interface {v1}, Landroid/view/ViewParent;->getParent()Landroid/view/ViewParent;

    move-result-object v1

    invoke-interface {v1}, Landroid/view/ViewParent;->getParent()Landroid/view/ViewParent;

    move-result-object v1

    check-cast v1, Landroid/view/ViewGroup;

    const/16 v2, 0x8

    invoke-virtual {v1, v2}, Landroid/view/ViewGroup;->setVisibility(I)V

    .line 377
    invoke-virtual {p0, v0}, Landroid/support/v7/widget/RecyclerView;->getChildAt(I)Landroid/view/View;

    move-result-object v0

    check-cast v0, Landroid/view/ViewGroup;

    const/4 v1, 0x3

    invoke-virtual {v0, v1}, Landroid/view/ViewGroup;->getChildAt(I)Landroid/view/View;

    move-result-object v0

    invoke-virtual {v0}, Landroid/view/View;->performClick()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 379
    :catch_0
    move-exception v0

    :cond_0
    :goto_0
    nop

    .line 380
    return-void
.end method
