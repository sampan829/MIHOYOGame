using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startPanel : basePanel
{
    private static  string name = "StartPanel";
    private static string path = "PanelRes/StartPanel";
    public static readonly UIType uIType = new UIType(name,path);
   // public Button back;


    public startPanel() : base(uIType)
    {
        
        
    }


    // Start is called before the first frame update
    private void BACK()
    {
        Application.Quit();
        gameRoot.Instance.UIManagerRoot.pop(false);
        

    }
    private void LOAD()
    {
        gameRoot.Instance.UIManagerRoot.pop(false);
        gameRoot.Instance.UIManagerRoot.push(new choosePanel());
       
       

    }
    private void SETTING()
    {
        gameRoot.Instance.UIManagerRoot.pop(false);
        gameRoot.Instance.UIManagerRoot.push(new settingPanel());

    }
    private void MAKERS()
    {
        gameRoot.Instance.UIManagerRoot.pop(false);
        gameRoot.Instance.UIManagerRoot.push(new MakerscPanel());
    }


    public override void OnStart()
    {
        base.OnStart();

        
         // tansform.find()是找自己的子对象 有一个弃用的方法 FindChild() 名字更直观
        /*
        Button back = activeobj.transform.Find("back").GetComponent<Button>(); 
        back.onClick.AddListener(BACK);
        */
       
        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "exit").GetComponent<Button>().onClick.AddListener(BACK);
        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "gameMakers").GetComponent<Button>().onClick.AddListener(MAKERS);
        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "setting").GetComponent<Button>().onClick.AddListener(SETTING);
        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "begin").GetComponent<Button>().onClick.AddListener(LOAD);

    }

    public override void OnEnable()
    {
        
        base.OnEnable();
    }
    

    public override void OnDisable()
    {
        
        Debug.Log("startingpanel back0");

        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
