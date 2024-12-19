.class public LuTools/uStreamSpoofing/uRequester;
.super Ljava/lang/Object;
.source "uRequester.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getConnectionFromCompiledRoute(Ljava/lang/String;LuTools/uStreamSpoofing/uRoute$CompiledRoute;)Ljava/net/HttpURLConnection;
    .locals 9
    .param p0, "apiUrl"    # Ljava/lang/String;
    .param p1, "route"    # LuTools/uStreamSpoofing/uRoute$CompiledRoute;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .line 11
    nop

    .line 15
    invoke-virtual {p1}, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->getCompiledRoute()Ljava/lang/String;

    move-result-object v0

    filled-new-array {p0, v0}, [Ljava/lang/Object;

    move-result-object v0

    .line 11
    const-string v1, "%s%s"

    invoke-static {v1, v0}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 17
    .local v0, "url":Ljava/lang/String;
    new-instance v1, Ljava/net/URL;

    invoke-direct {v1, v0}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v1

    check-cast v1, Ljava/net/HttpURLConnection;

    .line 18
    .local v1, "connection":Ljava/net/HttpURLConnection;
    invoke-virtual {p1}, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->getMethod()LuTools/uStreamSpoofing/uRoute$Method;

    move-result-object v2

    invoke-virtual {v2}, LuTools/uStreamSpoofing/uRoute$Method;->name()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 19
    nop

    .line 22
    const-string v2, "http.agent"

    invoke-static {v2}, Ljava/lang/System;->getProperty(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 24
    invoke-static {}, LuTools/uStreamSpoofing/uSpoofingUtils;->getAppVersionName()Ljava/lang/String;

    move-result-object v5

    .line 26
    invoke-static {}, LuTools/uStreamSpoofing/uSpoofingUtils;->getAppVersionName()Ljava/lang/String;

    move-result-object v7

    const-string v8, ")"

    const-string v4, "; uTube/"

    const-string v6, " ("

    filled-new-array/range {v3 .. v8}, [Ljava/lang/Object;

    move-result-object v2

    .line 19
    const-string v3, "%s%s%s%s%s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 29
    .local v2, "agentString":Ljava/lang/String;
    const-string v3, "User-Agent"

    invoke-virtual {v1, v3, v2}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 31
    return-object v1
.end method
