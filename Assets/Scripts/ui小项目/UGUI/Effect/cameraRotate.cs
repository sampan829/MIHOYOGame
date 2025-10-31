using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation=Quaternion.AngleAxis(rSpeed*Time.deltaTime, Vector3.up)* this.transform.rotation;
        
    }
}
