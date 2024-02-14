using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    [SerializeField] GameObject listener;

    [SerializeField] AK.Wwise.Event mainMusic;
    public int cueCount = 0;
    public bool window = true;

    [SerializeField] AK.Wwise.Event enemyPreAttack;
    public bool enemyInRange = false;
    public int timesInRange = 0;
    public int debugNum = 0;



    // Start is called before the first frame update
    void Start()
    {
        mainMusic.Post(listener, (uint)AkCallbackType.AK_MusicSyncUserCue, setWindow);
        //enemyPreAttack.Post(listener, (uint)AkCallbackType.AK_MusicSyncBeat, preAttack);
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            enemyInRange = true;
        }
        if (timesInRange == 3)
        {
            enemyInRange = false;
        }
    }

    public void preAttack (object in_cookie, AkCallbackType in_type, object in_info)
    {
        Debug.Log(debugNum);
        debugNum = debugNum + 1;

        if (enemyInRange == true)
        {
            enemyPreAttack.Post(listener);
            timesInRange = timesInRange + 1;
        }

    }
}
