.class public LuTools/uStreamSpoofing/uRoute$CompiledRoute;
.super Ljava/lang/Object;
.source "uRoute.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = LuTools/uStreamSpoofing/uRoute;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "CompiledRoute"
.end annotation


# instance fields
.field private final baseRoute:LuTools/uStreamSpoofing/uRoute;

.field private final compiledRoute:Ljava/lang/String;


# direct methods
.method private constructor <init>(LuTools/uStreamSpoofing/uRoute;Ljava/lang/String;)V
    .locals 0
    .param p1, "baseRoute"    # LuTools/uStreamSpoofing/uRoute;
    .param p2, "compiledRoute"    # Ljava/lang/String;

    .line 44
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 45
    iput-object p1, p0, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->baseRoute:LuTools/uStreamSpoofing/uRoute;

    .line 46
    iput-object p2, p0, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->compiledRoute:Ljava/lang/String;

    .line 47
    return-void
.end method

.method synthetic constructor <init>(LuTools/uStreamSpoofing/uRoute;Ljava/lang/String;LuTools/uStreamSpoofing/uRoute-IA;)V
    .locals 0

    invoke-direct {p0, p1, p2}, LuTools/uStreamSpoofing/uRoute$CompiledRoute;-><init>(LuTools/uStreamSpoofing/uRoute;Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public getCompiledRoute()Ljava/lang/String;
    .locals 1

    .line 50
    iget-object v0, p0, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->compiledRoute:Ljava/lang/String;

    return-object v0
.end method

.method public getMethod()LuTools/uStreamSpoofing/uRoute$Method;
    .locals 1

    .line 54
    iget-object v0, p0, LuTools/uStreamSpoofing/uRoute$CompiledRoute;->baseRoute:LuTools/uStreamSpoofing/uRoute;

    invoke-static {v0}, LuTools/uStreamSpoofing/uRoute;->-$$Nest$fgetmethod(LuTools/uStreamSpoofing/uRoute;)LuTools/uStreamSpoofing/uRoute$Method;

    move-result-object v0

    return-object v0
.end method
