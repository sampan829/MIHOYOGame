using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basePanel 
{
    // Start is called before the first frame update
    public UIType uiType;
    public GameObject activeobj;
    public basePanel(UIType uiType)
    {
        this.uiType = uiType;
    }
    public virtual void OnStart()
    {
        Debug.Log("start");
        UIMethod.Instance.getOrAddComponent<CanvasGroup>(activeobj).interactable = true;
    }
    public virtual void OnEnable()
    {
        UIMethod.Instance.getOrAddComponent<CanvasGroup>(activeobj).interactable = true;
    }
    public virtual void OnDisable()
    {
        UIMethod.Instance.getOrAddComponent<CanvasGroup>(activeobj).interactable= false;
    }
    public virtual void OnDestory()
    {
        UIMethod.Instance.getOrAddComponent<CanvasGroup>(activeobj).interactable = false;
    }

}
