.class final LuTools/uStreamSpoofing/uPlayerRoutes;
.super Ljava/lang/Object;
.source "uPlayerRoutes.java"


# static fields
.field private static final CONNECTION_TIMEOUT_MILLISECONDS:I = 0x2710

.field static final GET_STREAMING_DATA:LuTools/uStreamSpoofing/uRoute$CompiledRoute;

.field private static final YT_API_URL:Ljava/lang/String; = "https://youtubei.googleapis.com/youtubei/v1/"


# direct methods
.method static constructor <clinit>()V
    .locals 5

    .line 14
    new-instance v0, LuTools/uStreamSpoofing/uRoute;

    sget-object v1, LuTools/uStreamSpoofing/uRoute$Method;->POST:LuTools/uStreamSpoofing/uRoute$Method;

    const-string v2, "?fields=streamingData"

    const-string v3, "&alt=proto"

    const-string v4, "player"

    filled-new-array {v4, v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 16
    const-string v3, "%s%s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v1, v2}, LuTools/uStreamSpoofing/uRoute;-><init>(LuTools/uStreamSpoofing/uRoute$Method;Ljava/lang/String;)V

    const/4 v1, 0x0

    new-array v1, v1, [Ljava/lang/String;

    .line 23
    invoke-virtual {v0, v1}, LuTools/uStreamSpoofing/uRoute;->compile([Ljava/lang/String;)LuTools/uStreamSpoofing/uRoute$CompiledRoute;

    move-result-object v0

    sput-object v0, LuTools/uStreamSpoofing/uPlayerRoutes;->GET_STREAMING_DATA:LuTools/uStreamSpoofing/uRoute$CompiledRoute;

    .line 14
    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static createInnertubeBody(LuTools/uStreamSpoofing/uClientType;)Ljava/lang/String;
    .locals 4
    .param p0, "clientType"    # LuTools/uStreamSpoofing/uClientType;

    .line 26
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0}, Lorg/json/JSONObject;-><init>()V

    .line 29
    .local v0, "innerTubeBody":Lorg/json/JSONObject;
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 30
    .local v1, "client":Lorg/json/JSONObject;
    const-string v2, "clientName"

    invoke-virtual {p0}, LuTools/uStreamSpoofing/uClientType;->name()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 31
    const-string v2, "clientVersion"

    iget-object v3, p0, LuTools/uStreamSpoofing/uClientType;->appVersion:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 32
    const-string v2, "deviceModel"

    iget-object v3, p0, LuTools/uStreamSpoofing/uClientType;->model:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 33
    const-string v2, "osVersion"

    iget-object v3, p0, LuTools/uStreamSpoofing/uClientType;->osVersion:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 34
    iget-object v2, p0, LuTools/uStreamSpoofing/uClientType;->androidSdkVersion:Ljava/lang/String;

    if-eqz v2, :cond_0

    .line 35
    const-string v2, "androidSdkVersion"

    iget-object v3, p0, LuTools/uStreamSpoofing/uClientType;->androidSdkVersion:Ljava/lang/String;

    invoke-virtual {v1, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 38
    :cond_0
    const-string v2, "context"

    new-instance v3, LuTools/uStreamSpoofing/uPlayerRoutes$1;

    invoke-direct {v3, v1}, LuTools/uStreamSpoofing/uPlayerRoutes$1;-><init>(Lorg/json/JSONObject;)V

    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 41
    const-string v2, "contentCheckOk"

    const/4 v3, 0x1

    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Z)Lorg/json/JSONObject;

    .line 42
    const-string v2, "racyCheckOk"

    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Z)Lorg/json/JSONObject;

    .line 43
    const-string v2, "videoId"

    const-string v3, "%s"

    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 44
    nop

    .end local v1    # "client":Lorg/json/JSONObject;
    goto :goto_0

    :catch_0
    move-exception v1

    .line 46
    :goto_0
    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    return-object v1
.end method

.method static getPlayerResponseConnectionFromRoute(LuTools/uStreamSpoofing/uRoute$CompiledRoute;LuTools/uStreamSpoofing/uClientType;)Ljava/net/HttpURLConnection;
    .locals 3
    .param p0, "route"    # LuTools/uStreamSpoofing/uRoute$CompiledRoute;
    .param p1, "clientType"    # LuTools/uStreamSpoofing/uClientType;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .line 51
    const-string v0, "https://youtubei.googleapis.com/youtubei/v1/"

    invoke-static {v0, p0}, LuTools/uStreamSpoofing/uRequester;->getConnectionFromCompiledRoute(Ljava/lang/String;LuTools/uStreamSpoofing/uRoute$CompiledRoute;)Ljava/net/HttpURLConnection;

    move-result-object v0

    .line 52
    .local v0, "connection":Ljava/net/HttpURLConnection;
    const-string v1, "Content-Type"

    const-string v2, "application/json"

    invoke-virtual {v0, v1, v2}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 53
    const-string v1, "User-Agent"

    iget-object v2, p1, LuTools/uStreamSpoofing/uClientType;->userAgent:Ljava/lang/String;

    invoke-virtual {v0, v1, v2}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 54
    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    .line 55
    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setDoOutput(Z)V

    .line 56
    const/16 v1, 0x2710

    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    .line 57
    invoke-virtual {v0, v1}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 59
    return-object v0
.end method
