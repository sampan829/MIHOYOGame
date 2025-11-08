using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPanel : basePanel
{
    private static readonly string name = "NumPanel";
    private static readonly string path = "PanelRes/NumPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public NumPanel() : base(uIType)
    {
    }

    // Start is called before the first frame update
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
