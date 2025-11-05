using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1 :SceneBase

{
    public static string name = "initial-map-1";
    //public static readonly string passCom = "KJQNB";

    public bool clock;
    public bool bottleWater;
    public bool stone;
    public bool tent;

    public bool tents;
    public bool win;
    
    private static Scene1 instance;
    public static Scene1 Instance
    {
        get {
            if (instance == null) instance = new Scene1 ();
            return instance; 
        }
    }

   


    public override void enterScene()
    {
        //Debug.Log("第一关来咯"+ SceneManager.GetActiveScene().name);
        gameRoot.Instance.UIManagerRoot.push(new paperPanel());
        //if (SceneContro.Instance.scenedic.ContainsKey(this.name)) Debug.Log("正确的");
        //Debug.Log(SceneContro.Instance.scenedic.Count);
    }

    public override void exitScene()
    {

        //instance = null;
        gameRoot.Instance.removeScene<Scene1>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
