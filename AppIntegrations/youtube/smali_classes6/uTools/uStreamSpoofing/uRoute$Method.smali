.class public final enum LuTools/uStreamSpoofing/uRoute$Method;
.super Ljava/lang/Enum;
.source "uRoute.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = LuTools/uStreamSpoofing/uRoute;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Method"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "LuTools/uStreamSpoofing/uRoute$Method;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[LuTools/uStreamSpoofing/uRoute$Method;

.field public static final enum POST:LuTools/uStreamSpoofing/uRoute$Method;


# direct methods
.method private static synthetic $values()[LuTools/uStreamSpoofing/uRoute$Method;
    .locals 1

    .line 68
    sget-object v0, LuTools/uStreamSpoofing/uRoute$Method;->POST:LuTools/uStreamSpoofing/uRoute$Method;

    filled-new-array {v0}, [LuTools/uStreamSpoofing/uRoute$Method;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 69
    new-instance v0, LuTools/uStreamSpoofing/uRoute$Method;

    const-string v1, "POST"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, LuTools/uStreamSpoofing/uRoute$Method;-><init>(Ljava/lang/String;I)V

    sput-object v0, LuTools/uStreamSpoofing/uRoute$Method;->POST:LuTools/uStreamSpoofing/uRoute$Method;

    .line 68
    invoke-static {}, LuTools/uStreamSpoofing/uRoute$Method;->$values()[LuTools/uStreamSpoofing/uRoute$Method;

    move-result-object v0

    sput-object v0, LuTools/uStreamSpoofing/uRoute$Method;->$VALUES:[LuTools/uStreamSpoofing/uRoute$Method;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/MethodParameters;
        accessFlags = {
            0x1000,
            0x1000
        }
        names = {
            null,
            null
        }
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 68
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)LuTools/uStreamSpoofing/uRoute$Method;
    .locals 1
    .param p0, "name"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/MethodParameters;
        accessFlags = {
            0x8000
        }
        names = {
            null
        }
    .end annotation

    .line 68
    const-class v0, LuTools/uStreamSpoofing/uRoute$Method;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, LuTools/uStreamSpoofing/uRoute$Method;

    return-object v0
.end method

.method public static values()[LuTools/uStreamSpoofing/uRoute$Method;
    .locals 1

    .line 68
    sget-object v0, LuTools/uStreamSpoofing/uRoute$Method;->$VALUES:[LuTools/uStreamSpoofing/uRoute$Method;

    invoke-virtual {v0}, [LuTools/uStreamSpoofing/uRoute$Method;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [LuTools/uStreamSpoofing/uRoute$Method;

    return-object v0
.end method
