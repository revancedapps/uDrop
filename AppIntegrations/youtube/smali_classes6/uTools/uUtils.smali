.class public LuTools/uUtils;
.super Ljava/lang/Object;
.source "uUtils.java"


# static fields
.field public static appContext:Landroid/content/Context;

.field public static currentPlayerID:Ljava/lang/String;

.field private static isDarkTheme:Z

.field private static mainActivity:Landroid/app/Activity;

.field private static mainActivityRef:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference<",
            "Landroid/app/Activity;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 42
    const-string v0, ""

    sput-object v0, LuTools/uUtils;->currentPlayerID:Ljava/lang/String;

    .line 143
    new-instance v0, Landroid/app/Activity;

    invoke-direct {v0}, Landroid/app/Activity;-><init>()V

    sput-object v0, LuTools/uUtils;->mainActivity:Landroid/app/Activity;

    .line 144
    new-instance v0, Ljava/lang/ref/WeakReference;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    sput-object v0, LuTools/uUtils;->mainActivityRef:Ljava/lang/ref/WeakReference;

    .line 153
    const/4 v0, 0x0

    sput-boolean v0, LuTools/uUtils;->isDarkTheme:Z

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .line 25
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static ByteBufferContainsString(Ljava/nio/ByteBuffer;Ljava/lang/String;)Z
    .locals 5
    .param p0, "byteBuffer"    # Ljava/nio/ByteBuffer;
    .param p1, "str"    # Ljava/lang/String;

    .line 27
    invoke-virtual {p0}, Ljava/nio/ByteBuffer;->array()[B

    move-result-object v0

    .line 28
    .local v0, "bArrSource":[B
    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    .line 30
    .local v1, "bArrTarget":[B
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_0
    array-length v3, v0

    array-length v4, v1

    sub-int/2addr v3, v4

    if-gt v2, v3, :cond_1

    .line 31
    array-length v3, v1

    add-int/2addr v3, v2

    invoke-static {v0, v2, v3}, Ljava/util/Arrays;->copyOfRange([BII)[B

    move-result-object v3

    invoke-static {v3, v1}, Ljava/util/Arrays;->equals([B[B)Z

    move-result v3

    if-eqz v3, :cond_0

    .line 32
    const/4 v3, 0x1

    return v3

    .line 30
    :cond_0
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 35
    .end local v2    # "i":I
    :cond_1
    const/4 v2, 0x0

    return v2
.end method

.method public static CheckDarkTheme()Z
    .locals 1

    .line 39
    sget-boolean v0, LuTools/uUtils;->isDarkTheme:Z

    return v0
.end method

.method public static CheckIsShortsPlayer()Z
    .locals 2

    .line 44
    sget-object v0, LuTools/uUtils;->currentPlayerID:Ljava/lang/String;

    const-string v1, "8AEB"

    invoke-virtual {v0, v1}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    return v0
.end method

.method public static GetAppContext()Landroid/content/Context;
    .locals 2

    .line 49
    sget-object v0, LuTools/uUtils;->appContext:Landroid/content/Context;

    if-nez v0, :cond_0

    .line 50
    const-string v0, "uContext"

    const-string v1, "App Context is null"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 52
    const/4 v0, 0x0

    return-object v0

    .line 54
    :cond_0
    sget-object v0, LuTools/uUtils;->appContext:Landroid/content/Context;

    return-object v0
.end method

.method public static GetMainActivity()Landroid/app/Activity;
    .locals 2

    .line 59
    sget-object v0, LuTools/uUtils;->mainActivity:Landroid/app/Activity;

    if-nez v0, :cond_0

    .line 60
    const-string v0, "uActivity"

    const-string v1, "Main Activity is null"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 62
    const/4 v0, 0x0

    return-object v0

    .line 64
    :cond_0
    sget-object v0, LuTools/uUtils;->mainActivity:Landroid/app/Activity;

    return-object v0
.end method

.method public static GetMainActivityContext()Landroid/content/Context;
    .locals 3

    .line 81
    sget-object v0, LuTools/uUtils;->mainActivityRef:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/WeakReference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    .line 83
    .local v0, "mainActivityContext":Landroid/content/Context;
    if-nez v0, :cond_0

    .line 84
    const-string v1, "uContext"

    const-string v2, "Main Activity Context is null"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    const/4 v1, 0x0

    return-object v1

    .line 88
    :cond_0
    return-object v0
.end method

.method public static HideImageView(Landroid/widget/ImageView;)V
    .locals 1
    .param p0, "imageView"    # Landroid/widget/ImageView;

    .line 93
    const/16 v0, 0x8

    invoke-virtual {p0, v0}, Landroid/widget/ImageView;->setVisibility(I)V

    .line 94
    return-void
.end method

.method public static HideInstanceViewByLayoutParams(Landroid/view/View;)V
    .locals 2
    .param p0, "view"    # Landroid/view/View;

    .line 97
    instance-of v0, p0, Landroid/view/ViewGroup;

    if-eqz v0, :cond_0

    .line 98
    new-instance v0, Landroid/view/ViewGroup$LayoutParams;

    const/4 v1, 0x1

    invoke-direct {v0, v1, v1}, Landroid/view/ViewGroup$LayoutParams;-><init>(II)V

    invoke-virtual {p0, v0}, Landroid/view/View;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 100
    :cond_0
    return-void
.end method

.method public static HideView(Landroid/view/View;)V
    .locals 1
    .param p0, "view"    # Landroid/view/View;

    .line 103
    const/16 v0, 0x8

    invoke-virtual {p0, v0}, Landroid/view/View;->setVisibility(I)V

    .line 104
    return-void
.end method

.method public static HideViewByLinearLayoutParams(Landroid/view/View;)V
    .locals 2
    .param p0, "view"    # Landroid/view/View;

    .line 107
    new-instance v0, Landroid/widget/LinearLayout$LayoutParams;

    const/4 v1, 0x0

    invoke-direct {v0, v1, v1}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V

    invoke-virtual {p0, v0}, Landroid/view/View;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 108
    return-void
.end method

.method public static HideViewGroupByLayoutParams(Landroid/view/ViewGroup;)V
    .locals 2
    .param p0, "viewGroup"    # Landroid/view/ViewGroup;

    .line 111
    new-instance v0, Landroid/view/ViewGroup$LayoutParams;

    const/4 v1, 0x0

    invoke-direct {v0, v1, v1}, Landroid/view/ViewGroup$LayoutParams;-><init>(II)V

    invoke-virtual {p0, v0}, Landroid/view/ViewGroup;->setLayoutParams(Landroid/view/ViewGroup$LayoutParams;)V

    .line 112
    return-void
.end method

.method public static HideViewGroupByMarginLayout(Landroid/view/ViewGroup;)V
    .locals 1
    .param p0, "viewGroup"    # Landroid/view/ViewGroup;

    .line 115
    const/16 v0, 0x8

    invoke-virtual {p0, v0}, Landroid/view/ViewGroup;->setVisibility(I)V

    .line 116
    return-void
.end method

.method public static IsCurrentlyOnMainThread()Z
    .locals 1

    .line 119
    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-virtual {v0}, Landroid/os/Looper;->isCurrentThread()Z

    move-result v0

    return v0
.end method

.method public static RunOnMainThread(Ljava/lang/Runnable;)V
    .locals 2
    .param p0, "runnable"    # Ljava/lang/Runnable;

    .line 123
    const-wide/16 v0, 0x0

    invoke-static {p0, v0, v1}, LuTools/uUtils;->RunOnMainThreadDelayed(Ljava/lang/Runnable;J)V

    .line 124
    return-void
.end method

.method public static RunOnMainThreadDelayed(Ljava/lang/Runnable;J)V
    .locals 3
    .param p0, "runnable"    # Ljava/lang/Runnable;
    .param p1, "delayMillis"    # J

    .line 127
    new-instance v0, LuTools/uUtils$$ExternalSyntheticLambda1;

    invoke-direct {v0, p0}, LuTools/uUtils$$ExternalSyntheticLambda1;-><init>(Ljava/lang/Runnable;)V

    .line 132
    .local v0, "loggingRunnable":Ljava/lang/Runnable;
    new-instance v1, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v2

    invoke-direct {v1, v2}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    invoke-virtual {v1, v0, p1, p2}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 133
    return-void
.end method

.method public static RunOnMainThreadNowOrLater(Ljava/lang/Runnable;)V
    .locals 1
    .param p0, "runnable"    # Ljava/lang/Runnable;

    .line 136
    invoke-static {}, LuTools/uUtils;->IsCurrentlyOnMainThread()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 137
    invoke-interface {p0}, Ljava/lang/Runnable;->run()V

    goto :goto_0

    .line 139
    :cond_0
    invoke-static {p0}, LuTools/uUtils;->RunOnMainThread(Ljava/lang/Runnable;)V

    .line 141
    :goto_0
    return-void
.end method

.method public static SetAppTheme(Z)V
    .locals 0
    .param p0, "value"    # Z

    .line 158
    sput-boolean p0, LuTools/uUtils;->isDarkTheme:Z

    .line 159
    return-void
.end method

.method public static SetMainActivity(Landroid/app/Activity;)V
    .locals 1
    .param p0, "activity"    # Landroid/app/Activity;

    .line 146
    sput-object p0, LuTools/uUtils;->mainActivity:Landroid/app/Activity;

    .line 148
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    sput-object v0, LuTools/uUtils;->mainActivityRef:Ljava/lang/ref/WeakReference;

    .line 150
    invoke-static {p0}, LuTools/uUtils;->SetNavBarIndexByMainActivity(Landroid/app/Activity;)V

    .line 151
    return-void
.end method

.method public static SetNavBarIndexByMainActivity(Landroid/app/Activity;)V
    .locals 2
    .param p0, "activity"    # Landroid/app/Activity;

    .line 69
    invoke-virtual {p0}, Landroid/app/Activity;->getIntent()Landroid/content/Intent;

    move-result-object v0

    invoke-virtual {v0}, Landroid/content/Intent;->getAction()Ljava/lang/String;

    move-result-object v0

    .line 72
    .local v0, "intentAction":Ljava/lang/String;
    :try_start_0
    const-string v1, "com.google.android.youtube.action.open.shorts"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 73
    const/4 v1, 0x1

    sput v1, LuTools/uBlocker;->currentNavBarIndex:I

    goto :goto_0

    .line 74
    :cond_0
    const-string v1, "com.google.android.youtube.action.open.subscriptions"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 75
    const/4 v1, 0x2

    sput v1, LuTools/uBlocker;->currentNavBarIndex:I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 77
    :catch_0
    move-exception v1

    :cond_1
    :goto_0
    nop

    .line 78
    return-void
.end method

.method public static SetSystemTheme(Ljava/lang/Enum;)V
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/Enum<",
            "*>;)V"
        }
    .end annotation

    .line 155
    .local p0, "e":Ljava/lang/Enum;, "Ljava/lang/Enum<*>;"
    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    const/4 v1, 0x1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Integer;->equals(Ljava/lang/Object;)Z

    move-result v0

    sput-boolean v0, LuTools/uUtils;->isDarkTheme:Z

    .line 156
    return-void
.end method

.method private static ShowToast(Ljava/lang/String;I)V
    .locals 1
    .param p0, "messageToToast"    # Ljava/lang/String;
    .param p1, "toastDuration"    # I

    .line 166
    invoke-static {p0}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 167
    new-instance v0, LuTools/uUtils$$ExternalSyntheticLambda0;

    invoke-direct {v0, p0, p1}, LuTools/uUtils$$ExternalSyntheticLambda0;-><init>(Ljava/lang/String;I)V

    invoke-static {v0}, LuTools/uUtils;->RunOnMainThreadNowOrLater(Ljava/lang/Runnable;)V

    .line 170
    return-void
.end method

.method public static ShowToastLong(Ljava/lang/String;)V
    .locals 1
    .param p0, "messageToToast"    # Ljava/lang/String;

    .line 162
    const/4 v0, 0x1

    invoke-static {p0, v0}, LuTools/uUtils;->ShowToast(Ljava/lang/String;I)V

    .line 163
    return-void
.end method

.method static synthetic lambda$RunOnMainThreadDelayed$0(Ljava/lang/Runnable;)V
    .locals 1
    .param p0, "runnable"    # Ljava/lang/Runnable;

    .line 129
    :try_start_0
    invoke-interface {p0}, Ljava/lang/Runnable;->run()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 130
    :goto_0
    goto :goto_1

    :catch_0
    move-exception v0

    goto :goto_0

    .line 131
    :goto_1
    return-void
.end method

.method static synthetic lambda$ShowToast$1(Ljava/lang/String;I)V
    .locals 1
    .param p0, "messageToToast"    # Ljava/lang/String;
    .param p1, "toastDuration"    # I

    .line 168
    invoke-static {}, LuTools/uUtils;->GetAppContext()Landroid/content/Context;

    move-result-object v0

    invoke-static {v0, p0, p1}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v0

    invoke-virtual {v0}, Landroid/widget/Toast;->show()V

    .line 169
    return-void
.end method
