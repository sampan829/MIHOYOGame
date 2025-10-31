using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMethod
{
    private static  UIMethod instance=new UIMethod();
    public static UIMethod Instance
    {
        get
        {
            return instance;
        }
    }
    public GameObject findCanvas()
    {
        if (GameObject.FindObjectOfType<Canvas>() == null) Debug.Log("没有canvas");
        return GameObject.FindObjectOfType<Canvas>().gameObject;
    }
    public GameObject findObjInChild(GameObject parent,string sonName)
    {
        if (parent.transform.Find(sonName).gameObject == null) Debug.Log($"{parent.name}的孩子{sonName}找不到");
        return parent.transform.Find(sonName).gameObject;

    }
    public T getOrAddComponent<T>(GameObject gameObject) where T : Component
    {
        if (gameObject.GetComponent<T>() == null)
        {
            gameObject.AddComponent<T>();
            Debug.Log($"{gameObject.name}不存在组件");
        }
        return gameObject.GetComponent<T>();    
    }

    public T getOrAddComponentInChild<T>(GameObject gameObject,string sonName) where T : Component
    {
        if(gameObject.transform.Find(sonName)== null)
        {
            Debug.Log($"{gameObject.name}不存在儿子{sonName}，无法得到添加组件");
            return null;
        }
        if(gameObject.transform.Find(sonName).GetComponent<T>() == null)
        {
            Debug.Log($"{gameObject.name}无组件,已添加");
            gameObject.transform.Find(sonName).AddComponent<T>();
        }
        else { }
        return gameObject.transform.Find(sonName).GetComponent<T>();

    }
}

