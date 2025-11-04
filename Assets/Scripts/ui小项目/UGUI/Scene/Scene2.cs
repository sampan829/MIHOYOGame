using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 :SceneBase
{
    public static readonly string name = "Final-map-1";
    public bool clock;
    public bool bottleWater;
    public bool stone;
    public bool rockNextCamp;
    

    public bool mountain;
    public bool forest;

    public bool win;

    private static Scene2 instance;
    public static Scene2 Instance
    {
        get
        {
            if (instance == null) instance = new Scene2();
            return instance;
        }
    }
    public override void enterScene()
    {
        gameRoot.Instance.UIManagerRoot.push(new paperPanel());
    }

    public override void exitScene()
    {
        instance=null;
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
