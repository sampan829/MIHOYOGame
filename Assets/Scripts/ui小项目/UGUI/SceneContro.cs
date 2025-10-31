using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContro
{
    // Start is called before the first frame update
    public Dictionary<string, SceneBase> scenedic;
    private static SceneContro instance;
    public SceneContro() { 
    
        instance=this;
        scenedic = new Dictionary<string, SceneBase>();
    }
    public static SceneContro Instance
    {
        get { return instance; }
    }
    public void loadScene(string sceneName,SceneBase sb)
    {
        if (!scenedic.ContainsKey(sceneName))
        {
            scenedic.Add(sceneName, sb);
        }

        if (scenedic.ContainsKey(SceneManager.GetActiveScene().name)){
            scenedic[SceneManager.GetActiveScene().name] .exitScene();
        }
        gameRoot.Instance.UIManagerRoot.pop(true);

        SceneManager.LoadScene(sceneName);
        sb.enterScene();

    }
}
