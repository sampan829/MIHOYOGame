using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trueExitPanel : basePanel
{
    private static readonly string name = "TrueExitPanel";
    private static readonly string path = "PanelRes/TrueExitPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public trueExitPanel() : base(uIType)
    {
    }
    private void BACK()
    {
        gameRoot.Instance.UIManagerRoot.pop(false);
       // gameRoot.Instance.UIManagerRoot.push(new EscPanel());
    }

    private void TRUEEXIT()
    {
        gameRoot.Instance.UIManagerRoot.pop(true);
        gameRoot.Instance.sceneContorlRoot.loadScene(Scene0.name, new Scene0());
        gameRoot.Instance.changeSceneSwitch(true);
        Time.timeScale = 1.0f;
    }
    public override void OnStart()
    {
        base.OnStart();
        Button backgame=activeobj.transform.Find("back").GetComponent<Button>();
        Button trueexit = activeobj.transform.Find("exit").GetComponent<Button>();
        backgame.onClick.AddListener(BACK);
        trueexit.onClick.AddListener(TRUEEXIT);
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
