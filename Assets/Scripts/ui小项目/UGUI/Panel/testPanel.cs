using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//仅是随手测试用
public class testPanel : basePanel
{
    public readonly static string name = "TestPanel";
    public readonly static string path = "PanelRes/TestPanel";
    public static readonly UIType uIType = new UIType(name, path);
    // Start is called before the first frame update
    public testPanel() : base(uIType)
    {

    }

    public override void OnDestory()
    {
        base.OnDestory();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
