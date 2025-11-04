using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCubeClicked()
    {

        //Debug.Log(SceneManager.GetActiveScene().name);
        
        // gameRoot.Instance.UIManagerRoot.push(new paperPanel());
        //GameObject tmp = gameRoot.Instance.UIManagerRoot.uidic[Scene1.name].GetComponentInChildren<GameObject>();
        for(int i = 1; i < 10; ++i)
        {
            if (this.name!="clude"+i) continue;

            Image tmp = gameRoot.Instance.UIManagerRoot.uidic[paperPanel.name].transform.Find("clude"+i).GetComponent<Image>();
            tmp.enabled= true;

        }
        


       // Debug.Log(SceneManager.GetActiveScene().name);
        this.gameObject.SetActive(false);

    }
}
