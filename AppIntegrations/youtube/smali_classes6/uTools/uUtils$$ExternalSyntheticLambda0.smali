.class public final synthetic LuTools/uUtils$$ExternalSyntheticLambda0;
.super Ljava/lang/Object;
.source "D8$$SyntheticClass"

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field public final synthetic f$0:Ljava/lang/String;

.field public final synthetic f$1:I


# direct methods
.method public synthetic constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, LuTools/uUtils$$ExternalSyntheticLambda0;->f$0:Ljava/lang/String;

    iput p2, p0, LuTools/uUtils$$ExternalSyntheticLambda0;->f$1:I

    return-void
.end method


# virtual methods
.method public final run()V
    .locals 2

    .line 0
    iget-object v0, p0, LuTools/uUtils$$ExternalSyntheticLambda0;->f$0:Ljava/lang/String;

    iget v1, p0, LuTools/uUtils$$ExternalSyntheticLambda0;->f$1:I

    invoke-static {v0, v1}, LuTools/uUtils;->lambda$ShowToast$1(Ljava/lang/String;I)V

    return-void
.end method
