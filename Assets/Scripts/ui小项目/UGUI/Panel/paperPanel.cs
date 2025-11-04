using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperPanel : basePanel
{
    public  readonly static string name = "PaperPanel";
    public readonly static string path = "PanelRes/PaperPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public paperPanel() : base(uIType)
    {
    }




    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
