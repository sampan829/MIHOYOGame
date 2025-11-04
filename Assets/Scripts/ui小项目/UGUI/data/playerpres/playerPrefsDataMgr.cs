using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class playerPrefsDataMgr

{
    private static playerPrefsDataMgr instance = new playerPrefsDataMgr();
    public static playerPrefsDataMgr Instance {

        
        get {  return instance; }
    }
    public  void savedata(object data,string keyname)
    {
        Type datatpye = data.GetType();
        FieldInfo[] infos = datatpye.GetFields();
        string savekeyname = "";
        for (int i = 0; i < infos.Length; i++) {
            FieldInfo info = infos[i];
            savekeyname = keyname+"_"+ datatpye.Name + "_" + info.FieldType.Name + "_" + info.Name;
            //Debug.Log(savekeyname);
            savevalue(info.GetValue(data), savekeyname);
        }
        

    }
    public void savevalue(object value,string keyname)
    {Type feild = value.GetType();
        if (feild == typeof(int))
        {
            //Debug.Log("´æ´¢INT" + keyname);
            PlayerPrefs.SetInt(keyname, (int)value);
        }
        else if (feild == typeof(float))
        {
            //Debug.Log("´æ´¢FLOAT" + keyname );
            PlayerPrefs.SetFloat(keyname, (float)value);
        }
        else if (feild == typeof(string))
        {
            //Debug.Log("´æ´¢STRING" + keyname );
            PlayerPrefs.SetString(keyname, value.ToString());
        }
        else if (feild == typeof(bool)) {
            //Debug.Log("´æ´¢BOOL" + keyname );
            PlayerPrefs.SetInt(keyname, (bool)value?1:0);

        }
        else if (typeof(IList).IsAssignableFrom(feild))
        {
            //¸¸×°×Ó
            //Debug.Log("´ælist" + keyname);
            IList list = value as IList;
            PlayerPrefs.SetInt(keyname,list.Count);
            int i = 0;
            foreach(object obj in list)
            {
                savevalue(obj,keyname+"_"+i);
                i++;
            }
            /*
            for(int i = 0; i < list.Count; i++)
            {
                savevalue(list[i], keyname+i);
            }*/
           

        }
        else if (typeof(IDictionary).IsAssignableFrom(feild))
        {
           // Debug.Log("´ædictionanry" + keyname);
            IDictionary dict = value as IDictionary;
            PlayerPrefs.SetInt(keyname, dict.Count);
            int index = 0;
            foreach (object key in dict.Keys)
            {
                savevalue(key, keyname + "_key_" + index);
                savevalue(dict[key], keyname + "_value_" + index);
                index++;
            }
        }
        else//player1_playerinfo_String_name//player1_playerinfo_String_name
        {
            savedata(value, keyname);
        }
            

    }
    public  object loaddata(Type type,string keyname)
    {
       // Debug.Log("loaddata!!!!!!!" + keyname);
        object data=Activator.CreateInstance(type);
        FieldInfo[] infos =type.GetFields();
        string loadname = "";
        for(int i = 0; i < infos.Length; ++i)
        {
            
            FieldInfo info = infos[i];
            loadname= keyname + "_"+type.Name+ "_"+ info.FieldType.Name + "_" + info.Name;
           // Debug.Log(loadname);
            info.SetValue(data, loadvalue(info.FieldType, loadname));
        }


        return data;

    }
    public object loadvalue(Type type, string keyname)
    {
        //Debug.Log("testint");
        if (type == typeof(int))
        {
            //Debug.Log("testint");
            return PlayerPrefs.GetInt(keyname);
        }
        else if (type == typeof(float)) 
            {
            return PlayerPrefs.GetFloat(keyname);
        }
        else if(type == typeof(string))
        {
            return PlayerPrefs.GetString(keyname);
        }
        else if( type == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyname) == 1? true :false;
        }
        else if(typeof(IList).IsAssignableFrom(type))
        {
            int count =PlayerPrefs.GetInt(keyname);
            IList list=Activator.CreateInstance(type) as IList;

            for(int i = 0;i < count; ++i)
            {
                list .Add(loadvalue(type.GetGenericArguments()[0],keyname+"_"+i));
            }
            return list;
        }
        
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            int count =PlayerPrefs.GetInt (keyname);
            IDictionary dic =Activator.CreateInstance(type) as IDictionary;
            
            for(int i = 0; i < count; ++i)
            {
                dic.Add(loadvalue(type.GetGenericArguments()[0], keyname + "_key_" + i),
                    loadvalue(type.GetGenericArguments()[1], keyname + "_value_" + i));
                Debug.Log("load     !!    " + keyname + "_key_" + i);
            }
            
            return dic;

        }
        else
        {
           return loaddata(type, keyname);
        }
            //Debug.Log("ÎÒÊäÁË£¡£¡");
           // return null;
    }
}
