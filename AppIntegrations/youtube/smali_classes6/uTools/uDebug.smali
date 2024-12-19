.class public LuTools/uDebug;
.super Ljava/lang/Object;
.source "uDebug.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 11
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static GetViewParentID(Landroid/view/View;)V
    .locals 3
    .param p0, "value"    # Landroid/view/View;

    .line 249
    invoke-virtual {p0}, Landroid/view/View;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    .line 250
    .local v0, "parent":Ljava/lang/Object;
    const-string v1, "uView"

    if-eqz v0, :cond_0

    .line 251
    move-object v2, v0

    check-cast v2, Landroid/view/View;

    invoke-virtual {v2}, Landroid/view/View;->getId()I

    move-result v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 253
    :cond_0
    const/4 v2, 0x0

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 255
    :goto_0
    return-void
.end method

.method public static GetViewParentName(Landroid/view/View;)V
    .locals 3
    .param p0, "value"    # Landroid/view/View;

    .line 258
    invoke-virtual {p0}, Landroid/view/View;->getParent()Landroid/view/ViewParent;

    move-result-object v0

    .line 259
    .local v0, "parent":Landroid/view/ViewParent;
    const-string v1, "uView"

    if-eqz v0, :cond_0

    .line 260
    invoke-interface {v0}, Landroid/view/ViewParent;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 262
    :cond_0
    const-string v2, "-- null --"

    invoke-static {v1, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 264
    :goto_0
    return-void
.end method

.method public static PrintBooleanWithMethod(Z)V
    .locals 4
    .param p0, "value"    # Z

    .line 13
    const-string v0, "uBoolean"

    .line 15
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 16
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 17
    aget-object v2, v1, v3

    .line 23
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 20
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 17
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 29
    :cond_0
    invoke-static {p0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 30
    return-void
.end method

.method public static PrintByteArrayWithMethod([B)V
    .locals 8
    .param p0, "value"    # [B

    .line 33
    const-string v0, "uByteArray"

    .line 35
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 36
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 37
    aget-object v2, v1, v3

    .line 43
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 40
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 37
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 49
    :cond_0
    array-length v2, p0

    mul-int/lit8 v2, v2, 0x2

    new-array v2, v2, [C

    .line 50
    .local v2, "hexChars":[C
    const-string v3, "0123456789ABCDEF"

    invoke-virtual {v3}, Ljava/lang/String;->toCharArray()[C

    move-result-object v3

    .line 51
    .local v3, "hexArray":[C
    const/4 v4, 0x0

    .local v4, "j":I
    :goto_0
    array-length v5, p0

    if-ge v4, v5, :cond_1

    .line 52
    aget-byte v5, p0, v4

    and-int/lit16 v5, v5, 0xff

    .line 53
    .local v5, "v":I
    mul-int/lit8 v6, v4, 0x2

    ushr-int/lit8 v7, v5, 0x4

    aget-char v7, v3, v7

    aput-char v7, v2, v6

    .line 54
    mul-int/lit8 v6, v4, 0x2

    add-int/lit8 v6, v6, 0x1

    and-int/lit8 v7, v5, 0xf

    aget-char v7, v3, v7

    aput-char v7, v2, v6

    .line 51
    .end local v5    # "v":I
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 57
    .end local v4    # "j":I
    :cond_1
    invoke-static {v2}, Ljava/util/Arrays;->toString([C)Ljava/lang/String;

    move-result-object v4

    invoke-static {v0, v4}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 58
    return-void
.end method

.method public static PrintByteBufferWithMethod(Ljava/nio/ByteBuffer;)V
    .locals 6
    .param p0, "value"    # Ljava/nio/ByteBuffer;

    .line 61
    const-string v0, "uByteBuffer"

    .line 63
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 64
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 65
    aget-object v2, v1, v3

    .line 71
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 68
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 65
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 77
    :cond_0
    const-string v2, "-- null --"

    if-eqz p0, :cond_2

    .line 78
    new-instance v3, Ljava/lang/String;

    invoke-virtual {p0}, Ljava/nio/ByteBuffer;->array()[B

    move-result-object v4

    sget-object v5, Ljava/nio/charset/StandardCharsets;->UTF_8:Ljava/nio/charset/Charset;

    invoke-direct {v3, v4, v5}, Ljava/lang/String;-><init>([BLjava/nio/charset/Charset;)V

    .line 79
    .local v3, "valueToString":Ljava/lang/String;
    invoke-virtual {v3}, Ljava/lang/String;->isEmpty()Z

    move-result v4

    if-eqz v4, :cond_1

    .line 80
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 82
    :cond_1
    invoke-static {v0, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 84
    .end local v3    # "valueToString":Ljava/lang/String;
    :goto_0
    goto :goto_1

    .line 85
    :cond_2
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 88
    :goto_1
    return-void
.end method

.method public static PrintDoubleWithMethod(D)V
    .locals 4
    .param p0, "value"    # D

    .line 91
    const-string v0, "uDouble"

    .line 93
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 94
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 95
    aget-object v2, v1, v3

    .line 101
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 98
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 95
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 107
    :cond_0
    invoke-static {p0, p1}, Ljava/lang/String;->valueOf(D)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 108
    return-void
.end method

.method public static PrintFloatWithMethod(F)V
    .locals 4
    .param p0, "value"    # F

    .line 111
    const-string v0, "uFloat"

    .line 113
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 114
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 115
    aget-object v2, v1, v3

    .line 121
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 118
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 115
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 127
    :cond_0
    invoke-static {p0}, Ljava/lang/String;->valueOf(F)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 128
    return-void
.end method

.method public static PrintIntWithMethod(I)V
    .locals 4
    .param p0, "value"    # I

    .line 131
    const-string v0, "uInt"

    .line 133
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 134
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 135
    aget-object v2, v1, v3

    .line 141
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 138
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 135
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 147
    :cond_0
    invoke-static {p0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 148
    return-void
.end method

.method public static PrintLongWithMethod(J)V
    .locals 4
    .param p0, "value"    # J

    .line 151
    const-string v0, "uLong"

    .line 153
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 154
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 155
    aget-object v2, v1, v3

    .line 161
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 158
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 155
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 167
    :cond_0
    invoke-static {p0, p1}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 168
    return-void
.end method

.method public static PrintMethod()V
    .locals 3

    .line 219
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v0

    .line 220
    .local v0, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v1, v0

    const/4 v2, 0x3

    if-le v1, v2, :cond_0

    .line 221
    aget-object v1, v0, v2

    .line 227
    invoke-virtual {v1}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "\n"

    filled-new-array {v1, v2}, [Ljava/lang/Object;

    move-result-object v1

    .line 224
    const-string v2, "Called from method: %s%s"

    invoke-static {v2, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    .line 221
    const-string v2, "uMethod"

    invoke-static {v2, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 232
    :cond_0
    return-void
.end method

.method public static PrintStackTrace()V
    .locals 8

    .line 235
    const-string v0, "uStack"

    .line 237
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 238
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x0

    :goto_0
    if-ge v3, v2, :cond_0

    aget-object v4, v1, v3

    .line 239
    .local v4, "stackTraceElement":Ljava/lang/StackTraceElement;
    sget-object v5, Ljava/lang/System;->out:Ljava/io/PrintStream;

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Class name :: "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    .line 241
    invoke-virtual {v4}, Ljava/lang/StackTraceElement;->getClassName()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, "  || method name :: "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    .line 243
    invoke-virtual {v4}, Ljava/lang/StackTraceElement;->getMethodName()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    .line 239
    invoke-virtual {v5, v6}, Ljava/io/PrintStream;->println(Ljava/lang/String;)V

    .line 238
    .end local v4    # "stackTraceElement":Ljava/lang/StackTraceElement;
    add-int/lit8 v3, v3, 0x1

    goto :goto_0

    .line 246
    :cond_0
    return-void
.end method

.method public static PrintStringBuilderWithMethod(Ljava/lang/StringBuilder;)V
    .locals 4
    .param p0, "value"    # Ljava/lang/StringBuilder;

    .line 195
    const-string v0, "uStringBuilder"

    .line 197
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 198
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 199
    aget-object v2, v1, v3

    .line 205
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 202
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 199
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 211
    :cond_0
    if-eqz p0, :cond_1

    invoke-virtual {p0}, Ljava/lang/StringBuilder;->capacity()I

    move-result v2

    if-lez v2, :cond_1

    .line 212
    invoke-virtual {p0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 214
    :cond_1
    const-string v2, "-- null --"

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 216
    :goto_0
    return-void
.end method

.method public static PrintStringWithMethod(Ljava/lang/String;)V
    .locals 4
    .param p0, "value"    # Ljava/lang/String;

    .line 171
    const-string v0, "uString"

    .line 173
    .local v0, "message":Ljava/lang/String;
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v1

    .line 174
    .local v1, "stackTraceElements":[Ljava/lang/StackTraceElement;
    array-length v2, v1

    const/4 v3, 0x3

    if-le v2, v3, :cond_0

    .line 175
    aget-object v2, v1, v3

    .line 181
    invoke-virtual {v2}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v2

    const-string v3, "\n"

    filled-new-array {v2, v3}, [Ljava/lang/Object;

    move-result-object v2

    .line 178
    const-string v3, "Called from method: %s%s"

    invoke-static {v3, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    .line 175
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 187
    :cond_0
    if-eqz p0, :cond_1

    invoke-virtual {p0}, Ljava/lang/String;->isEmpty()Z

    move-result v2

    if-nez v2, :cond_1

    .line 188
    invoke-static {v0, p0}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 190
    :cond_1
    const-string v2, "-- null --"

    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 192
    :goto_0
    return-void
.end method
