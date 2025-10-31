using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class titleMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] movePos;
    private Transform target;
    public float movespeed = 5.0f;
    private float time;
    void Start()
    {

        changepos();
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.name);
        if (movePos.Length > 0)
        {
            time += Time.deltaTime;
          //   Vector3 toward=this.transform.position-target.position; 
            this.transform.position=Vector3.Slerp( this.transform.position,target.position , time*movespeed);
            if(Vector3.Distance(target.position, this.transform.position) <5f)
            {
                changepos();
                time = 0;
            }
        }
        
    }
    private void changepos()
    {
        if (movePos.Length > 0)
        {
            int index = Random.Range(0, movePos.Length);
            target = movePos[index];
        }
    }
}
