using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameRoot : MonoBehaviour
{
    // Start is called before the first frame update

    public UIManager UIManagerRoot;
    
    public SceneContro sceneContorlRoot;
    
    private static gameRoot instance;
    public static gameRoot Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance == null) 
        instance = this.GetComponent<gameRoot>();
        else
        {
            Destroy(gameObject);
        }
        sceneContorlRoot = new SceneContro();
        UIManagerRoot = new UIManager();

    }
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(gameObject);
        UIManagerRoot.canvasObj = UIMethod.Instance.findCanvas();

        if (SceneManager.GetActiveScene().name == Scene0.name)
        {
            //mainscene
            Scene0 scene0 = new Scene0();

            SceneContro.Instance.scenedic.Add(Scene0.name, scene0);



            UIManagerRoot.push(new startPanel());

        }
        //测试才触发
        else if (SceneManager.GetActiveScene().name == Scene1.name)
        {//initialmap1
            Scene1 scene1 = new Scene1();

            SceneContro.Instance.scenedic.Add(Scene1.name, scene1);
            UIManagerRoot.push(new paperPanel());
            // if (SceneContro.Instance.scenedic.ContainsKey(SceneManager.GetActiveScene().name)) Debug.Log("正确的");

        }
        else if (SceneManager.GetActiveScene().name == Scene2.name)
        {
            Scene2 scene2 = new Scene2();

            SceneContro.Instance.scenedic.Add(Scene2.name, scene2);
            sc2 = sceneContorlRoot.scenedic[Scene2.name] as Scene2;
            UIManagerRoot.push(new paperPanel());
        }
        else;
        
    }

    public Scene0 sc0;
    public Scene1 sc1;
    public Scene2 sc2;
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == Scene1.name)
        {
            if (sceneContorlRoot.scenedic[Scene1.name] != null&& (sceneContorlRoot.scenedic[Scene1.name] as Scene1).win==false)
            {
                  //(sceneContorlRoot.scenedic[Scene1.name] as Scene1).clock
            }
            
        }
        else if (SceneManager.GetActiveScene().name == Scene2.name)
        {
            //sc2 = sceneContorlRoot.scenedic[Scene2.name] as Scene2;
            if (sc2 != null && sc2 .win == false)
            {
                if (sc2.mountain == false && sc2.stone)
                {
                    sc2.mountain = true;
                    GameObject.Instantiate(Resources.Load("prefabs/Rock"));
                }
                if(sc2.forest == false&& sc2.bottleWater && sc2.rockNextCamp)
                {
                    Debug.Log("ssss");
                   sc2.forest= true;
                   GameObject.Instantiate(Resources.Load("prefabs/Plant"));




                }

                if (sc2.forest && sc2.mountain)sc2.win= true;

            }
            else if (sc2.win)
            {
                Debug.Log("you win");

                
            }
        }
        
        
    }
    
}
