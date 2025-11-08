using Boxophobic.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameRoot : MonoBehaviour
{
    // Start is called before the first frame update

    public UIManager UIManagerRoot;
    
    public SceneContro sceneContorlRoot;
    
    private static gameRoot instance;
    private bool sceneSwitch= false ;
    public bool SceneSW
    {
        get
        {
            return sceneSwitch;
        }
       
    }


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
            //UIManagerRoot.push(new winPanel());

        }
        //测试才触发
        else if (SceneManager.GetActiveScene().name == Scene1.name)
        {//initialmap1
            Scene1 scene1 = new Scene1();

            SceneContro.Instance.scenedic.Add(Scene1.name, scene1);
            sc1 = sceneContorlRoot.scenedic[Scene1.name] as Scene1;
            UIManagerRoot.push(new paperPanel());
            // if (SceneContro.Instance.scenedic.ContainsKey(SceneManager.GetActiveScene().name)) Debug.Log("正确的");

        }
        else if (SceneManager.GetActiveScene().name == Scene2.name)
        {
            Scene2 scene2 = new Scene2();

            SceneContro.Instance.scenedic.Add(Scene2.name, scene2);
            sc2 = sceneContorlRoot.scenedic[Scene2.name] as Scene2;
            UIManagerRoot.push(new paperPanel());
            //UIManagerRoot.push(new winPanel());
            // UIManagerRoot.push(new startPanel());
        }
        else if (SceneManager.GetActiveScene().name == Scene3.name)
        {

            Scene3 scene3 = new Scene3();
            SceneContro.Instance.scenedic.Add(Scene3.name, scene3);
            sc3 = sceneContorlRoot.scenedic[Scene3.name] as Scene3;
            UIManagerRoot.push(new paperPanel());


        }
        
        
        
    }

    public Scene0 sc0;
    public Scene1 sc1;
    public Scene2 sc2;
    public Scene3 sc3;
    // Update is called once per frame
    void Update()
    {

        checkWin();
        Esc();
        lose();

    }
    private void OnGUI()
    {

        if (SceneManager.GetActiveScene().name == Scene2.name)
        {

            
        }
        

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += scSwitch;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= scSwitch;
    }
    private  void scSwitch( UnityEngine.SceneManagement.Scene s,LoadSceneMode mode)
    {
        sceneSwitch = false;

    }

    public void removeScene<T>() where T:SceneBase
    {
        Type t= typeof(T);
        if (t == typeof(Scene1))
        {
            if(instance!=null)Instance. sc1 = null;
            else
                Debug.Log("gameroot instance ==null , 无法删除场景");
        }
        else if (t == typeof(Scene2))
        {
            if (instance != null)Instance. sc2 = null;
            else
                Debug.Log("gameroot instance ==null , 无法删除场景");
        }
        else if(t == typeof(Scene3))
        {
            if (instance != null) Instance.sc3 = null;
            else
                Debug.Log("gameroot instance ==null , 无法删除场景");
        }
    }
    private void checkWin()
    {

        if (sceneSwitch) return;

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == Scene0.name)
        {
            if (UIManagerRoot.uistack.Count == 0)
            {
                UIManagerRoot.push(new startPanel());

            }


            //Debug.Log("hihihi" + UIManagerRoot.uistack.Count);
            return;
        }
        else if (SceneManager.GetActiveScene().name == Scene1.name)
        {
          
            if (sc1 != null && sc1.win == false)
            {
                //(sceneContorlRoot.scenedic[Scene1.name] as Scene1).clock
                

                if (sc1.tents == false)
                {
                    if (sc1.bottleWater && sc1.tent)
                    {
                        sc1.tents = true;
                        GameObject.Instantiate(Resources.Load("prefabs/Tents"));
                        sc1.win= true; 
                    }
                }

            }
            else if (sc1.win && !sceneSwitch)
            {
                GameObject.Instantiate(Resources.Load("prefabs/winFloor"));
                
                sceneSwitch =true;/*
                Debug.Log("you win");
                Time.timeScale = 0;
                if (UIManagerRoot.uistack.Peek().uiType.Name != winPanel.name)
                {
                    Debug.Log("ttt");
                    Debug.Log(SceneManager.GetActiveScene().name + " win panel ");
                    UIManagerRoot.push(new winPanel());
                }*/
            }

        }
        else if (SceneManager.GetActiveScene().name == Scene2.name)
        {
            Debug.Log(sc2.win);
            if (sc2 == null) Debug.Log("sc2 is null");
            //sc2 = sceneContorlRoot.scenedic[Scene2.name] as Scene2;
            if (sc2 != null && sc2.win == false)
            {
                if (sc2.mountain == false && sc2.stone)
                {
                    sc2.mountain = true;
                    GameObject.Instantiate(Resources.Load("prefabs/Rock"));
                }
                if (sc2.forest == false && sc2.bottleWater && sc2.rockNextCamp)
                {

                    sc2.forest = true;
                    GameObject.Instantiate(Resources.Load("prefabs/Plant"));




                }

                if (sc2.forest && sc2.mountain) sc2.win = true;




            }
            else if (sc2.win&&!sceneSwitch)
            {
                GameObject.Instantiate(Resources.Load("prefabs/winFloor"));
                
                sceneSwitch = true;/*
                Debug.Log("you win");
                Time.timeScale = 0;
                if (UIManagerRoot.uistack.Peek().uiType.Name != winPanel.name)
                {
                    Debug.Log("ttt");
                    Debug.Log(SceneManager.GetActiveScene().name + " win panel ");
                    UIManagerRoot.push(new winPanel());
                }
                */
            }

        }
        else if(SceneManager.GetActiveScene().name == Scene3.name)
        {
            if (sc3 != null && sc3.win == false)
            {
                Debug.Log("s");
                if (sc3.buliding == false)
                {
                    if (sc3.tent)
                    {
                        sc3.delete = true;
                        sc3.buliding = true;
                        GameObject.Instantiate(Resources.Load("prefabs/building"));
                    }
                }

               if(sc3.bridge== false)
                {
                    if (sc3.seafloor)
                    {
                        sc3.bridge= true;
                        GameObject.Instantiate(Resources.Load("prefabs/bridege"));
                    }
                }
               if(sc3.farm == false)
                {
                    if (sc3.bottlewater && sc3.grass)
                    {
                        sc3.farm= true;
                        GameObject.Instantiate(Resources.Load("prefabs/Farm"));
                    }
                }
                if (sc3.farm && sc3.bridge && sc3.farm)
                {
                    sc3.win= true;
                }
            }
            else if(sc3 != null&&sc3.win&&!sceneSwitch)
            {
                GameObject.Instantiate(Resources.Load("prefabs/winFloor"));
                
                sceneSwitch = true;/*
                Debug.Log("you win");
                Time.timeScale = 0;
                if (UIManagerRoot.uistack.Peek().uiType.Name != winPanel.name)
                {
                    Debug.Log("ttt");
                    Debug.Log(SceneManager.GetActiveScene().name + " win panel ");
                    UIManagerRoot.push(new winPanel());
                }*/
            }
            
        }
    }
    private void lose()
    {

        if (SceneManager.GetActiveScene().name == Scene0.name) return;

        if (UIManagerRoot.uidic.ContainsKey(NumPanel.uIType.Name)){
            TextMeshProUGUI tmp= UIManagerRoot.uidic[NumPanel.uIType.Name] .transform .Find("Text").GetComponent<TextMeshProUGUI>();


            if (tmp.text == "0"&&UIManagerRoot.uidic.ContainsKey(LosePanel.uIType.Name)==false) {
            
                UIManagerRoot.push(new LosePanel());
        
            }

        }
        
        

    }
    private void Esc()
    {
        string scname = SceneManager.GetActiveScene().name;
        if (scname == null) return;
        if (scname == Scene1.name || scname == Scene2.name||scname==Scene3.name)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (UIManagerRoot.uidic.ContainsKey(trueExitPanel.uIType.Name) || UIManagerRoot.uidic.ContainsKey(EscPanel.uIType.Name)
                    || UIManagerRoot.uidic.ContainsKey(settingPanel.uIType.Name) || UIManagerRoot.uidic.ContainsKey(winPanel.uIType.Name)
                    || UIManagerRoot.uidic.ContainsKey(LosePanel.uIType.Name)
                    )
                    return;
                UIManagerRoot.push(new EscPanel());


                    

            }
        }
        
        
    }
    public void changeSceneSwitch(bool val)
    {
        sceneSwitch = val;
    }
}
