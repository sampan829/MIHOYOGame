using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscPanel : basePanel
{
    private static readonly string name = "EscPanel";
    private static readonly string path = "PanelRes/EscPanel";
    public static readonly UIType uIType = new UIType(name, path);
    public EscPanel() : base(uIType)
    {
    }

    public override void OnStart()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        base.OnStart();
        Button backgame=activeobj.transform.Find("backgame").GetComponent<Button>();    
        Button exit=activeobj.transform.Find("exit").GetComponent<Button>();
        Button setting =activeobj.transform.Find("setting").GetComponentInChildren<Button>();

        exit.onClick.AddListener(() =>
        {
            gameRoot.Instance.UIManagerRoot.push(new trueExitPanel());
        });
        backgame.onClick.AddListener(() =>
        {
            Cursor.lockState= CursorLockMode.Locked;
            gameRoot.Instance.UIManagerRoot.pop(false);
            Time.timeScale = 1.0f;
        });
        setting.onClick.AddListener(() =>
        {
            gameRoot.Instance.UIManagerRoot.pop(false);
            gameRoot.Instance.UIManagerRoot.push(new settingPanel());
        });
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
