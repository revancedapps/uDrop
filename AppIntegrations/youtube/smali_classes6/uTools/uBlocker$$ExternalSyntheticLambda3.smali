.class public final synthetic LuTools/uBlocker$$ExternalSyntheticLambda3;
.super Ljava/lang/Object;
.source "D8$$SyntheticClass"

# interfaces
.implements Landroid/view/ViewTreeObserver$OnGlobalLayoutListener;


# instance fields
.field public final synthetic f$0:Landroid/view/View;


# direct methods
.method public synthetic constructor <init>(Landroid/view/View;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, LuTools/uBlocker$$ExternalSyntheticLambda3;->f$0:Landroid/view/View;

    return-void
.end method


# virtual methods
.method public final onGlobalLayout()V
    .locals 1

    .line 0
    iget-object v0, p0, LuTools/uBlocker$$ExternalSyntheticLambda3;->f$0:Landroid/view/View;

    invoke-static {v0}, LuTools/uBlocker;->lambda$HideLiveChatSubscribersShelf$1(Landroid/view/View;)V

    return-void
.end method
