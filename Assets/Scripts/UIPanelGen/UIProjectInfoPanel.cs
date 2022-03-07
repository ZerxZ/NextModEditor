/*
 * UIProjectInfoPanel
 * This code is generated by code. Do not modify it。
 */
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public partial class UIProjectInfoPanel : UIPanelBase
{
    public static string PanelName => "ProjectInfo";

    [NonSerialized]
    public TextMeshProUGUI txtCurProject;
    [NonSerialized]
    public ToggleGroup tglGrpProjectTabs;
    [NonSerialized]
    public ScrollRect lstTabs;
    [NonSerialized]
    public RectTransform goTabRoot;

    protected override void OnPreInit()
    {
        txtCurProject = FindBindComponent<TextMeshProUGUI>("g:txtCurProject");
        tglGrpProjectTabs = FindBindComponent<ToggleGroup>("g:tglGrpProjectTabs");
        lstTabs = FindBindComponent<ScrollRect>("g:lstTabs");
        goTabRoot = FindBindComponent<RectTransform>("g:goTabRoot");

    }
}