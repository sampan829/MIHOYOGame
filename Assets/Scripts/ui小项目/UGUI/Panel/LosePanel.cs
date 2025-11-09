using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : basePanel
{
    private static readonly string name = "LosePanel";
    private static readonly string path = "PanelRes/LosePanel";
    public static readonly UIType uIType = new UIType(name, path);
    public LosePanel() : base(uIType)
    {
    }

    public override void OnStart()
    {
        GameObject.Instantiate(Resources.Load("soundPrefabs/lose"));
        base.OnStart();
        Time.timeScale = 0;
        Button exit= activeobj.transform.Find("exit").GetComponent<Button>();
        exit.onClick.AddListener(()=>{

            gameRoot.Instance.UIManagerRoot.pop(true);
            gameRoot.Instance.sceneContorlRoot.loadScene(Scene0.name, new Scene0());
            gameRoot.Instance.changeSceneSwitch(true);
            Time.timeScale = 1.0f;
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
