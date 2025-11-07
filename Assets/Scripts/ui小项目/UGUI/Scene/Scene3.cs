using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : SceneBase
{
    public static readonly string name = "Final-map-2";


    public bool tent;
    public bool grass;
    public bool seafloor;
    public bool bottlewater;

    public bool delete;
    public bool buliding;
    public bool farm;
    public bool bridge;

    public bool win;
    public override void enterScene()
    {
        gameRoot.Instance.UIManagerRoot.push(new paperPanel());
    }

    public override void exitScene()
    {
        gameRoot.Instance.removeScene<Scene3>();
    }
    public void renewstatement(bool val)
    {
        if (val)
        {
            tent = false;
            grass = false;
            seafloor = false;
            bottlewater = false;


        }
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
