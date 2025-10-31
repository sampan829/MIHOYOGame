using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataMgr 
{
    // Start is called before the first frame update

    private static dataMgr instance = new dataMgr();
    public static dataMgr Instance { get { return instance; } }
    public musicData musicdata;

    private dataMgr()
    {
        musicdata = playerPrefsDataMgr.Instance.loaddata(typeof(musicData), "Music") as musicData;
        if (!musicdata.notFirst)
        {
            musicdata.notFirst = true;
            //musicdata.soudVal = 50;
            musicdata.musicVal = 50;
            musicdata.musicOpen = true;
           // musicdata.soundOpen = true;
            playerPrefsDataMgr.Instance.savedata(musicdata, "Music");

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
