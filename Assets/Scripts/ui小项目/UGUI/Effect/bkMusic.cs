using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bkMusic : MonoBehaviour
{
    private static bkMusic instance;
    public static bkMusic Instance { get { return instance; } }

    private AudioSource AS;
    private void Awake()
    {

        instance = this;
        AS = this.GetComponent<AudioSource>();
        changeIS(dataMgr.Instance.musicdata.musicOpen);
        changeVol(dataMgr.Instance.musicdata.musicVal);
    }
    void Start()
    {
        
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
