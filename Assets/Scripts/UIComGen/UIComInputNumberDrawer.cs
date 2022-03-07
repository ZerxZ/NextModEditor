/*
 * UIComInputNumberDrawer
 * This code is generated by code. Do not modify it。
 */
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VirtualList;

public partial class UIComInputNumberDrawer : UIComBase
{
    public static string ComName => "inputNumberDrawer";

    [NonSerialized]
    public TextMeshProUGUI txtTitle;
    [NonSerialized]
    public TMP_InputField inMain;
    [NonSerialized]
    public RectTransform imgWarning;

    protected override void OnPreInit()
    {
        txtTitle = FindBindComponent<TextMeshProUGUI>("g:txtTitle");
        inMain = FindBindComponent<TMP_InputField>("g:inMain");
        imgWarning = FindBindComponent<RectTransform>("g:imgWarning");

    }
}