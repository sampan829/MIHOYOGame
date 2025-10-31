using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerscPanel : basePanel
{
    private static string name = "MakersPanel";
    private static string path = "PanelRes/MakersPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public MakerscPanel() : base(uIType)
    {

    }

    private void BACK()
    {
        gameRoot.Instance.UIManagerRoot.pop(false);
        gameRoot.Instance.UIManagerRoot.push(new startPanel());

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
        Debug.Log("makerspanel back0");
        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
