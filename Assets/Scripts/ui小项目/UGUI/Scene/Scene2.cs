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

    public Scene2()
    {

    }
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
        //instance=null;
        // gameRoot.Instance.sc2 = null;
        gameRoot.Instance.removeScene<Scene2>();
    }

    public void renewstatement(bool val)
    {
        if (val)
        {
            clock = false;
            bottleWater=false;
            stone = false;
            rockNextCamp=false;
            

        }
    }
 
}
