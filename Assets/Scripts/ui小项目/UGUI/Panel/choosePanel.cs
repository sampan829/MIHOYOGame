using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosePanel :basePanel
{
    private static string name = "ChoosePanel";
    private static string path = "PanelRes/ChoosePanel";
    public static readonly UIType uIType = new UIType(name, path);
    public choosePanel() : base(uIType)
    {

    }

    
    private void BACK()
    {
        UIManager.Instance.pop(false);
        UIManager.Instance.push(new startPanel());
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "back").GetComponent<Button>().onClick.AddListener(BACK);

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
