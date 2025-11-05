using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winPanel : basePanel
{
    public readonly static string name = "WinPanel";
    public readonly static string path = "PanelRes/winPanel";
    public static readonly UIType uIType = new UIType(name, path);


    private Button exit;

    public winPanel() : base(uIType)
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
        exit=activeobj.transform.Find("exit").GetComponent<Button>() ;
        Debug.Log("wwinwinwiwniwnwninwinw");
        exit.onClick.AddListener(() =>
        {
            Time.timeScale= 1.0f;
           
            gameRoot.Instance.UIManagerRoot.pop(true);
            gameRoot.Instance.sceneContorlRoot.loadScene("MainScene",new Scene0());
            //gameRoot.Instance.UIManagerRoot.push(new startPanel());
        }
        );


    }

    // Start is called before the first frame update


}
