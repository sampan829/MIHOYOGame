using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager 
{
    // Start is called before the first frame update
    public Dictionary<string,GameObject> uidic;
    public  Stack<basePanel> uistack;
    public GameObject canvasObj;
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null) instance = new UIManager();
            return instance;
        }
    }
    public UIManager()
    {
        instance = this;
        uistack = new Stack<basePanel>();
        uidic=new Dictionary<string,GameObject>();
    }
    public GameObject getsSingleObj(UIType uitpye)
    {
        if (uidic.ContainsKey(uitpye.Name)){
            return uidic[uitpye.Name];
        }
        if (canvasObj == null)
        {
            Debug.Log("error canva");
            canvasObj = UIMethod.Instance.findCanvas();
        }
        //???
        return GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uitpye.Path),canvasObj.transform);
    }
    public void push(basePanel basePanel)
    {
        if (uistack.Count > 0)
        {
            uistack.Peek().OnDisable();

        }
        GameObject uiobj = getsSingleObj(basePanel.uiType);
        uidic.Add(basePanel.uiType.Name, uiobj);
        basePanel.activeobj= uiobj;
        if (uistack.Count == 0)
        {
            uistack.Push(basePanel);

        }
        else
        {
            if(uistack.Peek().uiType.Name!=basePanel.uiType.Name)
            {
                uistack.Push(basePanel);
            }
        }
        basePanel.OnStart();

    }
    public void pop(bool isload)
    {
        Debug.Log(this);
        if (isload == true)
        {
            if (uistack.Count > 0)
            {
                uistack.Peek().OnDisable();
                uistack.Peek().OnDestory();
                GameObject.Destroy(uidic[ uistack.Peek().uiType.Name]);
                uidic.Remove(uistack.Peek().uiType.Name);
                uistack.Pop();
                pop(true);
            }
        }
        else
        {
            if (uistack.Count > 0)
            {
                uistack.Peek().OnDisable();
                uistack.Peek().OnDestory();
                GameObject.Destroy(uidic[uistack.Peek().uiType.Name]);
                uidic.Remove(uistack.Peek().uiType.Name);
                uistack.Pop();
                if(uistack.Count > 0)uistack.Peek().OnEnable();
            }
        }

    }

}
