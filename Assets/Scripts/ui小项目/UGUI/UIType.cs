using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    // Start is called before the first frame update
    private string name;
    public string Name {  get { return name; } }
    private string path;
    public string Path { get { return path; } }
    /// <summary>
    /// 
    /// s
    /// </summary>
    /// <param name="name"></param>
    /// <param name="path"></param>
    public  UIType(string name,string path)
    {
        this.name = name;
        this.path = path;

    }
    ///


   
}
