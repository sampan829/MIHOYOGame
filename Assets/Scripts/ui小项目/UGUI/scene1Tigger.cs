using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene1Tigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void eventTigger()
    {
        if (this!=null )
        {
            Scene1 tmp = gameRoot.Instance.sceneContorlRoot.scenedic[Scene1.name] as Scene1;
            if (tmp == null)
            {
                Debug.Log("scene1 don exist");
                return;
            }
            switch (this.tag)
            { 
                

                case "Clock":

                   
                   
                        tmp.clock = true;

                    
                    break;
                case "Rock":
                   
                   
                    tmp.stone = true;
                    
                    break;
                case "Bottle":

                    tmp.bottleWater= true;
                    break;

            }

          
             
        }
        
    }
}
