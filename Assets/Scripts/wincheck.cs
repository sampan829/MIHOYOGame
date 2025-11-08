using Boxophobic.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wincheck : MonoBehaviour
{
    // Start is called before the first frame update
    private bool winBuild;

 
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(winBuild==false)check();
        
    }
    public void check()
    {
        Debug.Log(" you real win !!!!!");
        gameRoot.Instance. changeSceneSwitch(true);
        Debug.Log("you win");
        Time.timeScale = 0;
        if (gameRoot.Instance.UIManagerRoot.uistack.Peek().uiType.Name != winPanel.name)
        {
            Debug.Log("ttt");
            Debug.Log(SceneManager.GetActiveScene().name + " win panel ");
            gameRoot.Instance.UIManagerRoot.push(new winPanel());
            winBuild=true;
        }
    }
}
