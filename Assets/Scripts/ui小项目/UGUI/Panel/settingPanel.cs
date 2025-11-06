using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settingPanel : basePanel
{
    private static string name = "SettingPanel";
    private static string path = "PanelRes/SettingPanel";
    public static readonly UIType uIType = new UIType(name, path);
    private Toggle musicBool;
    private Slider musicSlider;
    public settingPanel() : base(uIType)
    {
    }

    private void CHANGEMUSICBOOL(bool val)
    {
        dataMgr.Instance.changeBolMsic(val);
    }
    private void CHANGEMUSICVALUE(float val)
    {
        Debug.Log("music val " + musicSlider.value);
        dataMgr.Instance.changeMusic(val);
    }
    private void BACK()
    {

        /*
        UIManager.Instance.pop(false);
        UIManager.Instance.push(new startPanel());
        */

        if (SceneManager.GetActiveScene().name==Scene0.name)
        {
            gameRoot.Instance.UIManagerRoot.pop(false);
            gameRoot.Instance.UIManagerRoot.push(new startPanel());
        }
        else
        {
            gameRoot.Instance.UIManagerRoot.pop(false);
            gameRoot.Instance.UIManagerRoot.push(new EscPanel());   
        }
        
    }
    public override void OnStart()
    {
        base.OnStart();


        UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "back").GetComponent<Button>().onClick.AddListener(BACK);

        musicBool = UIMethod.Instance.getOrAddComponentInChild<Toggle>(activeobj, "musicbool");
        musicSlider = UIMethod.Instance.getOrAddComponentInChild<Slider>(activeobj, "musicslider");
        updataData();
        musicBool.onValueChanged.AddListener(CHANGEMUSICBOOL);
        musicSlider.onValueChanged.AddListener(CHANGEMUSICVALUE);
        
        
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
    private void updataData()
    {
        musicData data = dataMgr.Instance.musicdata;
        if (musicBool != null && musicSlider != null)
        {
            musicBool.isOn = data.musicOpen;
            musicSlider.value = data.musicVal;
        } 
    }
}
