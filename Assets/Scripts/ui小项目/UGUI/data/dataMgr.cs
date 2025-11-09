using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataMgr 
{
    // Start is called before the first frame update

    private static dataMgr instance = new dataMgr();
    public static dataMgr Instance { get { return instance; } }
    public musicData musicdata;
    public accessMap accessmap;
    public soundData sounddata;
    private dataMgr()
    {
        musicdata = playerPrefsDataMgr.Instance.loaddata(typeof(musicData), "Music") as musicData;
        accessmap=playerPrefsDataMgr.Instance.loaddata(typeof(accessMap),"AccessMap") as accessMap;
        sounddata = playerPrefsDataMgr.Instance.loaddata(typeof(soundData), "Sound") as soundData;
        if (musicdata.notFirst==false)
        {
            musicdata.notFirst = true;
            //musicdata.soudVal = 50;
            musicdata.musicVal = 50;
            musicdata.musicOpen = true;
           // musicdata.soundOpen = true;
            playerPrefsDataMgr.Instance.savedata(musicdata, "Music");

        }
        if (accessmap.notFirst == false)
        {
            accessmap.notFirst = true;
            accessmap.firstIf = true;
            accessmap.secondIf = false;
            accessmap.thirdIf = false;
            playerPrefsDataMgr.Instance.savedata(accessmap, "AccessMap");

        }
        if(sounddata.notFirst == false)
        {
            sounddata.notFirst = true;

            sounddata.soundVal = 50;
            sounddata.soundOpen = true;
            
            playerPrefsDataMgr.Instance.savedata(sounddata, "Sound");
        }
        //test

        accessmap.firstIf = true;
        accessmap.secondIf = true;
        accessmap.thirdIf = true;
        playerPrefsDataMgr.Instance.savedata(accessmap, "AccessMap");
        //
    }
    public void changeMusic(float val)
    {
        musicdata.musicVal = val;
        bkMusic.Instance.changeVol(val);
        playerPrefsDataMgr.Instance.savedata(musicdata, "Music");
    }
    public void changeBolMsic(bool newbool)
    {
        musicdata.musicOpen = newbool;
        bkMusic.Instance.changeIS(newbool);
        playerPrefsDataMgr.Instance.savedata(musicdata, "Music");
    }


    public void changeSound(float val)
    {
        Debug.Log("qqqq");
        sounddata.soundVal = val;
        //bkMusic.Instance.changeVol(val);
        soudeff.Instance.changeVol(val);
        playerPrefsDataMgr.Instance.savedata(sounddata, "Sound");
    }
    public void changeBolSound(bool newbool)
    {
        Debug.Log("qqqq");
        sounddata.soundOpen = newbool;
        //bkMusic.Instance.changeIS(newbool);
        soudeff.Instance.changeIS(newbool);
        playerPrefsDataMgr.Instance.savedata(sounddata, "Sound");
    }



}
