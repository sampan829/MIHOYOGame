using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scene3Tigger : MonoBehaviour
{
    public static bool del=false;
    //private Scene3 tmp;
    // Start is called before the first frame update
    void Start()
    {
      //  Scene3 tmp = gameRoot.Instance.sceneContorlRoot.scenedic[Scene3.name] as Scene3;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRoot.Instance.sc3 != null)
        {
            del = gameRoot.Instance.sc3.delete;
        }
        
        if (this.tag == "Tent" && del)
        {
            Debug.Log("oooowowowwowowowoowwwwwwwdasddasdsadsadsadsa");
            this.gameObject.SetActive(false);
        }
        
    }
    public void eventTigger()
    {
        if (this != null)
        {
            Scene3 tmp = gameRoot.Instance.sceneContorlRoot.scenedic[Scene3.name] as Scene3;
            if (tmp == null)
            {
                Debug.Log("scene1 don exist");
                return;
            }
            
            switch (this.tag)
            {


                case "Seafloor":



                    tmp.seafloor = true;


                    break;
                case "Tent":

                    if (this.transform.name == "TentMain")
                    {
                        del=true; 

                        tmp.tent = true;
                        
                    }
                    

                    break;
                case "grass":

                    tmp.grass = true;
                    break;
                case "Bottle":
                    tmp.bottlewater = true;
                    break;
               

            }
        }

    }
}
