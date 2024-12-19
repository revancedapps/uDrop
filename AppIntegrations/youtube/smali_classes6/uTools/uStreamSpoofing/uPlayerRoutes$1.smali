.class LuTools/uStreamSpoofing/uPlayerRoutes$1;
.super Lorg/json/JSONObject;
.source "uPlayerRoutes.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = LuTools/uStreamSpoofing/uPlayerRoutes;->createInnertubeBody(LuTools/uStreamSpoofing/uClientType;)Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic val$client:Lorg/json/JSONObject;


# direct methods
.method constructor <init>(Lorg/json/JSONObject;)V
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .line 38
    iput-object p1, p0, LuTools/uStreamSpoofing/uPlayerRoutes$1;->val$client:Lorg/json/JSONObject;

    invoke-direct {p0}, Lorg/json/JSONObject;-><init>()V

    .line 39
    const-string p1, "client"

    iget-object v0, p0, LuTools/uStreamSpoofing/uPlayerRoutes$1;->val$client:Lorg/json/JSONObject;

    invoke-virtual {p0, p1, v0}, LuTools/uStreamSpoofing/uPlayerRoutes$1;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 40
    return-void
.end method
