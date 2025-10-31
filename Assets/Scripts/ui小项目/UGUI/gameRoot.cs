using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        DontDestroyOnLoad(gameObject);
        UIManagerRoot.canvasObj = UIMethod.Instance.findCanvas();

        Scene1 scene1= new Scene1();    
        SceneContro.Instance.scenedic.Add(scene1.name, scene1);

        UIManagerRoot.push(new startPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
