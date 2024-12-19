namespace uDrop.Code
{
    public class YouTube
    {
        public static List<bool> Debug()
        {
            return [
                new SmaliUtils.SubPatchModule<(string, int)[]>(
                    [
                        ("Landroid/view/MotionEvent;->getAction()I", 1),
                        (" onDoubleTap(", 2),
                        (" onDoubleTapEvent(", 2),
                        (" onClick(", 2),
                        (" onCreate(", 2),
                        (" onCreateLayout(", 2),
                        (" onItemClick(", 2),
                        (" onBackPressed(", 2),
                        (" getOnBackPressedDispatcher(", 2),
                        (" onTouch(", 2),
                        (" onTouchEvent(", 2)
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        for (int i = 3; i <= 4; i++)
                        {
                            if (new[] {
                                    xmlSmaliSearchKeys[i].Item1
                                }.All(xmlSmaliProperties.Full.Contains))
                            {
                                xmlSmaliProperties.ReadXMLSmaliLines();    

                                for (int j = 0; j < xmlSmaliProperties.LinesCount; j++)
                                {
                                    if (!xmlSmaliProperties.Lines[j].Contains("abstract") &&
                                        xmlSmaliProperties.Lines[j].Contains(xmlSmaliSearchKeys[i].Item1))
                                    {
                                        (int, string[]) patch = (
                                            j + xmlSmaliSearchKeys[i].Item2,

                                            [
                                                //invoke-static {}, LuTools/uDebug;->PrintMethod()V
                                                //invoke-static {}, LuTools/uDebug;->PrintStackTrace()V
                                                //invoke-static {v1}, LuTools/uDebug;->PrintStringWithMethod(Ljava/lang/String;)V
                                                //invoke-static {v1}, LuTools/uDebug;->PrintIntWithMethod(I)V
                                                //invoke-static {v1}, LuTools/uDebug;->PrintLongWithMethod(J)V
                                                //invoke-static {v1}, LuTools/uDebug;->PrintByteByfferWithMethod(Ljava/nio/ByteBuffer;)V
                                                //invoke-static {v1}, LuTools/uBlocker;->HideView(Landroid/view/View;)V

                                                "invoke-static {}, LuTools/uDebug;->PrintMethod()V"
                                            ]
                                        );

                                        codeInject.Lines(
                                            [
                                                (("", false),

                                                patch.Item1,

                                                patch.Item2)
                                            ]
                                        );

                                        j += patch.Item1.Equals(j) ? patch.Item2.Length + 1 : 0;
                                    }
                                }

                                codeInject.Write();

                                patchInteractions++;
                            }
                        }

                        if (patchInteractions > 0 && xmlSmaliProperties.Path.Equals(xmlSmaliProperties.LastOfPath))
                        {
                            return (0, false, xmlSmaliInfo);
                        }
                        else
                        {
                            return (patchInteractions, true, xmlSmaliInfo);
                        }
                    }
                ).Apply
            ];
        }

        public static List<bool> Debug_Patch()
        {
            return [
                
            ];
        }

        private static readonly SmaliUtils.StringTransform playServicesName =
            new("com.google", "", "app.revanced");
        private static readonly string uToolsRootFolder =
            "uTools";
        private static readonly string uBlockerPath =
            $"{uToolsRootFolder}/uBlocker";
        private static readonly string uUtilsPath =
            $"{uToolsRootFolder}/uUtils";
        private static readonly string uSpoofingPath =
            $"{uToolsRootFolder}/uStreamSpoofing/uSpoofing";

        public static List<bool> ADBlock_Prevents_History_Fix()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        ".method",
                        "compareTo",
                        "Landroid/net/Uri;->parse(Ljava/lang/String;)Landroid/net/Uri;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\TrackingUrlModel.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0],
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -12); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    string trackingUrlRegister = xmlSmaliProperties.Lines[k].GetRegister(1);

                                                    codeInject.Lines(
                                                        [
                                                            (("", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{trackingUrlRegister}}}, L{uBlockerPath};->OverrideTrackingUrl(Landroid/net/Uri;)Landroid/net/Uri;",
                                                                $"move-result-object {trackingUrlRegister}"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> ADS_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"TriggerBundle doesn\\'t have the required metadata specified by the trigger \"",
                        "\"Ping migration no associated ping bindings for activated trigger: \"",
                        "\"Tried to enter slot with no assigned slotAdapter\"",
                        "\"Trying to enter a slot when a slot of same type and physical position is already active. Its status: \"",
                        ".method",
                        "(Ljava/util/List;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4],
                                                xmlSmaliSearchKeys[5]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Video ADS", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "const-string",
                        "\"Android Automotive\"",
                        "if-"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0],
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -5); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Shorts ADS", true),

                                                    j,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x1"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Amoled_App_Color_Tint()
        {
            return [
                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new("<style name=\"Theme.YouTube.Launcher.Cairo\" parent=\"@style/Base.V23.Theme.YouTube.Launcher.Cairo.Dark\" />", "", "<style name=\"Theme.YouTube.Home\" parent=\"@style/Base.V23.Theme.YouTube.Launcher.Cairo.Dark\">\n    <item name=\"android:windowBackground\">@color/yt_black0</item>\n    </style>"),
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\values-night\\styles.xml"))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("Dynamic Splashscreen Color Fix", false),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();

                                return (patchInteractions, false, xmlSmaliInfo);
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"yt_black0\"",
                        "\"yt_black1\"",
                        "\"yt_black1_opacity95\"",
                        "\"yt_black1_opacity98\"",
                        "\"yt_black2\"",
                        "\"yt_black3\"",
                        "\"yt_black4\"",
                        "\"yt_status_bar_background_dark\"",
                        "\"material_grey_850\""
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\values\\colors.xml"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                for (int j = 0; j < xmlSmaliSearchKeys.Length; j++)
                                {
                                    if (new[] {
                                            xmlSmaliSearchKeys[j]
                                        }.All(xmlSmaliProperties.Lines[i].Contains))
                                    {
                                        codeInject.LinesReplace(
                                            [
                                                (("Global Colors Attributes", true),

                                                i,

                                                [
                                                    $"<color name={xmlSmaliSearchKeys[j]}>@android:color/black</color>"
                                                ])
                                            ]
                                        );
                                    }
                                }
                            }

                            codeInject.Write();

                            return (patchInteractions, false, xmlSmaliInfo);
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(16842919),
                        SmaliUtils.GetResourceHex(16843518),
                        " onBoundsChange(Landroid/graphics/Rect;)V",
                        "invoke-virtual {",
                        "Landroid/graphics/Paint;->setColor(I)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 444); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3],
                                                xmlSmaliSearchKeys[4]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Litho UI Colors", true),

                                                    j - 1,

                                                    [
                                                        $"invoke-static {{p1}}, L{uBlockerPath};->ChangeLithoUIColor(I)I",
                                                        "move-result p1"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "app_theme_appearance_system"),
                        SmaliUtils.GetResourceHex("string", "app_theme_appearance_light"),
                        SmaliUtils.GetResourceHex("string", "app_theme_appearance_dark"),
                        "return-object",
                        ".end method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            string[] patch = [
                                                $"invoke-static {{v0}}, L{uUtilsPath};->SetSystemTheme(Ljava/lang/Enum;)V"
                                            ];

                                            codeInject.Lines(
                                                [
                                                    (("System Theme Set", true),

                                                    j,

                                                    patch)
                                                ]
                                            ).Write();

                                            j += patch.Length + 1;
                                        }

                                        if (new[] {
                                                xmlSmaliSearchKeys[4]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "Landroid/view/ContextThemeWrapper;",
                        ".method",
                        "(Landroid/app/Activity;",
                        ";)Landroid/content/Context;",
                        "new-instance",
                        "const ",
                        ".end method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2],
                                        xmlSmaliSearchKeys[3]
                                    }.All(xmlSmaliProperties.Lines[i].Contains) &&
                                    xmlSmaliProperties.Lines[i].MethodParametersCount().Equals(2))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4],
                                                xmlSmaliSearchKeys[0]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k < xmlSmaliProperties.LinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[5]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    patchInteractions = patchInteractions.Equals(0) ? 1 : 0;

                                                    codeInject.Lines(
                                                        [
                                                            (("App Theme Set", true),

                                                            k + 1,

                                                            [
                                                                $"const/4 v1, 0x{patchInteractions}",
                                                                $"invoke-static {{v1}}, L{uUtilsPath};->SetAppTheme(Z)V"
                                                            ])
                                                        ]
                                                    ).Write();
                                                }

                                                if (new[] {
                                                        xmlSmaliSearchKeys[6]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "<background android:drawable=\"@mipmap/adaptiveproduct_youtube_2024_q4_background_color_108\" />"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\ringo2_ic_launcher.xml"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.LinesReplace(
                                        [
                                            (("Custom Launcher Icon", true),

                                            i,

                                            [""])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "<background android:drawable=\"@mipmap/adaptiveproduct_youtube_2024_q4_background_color_108\" />"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\ringo2_ic_launcher_round.xml"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.LinesReplace(
                                        [
                                            (("Custom Launcher Icon", true),

                                            i,

                                            [""])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Autoplay_Button_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "autonav_preview_stub"),
                        "invoke-virtual",
                        "(Landroid/view/ViewStub;I)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 18); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.LinesReplace(
                                                [
                                                    (("", true),

                                                    j,

                                                    [""])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "autonav_toggle"),
                        "invoke-virtual",
                        "(Landroid/view/ViewStub;I)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 18); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.LinesReplace(
                                                [
                                                    (("", true),

                                                    j,

                                                    [""])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "touch_area"),
                        ".method public constructor <init>",
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k < xmlSmaliProperties.LinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Countdown Disabler", true),

                                                            k,

                                                            [
                                                                $"invoke-static {{{xmlSmaliProperties.Lines[k].GetRegister(1)}}}, L{uBlockerPath};->DisableAutoPlayCountdown(Landroid/view/View;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Background_Video_Playback()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "audio_unavailable"),
                        "invoke-static",
                        ";)Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -114); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if ((xmlSmaliProperties.Lines[j].GetMethodName<string[]>() as string[])!
                                                    .All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    codeInject.NewLines(
                                                        [
                                                            (("App", true),

                                                            k + 2,

                                                            [
                                                                "const/4 v0, 0x1",
                                                                "return v0"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Failed to start foreground priority player Service due to Android S+ restrictions\"",
                        "\"About to stop background service while in a pending state.\"",
                        ".method public final declared-synchronized",
                        "invoke-direct",
                        "<init>",
                        "invoke-static",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 262); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 20); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5],
                                                                xmlSmaliSearchKeys[6]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[l].GetInvokedSectionClass(1));

                                                            for (int m = 0; m < xmlSmaliProperties.NewLinesCount; m++)
                                                            {
                                                                if ((xmlSmaliProperties.Lines[l].GetMethodName<string[]>() as string[])!
                                                                    .All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.NewLines(
                                                                        [
                                                                            (("App", true),

                                                                            m + 2,

                                                                            [
                                                                                "const/4 v0, 0x1",
                                                                                "return v0"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "Lcom/google/protos/youtube/api/innertube/MiniplayerRendererOuterClass;->miniplayerRenderer:",
                        "const/4",
                        SmaliUtils.GetResourceHex(0),
                        SmaliUtils.GetResourceHex(5),
                        SmaliUtils.GetResourceHex(2),
                        SmaliUtils.GetResourceHex(3),
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 33); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 8); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[1],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 20); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[1],
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = l; m >= 0; m--)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[6]
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    codeInject.Lines(
                                                                        [
                                                                            (("Miniplayer", true),

                                                                            m + 2,

                                                                            [
                                                                                "return-void"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(151635310),
                        ".method",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -26); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Shorts", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x1",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45415425),
                        ".method",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -9); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Shorts", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x1",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Bottom_Floating_Button_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"fab\"",
                        "\"pcc\""
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\MainActivity.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = i; k < j; k++)
                                            {
                                                codeInject.LinesReplace(
                                                    [
                                                        (("", true),

                                                        k,

                                                        [""])
                                                    ]
                                                );
                                            }

                                            codeInject.Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Context_Set()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        " onCreate("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\MainActivity.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("Main Activity", true),

                                            i + 2,

                                            [
                                                $"invoke-static/range {{p0 .. p0}}, L{uUtilsPath};->SetMainActivity(Landroid/app/Activity;)V"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"MultiDex\"",
                        "\"Failure while trying to obtain ApplicationInfo from Context. Must be running in test mode. Skip patching.\"",
                        " onCreate()"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("App", true),

                                            i + 2,

                                            [
                                                $"sput-object p0, L{uUtilsPath};->appContext:Landroid/content/Context;"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Crowdfunding_Box_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "donation_companion_modern_type"),
                        "invoke-virtual",
                        "Landroid/view/LayoutInflater;->inflate(ILandroid/view/ViewGroup;Z)Landroid/view/View;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 13); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{xmlSmaliProperties.Lines[k].GetRegister(1)}}}, L{uUtilsPath};->HideInstanceViewByLayoutParams(Landroid/view/View;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Double_Speed_Seek_Disabler()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("dimen", "seek_easy_horizontal_touch_offset_to_start_scrubbing"),
                        "invoke-virtual",
                        "Landroid/view/MotionEvent;->getAction()I",
                        "move-result ",
                        "const-wide/16"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < scaleIndex.Lines(i, 6); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k < scaleIndex.Lines(j, 4); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    string compareValueRegister = xmlSmaliProperties.Lines[k].GetRegister(1);

                                                    codeInject.Lines(
                                                        [
                                                            (("", true),

                                                            j + 1,

                                                            [
                                                                $"const/4 {compareValueRegister}, 0x2",
                                                                $"if-eq v2, {compareValueRegister}, :disable_double_speed_seek",
                                                                $"const/4 {compareValueRegister}, 0x0",
                                                                $"return {compareValueRegister}",
                                                                ":disable_double_speed_seek"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> End_Screen_Suggested_Videos_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "endscreen_element_layout_video"),
                        "check-cast",
                        "Landroid/widget/FrameLayout;"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 17); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "endscreen_element_layout_circle"),
                        "check-cast",
                        "Landroid/widget/FrameLayout;"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 17); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "endscreen_element_layout_icon"),
                        "check-cast",
                        "Landroid/widget/FrameLayout;"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 17); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("dimen", "app_related_end_screen_item_padding"),
                        "invoke-virtual",
                        "(IZI)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = xmlSmaliProperties.LinesCount - 1; i >= scaleIndex.Lines(i, -10); i--)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[i].GetInvokedSectionClass(1));

                                    for (int j = 0; j < xmlSmaliProperties.NewLinesCount; j++)
                                    {
                                        if ((xmlSmaliProperties.Lines[i].GetMethodName<string[]>() as string[])!
                                            .All(xmlSmaliProperties.NewLines[j].Contains))
                                        {
                                            codeInject.NewLines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z",
                        "Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;",
                        "Landroid/animation/ObjectAnimator;->ofObject(Ljava/lang/Object;Landroid/util/Property;Landroid/animation/TypeEvaluator;[Ljava/lang/Object;)Landroid/animation/ObjectAnimator;",
                        "Landroid/animation/Animator;->setInterpolator(Landroid/animation/TimeInterpolator;)V",
                        "Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3],
                                xmlSmaliSearchKeys[4]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[5]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Suggestions", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Forced_Captions_Disabler()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"get_watch\"",
                        "invoke-direct/range",
                        "<init>",
                        "invoke-static",
                        ")Z",
                        "\"psps\"",
                        ".method",
                        "(Ljava/lang/String;[BLjava/lang/String;Ljava/lang/String;II"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 17); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -25); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[k].GetInvokedSectionClass(1));

                                                    for (int l = 0; l < xmlSmaliProperties.NewLinesCount; l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            for (int m = l; m >= 0; m--)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[6],
                                                                        xmlSmaliSearchKeys[7],
                                                                    }.All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.NewLines(
                                                                        [
                                                                            (("", true),

                                                                            m + 2,

                                                                            [
                                                                                "move-object/from16 v0, p3",
                                                                                $"sput-object v0, L{uUtilsPath};->currentPlayerID:Ljava/lang/String;"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"pc\"",
                        ".method",
                        "(Lcom/google/android/libraries/youtube/innertube/model/player/PlayerResponseModel;Lcom/google/android/libraries/youtube/player/model/PlaybackStartDescriptor;"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        $"invoke-static {{}}, L{uUtilsPath};->CheckIsShortsPlayer()Z",
                                                        "move-result v0",
                                                        $"sput-boolean v0, L{uBlockerPath};->captionsButton:Z"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "accessibility_captions_unavailable"),
                        ".locals"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        "const/4 v0, 0x1",
                                                        $"sput-boolean v0, L{uBlockerPath};->captionsButton:Z"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"DISABLE_CAPTIONS_OPTION\"",
                        ".method",
                        "()Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\SubtitleTrack.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        $"sget-boolean v0, L{uBlockerPath};->captionsButton:Z",
                                                        "if-nez v0, :disable_forced_captions",
                                                        "const/4 v0, 0x1",
                                                        "return v0",
                                                        ":disable_forced_captions"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Horizontal_Shelf_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "setFillViewport(Z)V",
                        "setHorizontalScrollBarEnabled(Z)V",
                        "invoke-direct",
                        "<init>",
                        "Ljava/util/ArrayList;->indexOf(Ljava/lang/Object;)I",
                        "(IZ)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                            xmlSmaliSearchKeys[0],
                            xmlSmaliSearchKeys[1]
                        }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                    xmlSmaliSearchKeys[1]
                                }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 17); j++)
                                    {
                                        if (new[] {
                                            xmlSmaliSearchKeys[2],
                                            xmlSmaliSearchKeys[3]
                                        }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.NewLines(k, 9); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            codeInject.NewLines(
                                                                [
                                                                    (("", true),

                                                                    l,

                                                                    [
                                                                        $"sput {xmlSmaliProperties.NewLines[l].GetRegister(2)}, L{uBlockerPath};->currentNavBarIndex:I"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "mobile_topbar_button_item"),
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                            xmlSmaliSearchKeys[0]
                        }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                    xmlSmaliSearchKeys[1]
                                }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("", true),

                                            i + 2,

                                            [
                                                "const/4 v0, 0x0",
                                                $"sput v0, L{uBlockerPath};->currentNavBarIndex:I"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"com.google.android.libraries.youtube.rendering.presenter.PresentContext\"",
                        "\"FromTopBarMenu\"",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                            xmlSmaliSearchKeys[0],
                            xmlSmaliSearchKeys[1]
                        }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                    xmlSmaliSearchKeys[2]
                                }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("", true),

                                            i + 2,

                                            [
                                                "const/4 v0, 0x0",
                                                $"sput v0, L{uBlockerPath};->currentNavBarIndex:I"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        " onBackPressed("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\watchwhile\\MainActivity.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("", true),

                                            i + 2,

                                            [
                                                "const/4 v0, 0x0",
                                                $"sput v0, L{uBlockerPath};->currentNavBarIndex:I"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "Landroid/view/View;->setImportantForAccessibility(I)V",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\overlay\\YouTubePlayerOverlaysLayout.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        $"sput v0, L{uBlockerPath};->currentNavBarIndex:I"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Litho_Elements_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(17),
                        SmaliUtils.GetResourceHex(16),
                        SmaliUtils.GetResourceHex(15),
                        SmaliUtils.GetResourceHex(14),
                        SmaliUtils.GetResourceHex(13),
                        SmaliUtils.GetResourceHex(12),
                        SmaliUtils.GetResourceHex(11),
                        SmaliUtils.GetResourceHex(10),
                        SmaliUtils.GetResourceHex(9),
                        SmaliUtils.GetResourceHex(8),
                        SmaliUtils.GetResourceHex(7),
                        SmaliUtils.GetResourceHex(6),
                        SmaliUtils.GetResourceHex(5),
                        SmaliUtils.GetResourceHex(4),
                        SmaliUtils.GetResourceHex(3),
                        SmaliUtils.GetResourceHex(2),
                        SmaliUtils.GetResourceHex(1),
                        SmaliUtils.GetResourceHex(0),
                        ".method public final",
                        "(ILjava/nio/ByteBuffer;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3],
                                xmlSmaliSearchKeys[4],
                                xmlSmaliSearchKeys[5],
                                xmlSmaliSearchKeys[6],
                                xmlSmaliSearchKeys[7],
                                xmlSmaliSearchKeys[8],
                                xmlSmaliSearchKeys[9],
                                xmlSmaliSearchKeys[10],
                                xmlSmaliSearchKeys[11],
                                xmlSmaliSearchKeys[12],
                                xmlSmaliSearchKeys[13],
                                xmlSmaliSearchKeys[14],
                                xmlSmaliSearchKeys[15],
                                xmlSmaliSearchKeys[16],
                                xmlSmaliSearchKeys[17]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[18],
                                        xmlSmaliSearchKeys[19]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("Litho ProtoBuffer", true),

                                            i + 2,

                                            [
                                                $"sput-object p2, L{uBlockerPath};->protoBufferComponents:Ljava/nio/ByteBuffer;"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"ScrollableContainerType\"",
                        "\"Failed to parse Element proto.\"",
                        ".method",
                        "const-string",
                        "\"|\"",
                        "iput-object",
                        ":Ljava/lang/StringBuilder;",
                        "\"Element missing type extension\"",
                        "invoke-static/range",
                        "iget-object",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[9]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k < xmlSmaliProperties.LinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3],
                                                        xmlSmaliSearchKeys[4],
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 202); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5],
                                                                xmlSmaliSearchKeys[6]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = l; m < xmlSmaliProperties.LinesCount; m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[7]
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    for (int n = m; n <= scaleIndex.Lines(m, 32); n++)
                                                                    {
                                                                        if (new[] {
                                                                                xmlSmaliSearchKeys[8]
                                                                            }.All(xmlSmaliProperties.Lines[n].Contains))
                                                                        {
                                                                            for (int o = n; o <= scaleIndex.Lines(n, 8); o++)
                                                                            {
                                                                                if (new[] {
                                                                                        xmlSmaliSearchKeys[9]
                                                                                    }.All(xmlSmaliProperties.Lines[o].Contains))
                                                                                {
                                                                                    for (int p = m; p >= scaleIndex.Lines(m, -12); p--)
                                                                                    {
                                                                                        if (new[] {
                                                                                                xmlSmaliSearchKeys[10]
                                                                                            }.All(xmlSmaliProperties.Lines[p].Contains))
                                                                                        {
                                                                                            string throwExceptionRegister = xmlSmaliProperties.Lines[m].GetRegister(1);
                                                                                            string stringBuilderFirstRegister = xmlSmaliProperties.Lines[l].GetRegister(1);
                                                                                            string stringBuilderSecondRegister = xmlSmaliProperties.Lines[l].GetRegister(2);

                                                                                            codeInject.Lines(
                                                                                                [
                                                                                                    (("Litho Tree", true),

                                                                                                    p + 1,

                                                                                                    [
                                                                                                        $"if-nez {xmlSmaliProperties.Lines[p].GetRegister(1)}, :litho_tree",
                                                                                                        $"move-object/from16 {throwExceptionRegister}, p1",
                                                                                                        $"invoke-static {{{throwExceptionRegister}}}, {xmlSmaliProperties.Lines[n].GetInvokedSection()}",
                                                                                                        $"move-result-object {throwExceptionRegister}",
                                                                                                        $"iget-object {throwExceptionRegister}, {throwExceptionRegister}, {xmlSmaliProperties.Lines[o].GetInvokedSection()}",
                                                                                                        $"return-object {throwExceptionRegister}",
                                                                                                        ":litho_tree"
                                                                                                    ]),
                                                                                                        
                                                                                                    (("Litho Component", true),

                                                                                                    l + 1,

                                                                                                    [
                                                                                                        $"invoke-static {{{stringBuilderFirstRegister}}}, L{uBlockerPath};->HideLithoTemplate(Ljava/lang/StringBuilder;)Z",
                                                                                                        $"move-result {stringBuilderFirstRegister}",
                                                                                                        $"if-eqz {stringBuilderFirstRegister}, :litho_component",
                                                                                                        $"const/4 {stringBuilderSecondRegister}, 0x0",
                                                                                                        $"return-object {stringBuilderSecondRegister}",
                                                                                                        ":litho_component"
                                                                                                    ])
                                                                                                ]
                                                                                            ).Write();

                                                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45419603),
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 14); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Litho Obfuscation Disabler", true),

                                                    j + 1,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45631264),
                        ".method public final",
                        "()Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -29); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Litho Obfuscation Disabler", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "canScrollVertically",
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\SwipeRefreshLayout.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 6); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Swipe To Refresh Fix", true),

                                                    j + 1,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"scroll_position\"",
                        SmaliUtils.GetResourceHex("id", "elements_item_touch_helper"),
                        ".method protected",
                        "()V",
                        "const/4",
                        "0x3",
                        "Landroid/support/v7/widget/RecyclerView;->"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(str => xmlSmaliProperties.Full.ReferenceEntriesCount(str, 2)))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = xmlSmaliProperties.LinesCount - 1; i >= 0; i--)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2],
                                        xmlSmaliSearchKeys[3]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 13); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4],
                                                xmlSmaliSearchKeys[5]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 20); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[6]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Back To Exit Fix", true),

                                                            k + 1,

                                                            [
                                                                "const/4 v1, 0x0",
                                                                $"sput-boolean v1, L{uBlockerPath};->isTopView:Z"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "browse_fragment_tabs"),
                        "new-instance",
                        "}, Landroid/support/v7/widget/RecyclerView;->",
                        ":cond_"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(j, 86); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.NewLines(l, 5); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[3]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            codeInject.NewLines(
                                                                [
                                                                    (("Back To Exit Fix", true),

                                                                    l + 1,

                                                                    [
                                                                        "const/4 v2, 0x1",
                                                                        $"sput-boolean v2, L{uBlockerPath};->isTopView:Z"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        " onBackPressed()V",
                        "return-void"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\watchwhile\\MainActivity.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 32); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Back To Exit Fix", true),

                                                    j,

                                                    [
                                                        $"invoke-static {{p0}}, L{uBlockerPath};->CloseActivityOnBackPressed(Lcom/google/android/apps/youtube/app/watchwhile/MainActivity;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Live_Chat_Elements_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "live_chat_modern_poll"),
                        "Landroid/view/ViewStub;->inflate()Landroid/view/View;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 11); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Poll Window", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{xmlSmaliProperties.Lines[k].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "live_chat_picker_toggle_button_tag"),
                        SmaliUtils.GetResourceHex("id", "action_pills"),
                        ".method private static",
                        ";)Z",
                        ".method",
                        "invoke-virtual",
                        "Landroid/view/View;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= 0; k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[0]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l >= 0; l--)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = l; m <= scaleIndex.Lines(l, 30); m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[5],
                                                                        xmlSmaliSearchKeys[6]
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    for (int n = m; n <= scaleIndex.Lines(m, 6); n++)
                                                                    {
                                                                        if (new[] {
                                                                                xmlSmaliSearchKeys[7]
                                                                            }.All(xmlSmaliProperties.Lines[n].Contains))
                                                                        {
                                                                            codeInject.Lines(
                                                                                [
                                                                                    (("Donate And Comment Button", true),

                                                                                    j + 2,

                                                                                    [
                                                                                        "const/4 v0, 0x1",
                                                                                        "return v0"
                                                                                    ]),

                                                                                    (("Donate And Comment Button", true),

                                                                                    n + 1,

                                                                                    [
                                                                                        $"invoke-static {{{xmlSmaliProperties.Lines[n].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                                                    ])
                                                                                ]
                                                                            ).Write();

                                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "thumbnail_and_emoji_picker_container"),
                        "return-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 23); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Comment Box Emoji Panel Button", true),

                                                    j,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "component_long_click_listener"),
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V",
                        "invoke-direct",
                        "<init>",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -74); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -6); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2],
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[k].GetInvokedSectionClass(1));

                                                    for (int l = 0; l < xmlSmaliProperties.NewLinesCount; l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            codeInject.NewLines(
                                                                [
                                                                    (("Subscribers Shelf", true),

                                                                    l + 2,

                                                                    [
                                                                        "const/4 v0, 0x0",
                                                                        $"sput v0, L{uBlockerPath};->liveChatSubscribersShelf:I"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,


                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "live_chat_ticker_item"),
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 171); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Subscribers Shelf", true),

                                                    j,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uBlockerPath};->HideLiveChatSubscribersShelf(Landroid/view/View;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "component_long_click_listener"),
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V",
                        "invoke-direct",
                        "<init>",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -74); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -6); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2],
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[k].GetInvokedSectionClass(1));

                                                    for (int l = 0; l < xmlSmaliProperties.NewLinesCount; l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            codeInject.NewLines(
                                                                [
                                                                    (("Community Rules Box", true),

                                                                    l + 2,

                                                                    [
                                                                        "const/4 v0, 0x0",
                                                                        $"sput v0, L{uBlockerPath};->liveChatCommunityRulesBox:I"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,


                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45364140),
                        "\"anchor_view\"",
                        "Landroid/view/View;->setClickable(Z)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("Community Rules Box", true),

                                            i + 1,

                                            [
                                                $"invoke-static {{{xmlSmaliProperties.Lines[i].GetRegister(1)}}}, L{uBlockerPath};->HideLiveChatCommunityRulesBox(Landroid/view/View;)V",
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "engagement_panel_title_header"),
                        "Lcom/google/protos/youtube/api/innertube/FilterChipBarElementRendererOuterClass$FilterChipBarElementRenderer;",
                        "Landroid/widget/ImageView;->setImageResource(I)V",
                        SmaliUtils.GetResourceHex("drawable", "yt_outline_scissors_black_24")
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("Create Clip Button", true),

                                            i + 1,

                                            [
                                                $"const v0, {xmlSmaliSearchKeys[3]}",
                                                $"if-ne {xmlSmaliProperties.Lines[i].GetRegister(2)}, v0, :hide_create_clip_button",
                                                $"invoke-static {{{xmlSmaliProperties.Lines[i].GetRegister(1)}}}, L{uUtilsPath};->HideImageView(Landroid/widget/ImageView;)V",
                                                ":hide_create_clip_button"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Load_More_Videos_Button_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "expand_button_down"),
                        "Landroid/view/View;->inflate",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 9); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{xmlSmaliProperties.Lines[k].GetRegister(1)}}}, L{uUtilsPath};->HideInstanceViewByLayoutParams(Landroid/view/View;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Non_Root_Conversion()
        {
            return [
                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new($"\"{playServicesName.Original}\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.c2dm.intent.RECEIVE\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.c2dm.intent.REGISTER\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.c2dm.intent.REGISTRATION\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.c2dm.permission.RECEIVE\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.c2dm.permission.SEND\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.accountsettings.action.VIEW_SETTINGS\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.auth.account.authapi.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.auth.accounts\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.auth.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.cast.firstparty.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.cast.service.BIND_CAST_DEVICE_CONTROLLER_SERVICE\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.clearcut.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.common.telemetry.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.droidguard.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.feedback.internal.IFeedbackService\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.fonts\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.gass.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.gmscompliance.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.googlehelp.HELP\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.googlehelp.service.GoogleHelpService.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.icing.LIGHTWEIGHT_INDEX_SERVICE\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.languageprofile.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.measurement.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.people.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.phenotype\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.phenotype.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.potokens.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.pseudonymous.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.signin.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.usagereporting.service.START\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gms.wallet.service.BIND\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gsf.action.GET_GLS\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"content://{playServicesName.Original}.android.gms.phenotype/\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"content://{playServicesName.Original}.android.gsf.gservices\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"content://{playServicesName.Original}.android.gsf.gservices/prefix\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.gsf.login\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.android.providers.gsf.permission.READ_GSERVICES\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"{playServicesName.Original}.iid.TOKEN_REQUEST\"", playServicesName.Original, playServicesName.Transformed),
                        new($"\"content://{playServicesName.Original}.settings/partner\"", playServicesName.Original, playServicesName.Transformed),
                        new($"android:name=\"{playServicesName.Original}.android.youtube.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION\"", playServicesName.Original, Main_Class.apkInfo.Item3.ToLower()),
                        new($"android:name=\"{playServicesName.Original}.android.youtube.permission.C2D_MESSAGE\"", playServicesName.Original, Main_Class.apkInfo.Item3.ToLower()),
                        new($"android:authorities=\"{playServicesName.Original}.android.youtube", playServicesName.Original, Main_Class.apkInfo.Item3.ToLower()),
                        new($"\"{playServicesName.Original}.android.c2dm", playServicesName.Original, Main_Class.apkInfo.Item3.ToLower())
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (!xmlSmaliProperties.Path.Contains(uToolsRootFolder) &&
                            (xmlSmaliProperties.Path.EndsWith(".smali") ||
                            xmlSmaliProperties.Path.EndsWith("\\AndroidManifest.xml")))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("Stock To MicroG Classes Rename", false),

                                        -1,

                                        [""])
                                    ],
                                    
                                    xmlSmaliSearchKeys
                                ).Write();

                                patchInteractions++;
                            }
                        }

                        if (patchInteractions > 0 && xmlSmaliProperties.Path.Equals(xmlSmaliProperties.LastOfPath))
                        {
                            return (0, false, xmlSmaliInfo);
                        }
                        else
                        {
                            return (patchInteractions, true, xmlSmaliInfo);
                        }
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new($"package=\"{playServicesName.Original}.android.youtube", playServicesName.Original, Main_Class.apkInfo.Item3.ToLower())
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\AndroidManifest.xml"))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("App Package Rename", false),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();

                                return (patchInteractions, false, xmlSmaliInfo);
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new("android:label=\"@string/application_name\"", "@string/application_name", Main_Class.apkInfo.Item3)
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\AndroidManifest.xml"))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("App Label Rename", false),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();
                            }

                            return (patchInteractions, false, xmlSmaliInfo);
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "</manifest>",
                        "</application>"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\AndroidManifest.xml"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -3); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("MicroG Binding Signature", true),
                                                
                                                    j,

                                                    [
                                                        $"<meta-data android:name=\"{playServicesName.Transformed}.android.gms.SPOOFED_PACKAGE_NAME\" android:value=\"{playServicesName.Original}.android.youtube\"/>",
                                                        $"<meta-data android:name=\"{playServicesName.Transformed}.android.gms.SPOOFED_PACKAGE_SIGNATURE\" android:value=\"24bb24c05e47e0aefa68a58a766179d9b613a600\"/>",
                                                        $"<meta-data android:name=\"{playServicesName.Transformed}.MICROG_PACKAGE_NAME\" android:value=\"{playServicesName.Transformed}.android.gms\"/>"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new("</queries>", "", $"<package android:name=\"{playServicesName.Transformed}.android.gms\"/>\n            </queries>")
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\AndroidManifest.xml"))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("MicroG Binding Signature", false),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();

                                return (patchInteractions, false, xmlSmaliInfo);
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        " onCreate("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\MainActivity.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("MicroG Package Detection Check", true),

                                            i + 2,

                                            [
                                                $"invoke-static/range {{p0 .. p0}}, L{uBlockerPath};->CheckMicroGPackage(Landroid/app/Activity;)V"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Primes instant initialization\"",
                        "Ljava/lang/Object;-><init>()V",
                        ".method",
                        ")V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Primes Initialization Disabler", true),

                                                    j + 1,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            );

                                            for (int k = j; k < xmlSmaliProperties.LinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2],
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Primes Initialization Disabler", true),

                                                            k + 2,

                                                            [
                                                                "return-void"
                                                            ])
                                                        ]
                                                    );
                                                }

                                                if (k.Equals(xmlSmaliProperties.LinesCount - 1))
                                                {
                                                    codeInject.Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Primes did not observe lifecycle events in the expected order. %s is not initializing in Application#onCreate\"",
                        "if-"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 18); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Primes Lifecycle Disabler", true),

                                                    j - 1,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x1"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Primes init triggered from background in package: %s\"",
                        "if-"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 18); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Primes Background Disabler", true),

                                                    j - 1,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x1"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"a.\"",
                        "\"advertisingid\"",
                        "invoke-virtual",
                        "()V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 33); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if ((xmlSmaliProperties.Lines[j].GetMethodName<string[]>() as string[])!
                                                    .All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    codeInject.NewLines(
                                                        [
                                                            (("Get Advertising ID Disabler", true),

                                                            k + 2,

                                                            [
                                                                "return-void"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Cannot initialize SslGuardSocketFactory will null\"",
                        "\"Failed to install SslGuard with top priority.\"",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("SSL Guard Disabler", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"The Google Play services resources were not found. Check your project configuration to ensure that the resources are included.\"",
                        ".locals"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Google Signature Check Disabler", true),

                                                    j,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"GooglePlayServices not available due to error \"",
                        ".locals"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Google Signature Check Disabler", true),

                                                    j,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new("</PreferenceScreen>", "</PreferenceScreen>", $"<PreferenceCategory android:persistent=\"false\" android:layout=\"@layout/preference_group_title\" android:title=\"uTube\" android:key=\"microg_group_key\" app:iconSpaceReserved=\"false\">\n        <Preference android:icon=\"@drawable/microg_settings_key_icon\" android:title=\"MicroG\"> <intent android:targetPackage=\"{playServicesName.Transformed}.android.gms\" android:targetClass=\"org.microg.gms.ui.SettingsActivity\"/> </Preference>\n        </PreferenceCategory>\n        </PreferenceScreen>")
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\settings_fragment_cairo.xml"))
                        {
                            if (xmlSmaliSearchKeys.Any(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("MicroG Settings Button", true),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();

                                return (patchInteractions, false, xmlSmaliInfo);
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,


                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Error fetching CastContext.\"",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Cast Service Disabler", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"com.google.android.gms.cast.framework.internal.CastDynamiteModuleImpl\"",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Cast Service Disabler", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return-object v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Failed to load module via V2: \"",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Cast Service V2 Disabler", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        ".method",
                        "setVisibility(I)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\MediaRouteButton.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (xmlSmaliSearchKeys
                                        .All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    codeInject.Lines(
                                        [
                                            (("Cast Button Removal", true),

                                            i + 2,

                                            [
                                                "const/16 p1, 0x8"
                                            ])
                                        ]
                                    ).Write();

                                    return (patchInteractions, false, xmlSmaliInfo);
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"(Linux; U; Android \"",
                        "invoke-virtual",
                        "Landroid/content/Context;->getPackageName()Ljava/lang/String;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -28); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("App Package Spoof", true),

                                                            k + 1,

                                                            [
                                                                $"const-string {xmlSmaliProperties.Lines[k].GetRegister(1)}, \"com.google.android.youtube\""
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"youtubei/v1\"",
                        "\"key\"",
                        "\"asig\"",
                        "Landroid/net/Uri$Builder;->build()Landroid/net/Uri;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 189); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    string buildURIRegister = xmlSmaliProperties.Lines[k].GetRegister(1);

                                                    codeInject.Lines(
                                                        [
                                                            (("Playback Stream Spoof", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{buildURIRegister}}}, L{uSpoofingPath};->blockGetWatchRequest(Landroid/net/Uri;)Landroid/net/Uri;",
                                                                $"move-result-object {buildURIRegister}"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"media3.datasource.cronet\"",
                        "\"Range\"",
                        ".method protected",
                        "Lorg/chromium/net/UrlRequest$Builder;",
                        "invoke-virtual",
                        "Landroid/net/Uri;->toString()Ljava/lang/String;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[2],
                                        xmlSmaliSearchKeys[3]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 9); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4],
                                                xmlSmaliSearchKeys[5],
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[6]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    string toStringURIRegister = xmlSmaliProperties.Lines[k].GetRegister(1);

                                                    codeInject.Lines(
                                                        [
                                                            (("Playback Stream Spoof", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{toStringURIRegister}}}, L{uSpoofingPath};->blockInitPlaybackRequest(Ljava/lang/String;)Ljava/lang/String;",
                                                                $"move-result-object {toStringURIRegister}"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "setRequestFinishedListener(",
                        ".method public static",
                        ")Lorg/chromium/net/UrlRequest;",
                        "invoke-virtual",
                        "Lorg/chromium/net/CronetEngine;->newUrlRequestBuilder",
                        "new-instance"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 48); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3],
                                                xmlSmaliSearchKeys[4]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -10); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[5]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    string buildRequestFirstRegister = xmlSmaliProperties.Lines[j].GetRegister(2);
                                                    string buildRequestSecondRegister = xmlSmaliProperties.Lines[j].GetRegister(3);

                                                    codeInject.Lines(
                                                        [
                                                            (("Playback Stream Spoof", true),

                                                            k,

                                                            [
                                                                $"move-object {buildRequestSecondRegister}, p1",
                                                                $"invoke-static {{{buildRequestFirstRegister}, {buildRequestSecondRegister}}}, L{uSpoofingPath};->fetchStreams(Ljava/lang/String;Ljava/util/Map;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Invalid playback type; streaming data is not playable\"",
                        ".method public constructor <init>",
                        "const/4",
                        "iget-object",
                        "iput-object",
                        "iget-object",
                        "iput-object",
                        ".field public",
                        ":Ljava/lang/String;",
                        "-$$Nest$smcheckIsLite",
                        ".end method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 15); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 9); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 11); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = l; m <= scaleIndex.Lines(l, 3); m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[5]
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    for (int n = m; n <= scaleIndex.Lines(m, 9); n++)
                                                                    {
                                                                        if (new[] {
                                                                                xmlSmaliSearchKeys[6]
                                                                            }.All(xmlSmaliProperties.Lines[n].Contains))
                                                                        {
                                                                            string firstClassName = xmlSmaliProperties.Lines[m].GetInvokedSectionClass(2);
                                                                            xmlSmaliProperties.ReadXMLSmaliNewLines(firstClassName);
                                                                            string firstFieldName = "";
                                                                            for (int o = 0; o < xmlSmaliProperties.NewLinesCount; o++)
                                                                            {
                                                                                if (new[] {
                                                                                        xmlSmaliSearchKeys[7],
                                                                                        xmlSmaliSearchKeys[8]
                                                                                    }.All(xmlSmaliProperties.NewLines[o].Contains))
                                                                                {
                                                                                    firstFieldName = xmlSmaliProperties.NewLines[o].Split(' ', ':')[2];

                                                                                    break;
                                                                                }
                                                                            }

                                                                            string secondClassName = xmlSmaliProperties.Lines[m].GetInvokedSectionClass(1);
                                                                            xmlSmaliProperties.ReadXMLSmaliNewLines(secondClassName);
                                                                            string secondFieldName = "";
                                                                            for (int o = 0; o < xmlSmaliProperties.NewLinesCount; o++)
                                                                            {
                                                                                if (new[] {
                                                                                        xmlSmaliSearchKeys[7],
                                                                                        $"L{secondClassName};"
                                                                                    }.All(xmlSmaliProperties.NewLines[o].Contains))
                                                                                {
                                                                                    secondFieldName = xmlSmaliProperties.NewLines[o].Split(' ', ':')[4];

                                                                                    break;
                                                                                }
                                                                            }

                                                                            if (!new[] {
                                                                                    firstFieldName,
                                                                                    secondFieldName
                                                                                }.Any(string.IsNullOrEmpty))
                                                                            {
                                                                                codeInject.Lines(
                                                                                    [
                                                                                        (("Playback Stream Spoof", true),

                                                                                        n + 1,

                                                                                        [
                                                                                            $"invoke-direct {{{xmlSmaliProperties.Lines[n].GetRegister(2)}, {xmlSmaliProperties.Lines[n].GetRegister(1)}}}, L{xmlSmaliProperties.Lines[l].GetInvokedSectionClass(1)};->{Main_Class.apkInfo.Item3}_SetStreamingData(L{firstClassName};)V"
                                                                                        ])
                                                                                    ]
                                                                                );

                                                                                for (int o = n; o <= scaleIndex.Lines(n, 45); o++)
                                                                                {
                                                                                    if (new[] {
                                                                                            xmlSmaliSearchKeys[9]
                                                                                        }.All(xmlSmaliProperties.Lines[o].Contains))
                                                                                    {
                                                                                        for (int p = o; p < xmlSmaliProperties.LinesCount; p++)
                                                                                        {
                                                                                            if (new[] {
                                                                                                    xmlSmaliSearchKeys[10]
                                                                                                }.All(xmlSmaliProperties.Lines[p].Contains))
                                                                                            {
                                                                                                string thirdClassName = xmlSmaliProperties.Lines[o].GetInvokedSectionClass(1);

                                                                                                codeInject.Lines(
                                                                                                    [
                                                                                                        (("Playback Stream Spoof", true),

                                                                                                        p + 1,

                                                                                                        [
                                                                                                            $".method private final {Main_Class.apkInfo.Item3}_SetStreamingData(L{firstClassName};)V",
                                                                                                            ".locals 2",
                                                                                                            ".param p1, \"videoDetails\"",
                                                                                                            $"iget-object v0, p1, L{firstClassName};->{firstFieldName}:Ljava/lang/String;",
                                                                                                            "if-eqz v0, :override_streaming_data",
                                                                                                            $"invoke-static {{v0}}, L{uSpoofingPath};->getStreamingData(Ljava/lang/String;)Ljava/nio/ByteBuffer;",
                                                                                                            "move-result-object v0",
                                                                                                            "if-eqz v0, :override_streaming_data",
                                                                                                            $"sget-object v1, L{secondClassName};->{secondFieldName}:L{secondClassName};",
                                                                                                            $"invoke-static {{v1, v0}}, L{thirdClassName};->parseFrom(L{thirdClassName};Ljava/nio/ByteBuffer;)L{thirdClassName};",
                                                                                                            "move-result-object v0",
                                                                                                            $"check-cast v0, L{secondClassName};",
                                                                                                            $"iget-object v1, v0, {xmlSmaliProperties.Lines[k].GetInvokedSection()}",
                                                                                                            "if-eqz v1, :override_streaming_data",
                                                                                                            $"iput-object v1, p0, {xmlSmaliProperties.Lines[l].GetInvokedSection()}",
                                                                                                            ":override_streaming_data",
                                                                                                            "return-void",
                                                                                                            ".end method"
                                                                                                        ])
                                                                                                    ]
                                                                                                ).Write();

                                                                                                return (patchInteractions, false, xmlSmaliInfo);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"HEAD\"",
                        "\"POST\"",
                        "\"GET\"",
                        "\"media3.datasource\"",
                        ".method public constructor <init>(Landroid/net/Uri;JI[BLjava/util/Map;JJLjava/lang/String;ILjava/lang/Object;)V",
                        "Lj$/util/DesugarCollections;->unmodifiableMap(Ljava/util/Map;)Ljava/util/Map;",
                        "iput-object",
                        "[B",
                        "iput ",
                        ":I",
                        "iput-object",
                        "Landroid/net/Uri;",
                        ".end method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[4]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 116); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[5]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -10); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[6],
                                                        xmlSmaliSearchKeys[7]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l >= scaleIndex.Lines(k, -18); l--)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[8],
                                                                xmlSmaliSearchKeys[9]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = l; m >= scaleIndex.Lines(l, -7); m--)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[10],
                                                                        xmlSmaliSearchKeys[11]
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    for (int n = m; n <= xmlSmaliProperties.LinesCount; n++)
                                                                    {
                                                                        if (new[] {
                                                                                xmlSmaliSearchKeys[12]
                                                                            }.All(xmlSmaliProperties.Lines[n].Contains))
                                                                        {
                                                                            string byteArrayInvokedSection = xmlSmaliProperties.Lines[k].GetInvokedSection();

                                                                            codeInject.Lines(
                                                                                [
                                                                                    (("Playback Stream Spoof", true),

                                                                                    n - 2,

                                                                                    [
                                                                                        "move-object v0, p0",
                                                                                        $"iget-object v1, v0, {xmlSmaliProperties.Lines[m].GetInvokedSection()}",
                                                                                        $"iget v2, v0, {xmlSmaliProperties.Lines[l].GetInvokedSection()}",
                                                                                        $"iget-object v3, v0, {byteArrayInvokedSection}",
                                                                                        $"invoke-static {{v1, v2, v3}}, L{uSpoofingPath};->removeVideoPlaybackPostBody(Landroid/net/Uri;I[B)[B",
                                                                                        "move-result-object v1",
                                                                                        $"iput-object v1, v0, {byteArrayInvokedSection}"
                                                                                    ])
                                                                                ]
                                                                            ).Write();

                                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45355374),
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 11); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Live Stream Start From Beginning Fix", true),

                                                    j + 1,

                                                    [
                                                        $"const/4 {xmlSmaliProperties.Lines[j].GetRegister(1)}, 0x0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Premium_Elements_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<SmaliUtils.StringTransform[]>(
                    [
                        new("<Preference android:persistent=\"false\" android:layout=\"@layout/preference_with_icon\" android:key=\"@string/subscription_product_setting_key\" android:fragment=\"placeholder\" />", "", ""),
                        new("<Preference android:persistent=\"false\" android:layout=\"@layout/preference_with_icon\" android:key=\"@string/billing_and_payment_key\" android:fragment=\"com.google.android.apps.youtube.app.settings.BillingsAndPaymentsPrefsFragment\" app:iconSpaceReserved=\"true\" />", "", ""),
                        new("<Preference android:persistent=\"false\" android:layout=\"@layout/preference_with_icon\" android:key=\"@string/premium_early_access_browse_page_key\" android:fragment=\"placeholder\" android:iconSpaceReserved=\"true\" />", "", "")
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\settings_fragment_cairo.xml"))
                        {
                            if (xmlSmaliSearchKeys.All(st => xmlSmaliProperties.Full.Contains(st.Original)))
                            {
                                codeInject.FullReplace(
                                    [
                                        (("Experimental Features/Subscriptions/Payments Buttons", true),

                                        -1,

                                        [""])
                                    ],

                                    xmlSmaliSearchKeys
                                ).Write();

                                return (patchInteractions, false, xmlSmaliInfo);
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        " onMeasure(II)V",
                        "return-void",
                        "invoke-virtual"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (xmlSmaliProperties.Path.EndsWith("\\CompactYpcOfferModuleView.smali"))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -6); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Original Video Production Box", true),

                                                            k,

                                                            [
                                                                $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(2)}, 0x0",
                                                                $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(3)}, 0x0"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"c.supportedViewport\"",
                        "\"player.exception\"",
                        "\"vprng\"",
                        ".method",
                        "(Ljava/util/List;Ljava/util/Collection;Ljava/lang/String;L",
                        ")[Lcom/google/android/libraries/youtube/innertube/model/media/VideoQuality;",
                        "Lcom/google/android/libraries/youtube/innertube/model/media/FormatStreamModel;->",
                        "()Ljava/lang/String;",
                        "move-result-object",
                        "Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;",
                        "if-"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[3],
                                        xmlSmaliSearchKeys[4],
                                        xmlSmaliSearchKeys[5]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 389); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[6],
                                                xmlSmaliSearchKeys[7]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            if (patchInteractions.Equals(1)) {
                                                for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                                {
                                                    if (new[] {
                                                            xmlSmaliSearchKeys[8]
                                                        }.All(xmlSmaliProperties.Lines[k].Contains))
                                                    {
                                                        for (int l = k; l <= scaleIndex.Lines(k, 31); l++)
                                                        {
                                                            if (new[] {
                                                                    xmlSmaliSearchKeys[9]
                                                                }.All(xmlSmaliProperties.Lines[l].Contains))
                                                            {
                                                                for (int m = l; m >= scaleIndex.Lines(l, -6); m--)
                                                                {
                                                                    if (new[] {
                                                                            xmlSmaliSearchKeys[10]
                                                                        }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                    {
                                                                        string ifCondRegister = xmlSmaliProperties.Lines[m].GetRegister(1);
                                                                        string videoResolutionItemRegister = xmlSmaliProperties.Lines[k].GetRegister(1);

                                                                        codeInject.Lines(
                                                                            [
                                                                                (("High Bitrate Resolution", true),

                                                                                l + 1,

                                                                                [
                                                                                    ":hide_high_bitrate_resolution"
                                                                                ]),

                                                                                (("High Bitrate Resolution", true),

                                                                                l,

                                                                                [
                                                                                    $"invoke-static {{{videoResolutionItemRegister}}}, L{uBlockerPath};->HideHighBitrateResolution(Ljava/lang/String;)Z",
                                                                                    $"move-result {ifCondRegister}",
                                                                                    $"if-nez {ifCondRegister}, :hide_high_bitrate_resolution"
                                                                                ])
                                                                            ]
                                                                        ).Write();

                                                                        return (0, false, xmlSmaliInfo);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            patchInteractions = 1;
                                        }
                                    }
                                }
                            }
                        }

                        return (0, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Error casting %s\"",
                        "\"SafeLayoutParams\"",
                        ".method public static",
                        "(Ljava/lang/Class;Landroid/view/ViewGroup$LayoutParams;)Landroid/view/ViewGroup$LayoutParams;",
                        "(Landroid/view/View;II)V",
                        "HideViewGroupByMarginLayout",
                        ".param"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= 0; k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    xmlSmaliProperties.ReadXMLSmaliNewLines(uUtilsPath);

                                                    for (int l = 0; l < xmlSmaliProperties.NewLinesCount; l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[2],
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            for (int m = l; m < scaleIndex.NewLines(l, 3); m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[6]
                                                                    }.All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.NewLines(
                                                                        [
                                                                            (("My Tab Get Premium Button", true),

                                                                            m + 1,

                                                                            [
                                                                                $"const/4 v0, 0x0",
                                                                                $"invoke-static {{p0, v0, v0}}, L{Path.GetFileNameWithoutExtension(xmlSmaliProperties.Path)};->{(xmlSmaliProperties.Lines[k].GetMethodName<string>() as string)}(Landroid/view/View;II)V"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "compact_link"),
                        "and-int",
                        "0x800",
                        "invoke-static",
                        "(Landroid/widget/TextView;Ljava/lang/CharSequence;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1],
                                        xmlSmaliSearchKeys[2]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -10); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3],
                                                xmlSmaliSearchKeys[4]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("My Tab Get Premium Button", true),

                                                    j + 1,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}, {xmlSmaliProperties.Lines[j].GetRegister(2)}}}, L{uBlockerPath};->HideTabMyAccountGetPremium(Landroid/view/View;Ljava/lang/CharSequence;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Object is not an offlineable video: \"",
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Video Download Button", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "live_chat_item_context_menu_item"),
                        "invoke-static",
                        ";)Ljava/lang/CharSequence;",
                        "and-int",
                        SmaliUtils.GetResourceHex(8),
                        "return-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 22); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if ((xmlSmaliProperties.Lines[j].GetMethodName<string[]>() as string[])!
                                                    .All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.NewLines(k, 296); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[3],
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            for (int m = l; m >= scaleIndex.NewLines(l, -5); m--)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[5]
                                                                    }.All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.NewLines(
                                                                        [
                                                                            (("Next In Queue Button", true),

                                                                            m,

                                                                            [
                                                                                $"const/4 {xmlSmaliProperties.NewLines[m].GetRegister(1)}, 0x0"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Shorts_Player_Bypasser()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"com.google.android.apps.youtube.PlaybackStartDescriptor\"",
                        "\"com.google.android.apps.youtube.ReelWatchActivityIntentCreator.CSI_START_BASELINE_KEY\"",
                        "\"com.google.android.apps.youtube.ReelWatchActivityIntentCreator.LOAD_TYPE_KEY\"",
                        "\"com.google.android.apps.youtube.ReelWatchActivityIntentCreator.IS_REFERRED_FROM_DISCOVER_KEY\"",
                        ".method",
                        "\"PlaybackStartDescriptor:\\n  VideoId:%s\\n  PlaylistId:%s\\n  Index:%d\\n  VideoIds:%s\"",
                        "invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;",
                        "invoke-virtual",
                        "()Ljava/lang/String;"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines("\\com\\google\\android\\libraries\\youtube\\player\\model\\PlaybackStartDescriptor");

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[5]
                                                    }.All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    for (int l = k; l >= scaleIndex.NewLines(k, -97); l--)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[6]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            for (int m = l; m <= scaleIndex.NewLines(l, 9); m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[7],
                                                                        xmlSmaliSearchKeys[8]
                                                                    }.All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.Lines(
                                                                        [
                                                                            (("", true),

                                                                            j + 2,

                                                                            [
                                                                                "move-object/from16 v0, p1",
                                                                                $"invoke-virtual {{v0}}, Lcom/google/android/libraries/youtube/player/model/PlaybackStartDescriptor;->{xmlSmaliProperties.NewLines[m].GetMethodName<string>() as string}()Ljava/lang/String;",
                                                                                "move-result-object v0",
                                                                                $"invoke-static {{v0}}, L{uBlockerPath};->ShortsPlayerBypassing(Ljava/lang/String;)Z",
                                                                                "move-result v0",
                                                                                "if-eqz v0, :shorts_player_bypassing",
                                                                                "return-void",
                                                                                ":shorts_player_bypassing"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Shorts_Elements_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Null topBarButtons\"",
                        ".method public constructor <init>",
                        "iput-boolean"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 7); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Player Toolbar", true),

                                                            k,

                                                            [
                                                                $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(1)}, 0x0"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "reel_player_badge2"),
                        "and-int/lit16",
                        "if-nez"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -8); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -10); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Could Contains Promo Banner", true),

                                                            k,

                                                            [
                                                                $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(1)}, 0x0"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45401636),
                        ".method",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -9); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Startup Player Disabler", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Failed to read user_was_in_shorts proto after successful warmup\"",
                        "invoke-interface",
                        "Lcom/google/common/util/concurrent/ListenableFuture;->isDone()Z",
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -52); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Startup Player Disabler", true),

                                                    j,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "Landroid/view/Display;->getSize(Landroid/graphics/Point;)V",
                        "\"window\"",
                        "\"accessibility\"",
                        "Landroid/view/MotionEvent;->getAction()I",
                        "add-int/lit8",
                        "-0x1",
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2],
                                xmlSmaliSearchKeys[3]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[3]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 416); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[4],
                                                xmlSmaliSearchKeys[5]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -4); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[6]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Double Tap To Like", true),

                                                            k + 1,

                                                            [
                                                                $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(1)}, 0x0"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,
                
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "reels_edu_swipe_text_view"),
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Swipe To Next Suggestion", true),

                                                    j + 2,

                                                    [
                                                        "return-void"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Start_Video_Panel_Disabler()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"Failed to start foreground priority player Service due to Android S+ restrictions\"",
                        "\"About to stop background service while in a pending state.\"",
                        ".method public final declared-synchronized",
                        "invoke-direct",
                        "<init>",
                        "invoke-static",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j < xmlSmaliProperties.LinesCount; j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 262); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 20); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5],
                                                                xmlSmaliSearchKeys[6]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[l].GetInvokedSectionClass(1));

                                                            for (int m = 0; m < xmlSmaliProperties.NewLinesCount; m++)
                                                            {
                                                                if ((xmlSmaliProperties.Lines[l].GetMethodName<string[]>() as string[])!
                                                                    .All(xmlSmaliProperties.NewLines[m].Contains))
                                                                {
                                                                    codeInject.NewLines(
                                                                        [
                                                                            (("", true),

                                                                            m + 2,

                                                                            [
                                                                                $"invoke-static {{}}, L{uUtilsPath};->CheckIsShortsPlayer()Z",
                                                                                "move-result v0",
                                                                                "if-nez v0, :hide_engagement_panel",
                                                                                "const/4 v0, 0x0",
                                                                                $"sput-boolean v0, L{uBlockerPath};->initVideoPanel:Z",
                                                                                ":hide_engagement_panel"
                                                                            ])
                                                                        ]
                                                                    ).Write();

                                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("id", "component_long_click_listener"),
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V",
                        "invoke-direct",
                        "<init>",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -74); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -6); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[2],
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[k].GetInvokedSectionClass(1));

                                                    for (int l = 0; l < xmlSmaliProperties.NewLinesCount; l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[4]
                                                            }.All(xmlSmaliProperties.NewLines[l].Contains))
                                                        {
                                                            codeInject.NewLines(
                                                                [
                                                                    (("", true),

                                                                    l + 2,

                                                                    [
                                                                        "const/4 v0, 0x1",
                                                                        $"sput-boolean v0, L{uBlockerPath};->initVideoPanel:Z"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"engagement-panel-playlist\"",
                        ".method",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x1",
                                                        $"sput-boolean v0, L{uBlockerPath};->initVideoPanel:Z"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "offline_actions_video_deleted_undo_snackbar_text"),
                        "invoke-direct",
                        "<init>",
                        " onClick("
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -6); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            xmlSmaliProperties.ReadXMLSmaliNewLines(xmlSmaliProperties.Lines[j].GetInvokedSectionClass(1));

                                            for (int k = 0; k < xmlSmaliProperties.NewLinesCount; k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.NewLines[k].Contains))
                                                {
                                                    codeInject.NewLines(
                                                        [
                                                            (("", true),

                                                            k + 2,

                                                            [
                                                                "const/4 v0, 0x1",
                                                                $"sput-boolean v0, L{uBlockerPath};->initVideoPanel:Z"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"EngagementPanelController: cannot show EngagementPanel before EngagementPanelController.init() has been called.\"",
                        ".locals"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        $"sget-boolean v0, L{uBlockerPath};->initVideoPanel:Z",
                                                        "if-nez v0, :hide_engagement_panel",
                                                        "const/4 v0, 0x0",
                                                        "return-object v0",
                                                        ":hide_engagement_panel"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Top_And_Navigation_Bars_Buttons_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "mobile_topbar_button_item"),
                        SmaliUtils.GetResourceHex("drawable", "yt_outline_new_search_black_24"),
                        "invoke-static {",
                        "(I)",
                        "move-result-object",
                        "setOnClickListener(Landroid/view/View$OnClickListener;)V"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -46); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = i; l <= scaleIndex.Lines(i, 70); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            codeInject.Lines(
                                                                [
                                                                    (("Top Bar", true),

                                                                    l + 1,

                                                                    [
                                                                        $"invoke-static {{{xmlSmaliProperties.Lines[l].GetRegister(1)}}}, L{uBlockerPath};->HideTopbarButtons(Landroid/view/View;)V"
                                                                    ]),

                                                                    (("Top Bar", true),

                                                                    k + 1,

                                                                    [
                                                                        $"sput-object {xmlSmaliProperties.Lines[k].GetRegister(1)}, L{uBlockerPath};->topBarPivot:Ljava/lang/Enum;"
                                                                    ])
                                                                ]
                                                            ).Write();

                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(318370164),
                        SmaliUtils.GetResourceHex(16843518),
                        "and-int",
                        "invoke-static",
                        "(I)L",
                        "move-result-object",
                        "invoke-virtual/range {",
                        "/pivotbar/PivotBar;->",
                        ")Landroid/view/View;",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -153); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k >= scaleIndex.Lines(j, -30); k--)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3],
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    for (int l = k; l <= scaleIndex.Lines(k, 6); l++)
                                                    {
                                                        if (new[] {
                                                                xmlSmaliSearchKeys[5]
                                                            }.All(xmlSmaliProperties.Lines[l].Contains))
                                                        {
                                                            for (int m = i; m <= scaleIndex.Lines(i, 86); m++)
                                                            {
                                                                if (new[] {
                                                                        xmlSmaliSearchKeys[6],
                                                                        xmlSmaliSearchKeys[7],
                                                                        xmlSmaliSearchKeys[8],
                                                                    }.All(xmlSmaliProperties.Lines[m].Contains))
                                                                {
                                                                    for (int n = m; n <= scaleIndex.Lines(m, 6); n++)
                                                                    {
                                                                        if (new[] {
                                                                                xmlSmaliSearchKeys[9]
                                                                            }.All(xmlSmaliProperties.Lines[n].Contains))
                                                                        {
                                                                            codeInject.Lines(
                                                                                [
                                                                                    (("Navigation Bar", true),

                                                                                    n + 1,

                                                                                    [
                                                                                        $"invoke-static {{{xmlSmaliProperties.Lines[n].GetRegister(1)}}}, L{uBlockerPath};->HideNavigationbarButtons(Landroid/view/View;)V"
                                                                                    ]),

                                                                                    (("Navigation Bar", true),

                                                                                    l + 1,

                                                                                    [
                                                                                        $"sput-object {xmlSmaliProperties.Lines[l].GetRegister(1)}, L{uBlockerPath};->navigationBarPivot:Ljava/lang/Enum;"
                                                                                    ])
                                                                                ]
                                                                            ).Write();

                                                                            return (patchInteractions, false, xmlSmaliInfo);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("layout", "image_only_tab"),
                        "invoke-virtual {",
                        "/pivotbar/PivotBar;->",
                        ")Landroid/view/View",
                        "move-result-object"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 57); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 6); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[4]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("Navigation Bar Create Button", true),

                                                            k + 1,

                                                            [
                                                                $"invoke-static {{{xmlSmaliProperties.Lines[k].GetRegister(1)}}}, L{uUtilsPath};->HideView(Landroid/view/View;)V"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }

        public static List<bool> Video_Qualities_Fast_Access()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex(45400072),
                        ".method",
                        ")Z"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -9); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("Newer Quality Layout Enabler", true),

                                                    j + 2,

                                                    [
                                                        "const/4 v0, 0x0",
                                                        "return v0"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        "\"LithoRVSLCBinder\"",
                        ".method public constructor <init>",
                        "move-object/from16",
                        ", p2",
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[1]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j <= scaleIndex.Lines(i, 12); j++)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[2],
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 1,

                                                    [
                                                        $"invoke-static {{{xmlSmaliProperties.Lines[j].GetRegister(1)}}}, L{uBlockerPath};->OpenVideoResolutionsFlyout(Landroid/support/v7/widget/RecyclerView;)V"
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply,

                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "quality_ds_res"),
                        "invoke-virtual {",
                        ";->ordinal()I",
                        "move-result "
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= scaleIndex.Lines(i, -35); j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[1],
                                                xmlSmaliSearchKeys[2]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            for (int k = j; k <= scaleIndex.Lines(j, 5); k++)
                                            {
                                                if (new[] {
                                                        xmlSmaliSearchKeys[3]
                                                    }.All(xmlSmaliProperties.Lines[k].Contains))
                                                {
                                                    codeInject.Lines(
                                                        [
                                                            (("", true),

                                                            k + 1,

                                                            [
                                                               $"const/4 {xmlSmaliProperties.Lines[k].GetRegister(1)}, 0x3"
                                                            ])
                                                        ]
                                                    ).Write();

                                                    return (patchInteractions, false, xmlSmaliInfo);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }
        
        public static List<bool> Video_SearchBar_Removal()
        {
            return [
                new SmaliUtils.SubPatchModule<string[]>(
                    [
                        SmaliUtils.GetResourceHex("string", "see_more_proceeding_header"),
                        SmaliUtils.GetResourceHex("string", "p13n_header"),
                        SmaliUtils.GetResourceHex("dimen", "suggestion_category_divider_height"),
                        ".method"
                    ],

                    true,

                    (
                        xmlSmaliProperties,
                        xmlSmaliSearchKeys,
                        scaleIndex,
                        codeInject,
                        patchInteractions,
                        xmlSmaliInfo
                    ) => {
                        if (new[] {
                                xmlSmaliSearchKeys[0],
                                xmlSmaliSearchKeys[1],
                                xmlSmaliSearchKeys[2]
                            }.All(xmlSmaliProperties.Full.Contains))
                        {
                            xmlSmaliProperties.ReadXMLSmaliLines();

                            for (int i = 0; i < xmlSmaliProperties.LinesCount; i++)
                            {
                                if (new[] {
                                        xmlSmaliSearchKeys[0]
                                    }.All(xmlSmaliProperties.Lines[i].Contains))
                                {
                                    for (int j = i; j >= 0; j--)
                                    {
                                        if (new[] {
                                                xmlSmaliSearchKeys[3]
                                            }.All(xmlSmaliProperties.Lines[j].Contains))
                                        {
                                            codeInject.Lines(
                                                [
                                                    (("", true),

                                                    j + 2,

                                                    [
                                                        $"move-object/from16 v0, p2",
                                                        "invoke-static {v0}, LuTools/uBlocker;->HideVideoSearchBarSuggestions(Ljava/lang/String;)Z",
                                                        "move-result v0",
                                                        "if-eqz v0, :hide_video_searchbar_suggestions",
                                                        "return-void",
                                                        ":hide_video_searchbar_suggestions",
                                                    ])
                                                ]
                                            ).Write();

                                            return (patchInteractions, false, xmlSmaliInfo);
                                        }
                                    }
                                }
                            }
                        }

                        return (patchInteractions, true, xmlSmaliInfo);
                    }
                ).Apply
            ];
        }
    }
}