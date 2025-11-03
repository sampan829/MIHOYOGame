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

    private dataMgr()
    {
        musicdata = playerPrefsDataMgr.Instance.loaddata(typeof(musicData), "Music") as musicData;
        accessmap=playerPrefsDataMgr.Instance.loaddata(typeof(accessMap),"AccessMap") as accessMap;
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



}
