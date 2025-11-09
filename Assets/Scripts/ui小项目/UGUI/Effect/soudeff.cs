using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soudeff : MonoBehaviour
{
   
    public  AudioSource AS;


    private static soudeff instance;
    public static soudeff Instance { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        AS=this.transform.GetComponent<AudioSource>();
        if(AS != null )
        {
            changeIS(dataMgr.Instance.sounddata.soundOpen);
            changeVol(dataMgr.Instance.sounddata.soundVal);
        }
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void changeVol(float value)
    {
        AS.volume = value / 100;

    }
    public void changeIS(bool isopen)
    {
        AS.mute = !isopen;

    }
}
