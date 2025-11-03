using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Button firstMapButton = UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "firstmap").GetComponent<Button>();
        Button dierMapButton = UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "secondmap").GetComponent<Button>();
        Button disanMapButton = UIMethod.Instance.getOrAddComponentInChild<Button>(activeobj, "thirdmap").GetComponent<Button>();
        accessMap am=playerPrefsDataMgr.Instance.loaddata(typeof(accessMap), "AccessMap") as accessMap;
        if (am.firstIf == true)
        {
            
            GameObject X = GameObject.Find("firstmap/X");
            X.SetActive(false);
            firstMapButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("initial-map-1");
                UIManager.Instance.pop(true);
            });
            
        }
        else
        {
            firstMapButton.interactable = false;
        }
        if (am.secondIf == true)
        {
           
            GameObject X = GameObject.Find("secondmap/X");
            X.SetActive(false);

            dierMapButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Final-map-1");
                UIManager.Instance.pop(true);
            });

        }
        else
        {
           dierMapButton.interactable = false;
        }
        if (am.thirdIf == true)
        {
           
            GameObject X = GameObject.Find("thirdmap/X");
            X.SetActive(false);

            disanMapButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Final-map-2");
                UIManager.Instance.pop(true);
            });
        }
        else
        { 
            disanMapButton.interactable = false;

        }

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
