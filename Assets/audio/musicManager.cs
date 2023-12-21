using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    [SerializeField] GameObject listener;
    [SerializeField] AK.Wwise.Event mainMusic;

    public int cueCount = 0;
    public bool window = true;

    // Start is called before the first frame update
    void Start()
    {
        mainMusic.Post(listener, (uint)AkCallbackType.AK_MusicSyncUserCue, setWindow);
        
    }

    public void setWindow (object in_cookie, AkCallbackType in_type, object in_info)
    {
        cueCount = cueCount + 1;
        if (cueCount % 2 == 0)
        {
            window = true;
        }
        else
        {
            window = false;
        }
    }
}
