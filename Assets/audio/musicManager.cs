using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    [SerializeField] GameObject listener;

    [SerializeField] AK.Wwise.Event mainMusic;
    [SerializeField] AK.Wwise.Event mainMusic2;

    [SerializeField] AK.Wwise.Event mainBeat;
    public int cueCount = 0;
    public bool window = true;

    [SerializeField] AK.Wwise.Event enemyPreAttack;
    public bool enemyInRange = false;
    public int timesInRange = 0;
    [SerializeField] GameObject enemy;
    public int preAttackTarget = 0;

    uint callbackType = (uint)(AkCallbackType.AK_MusicSyncUserCue | AkCallbackType.AK_MusicSyncBeat);


    // Start is called before the first frame update
    void Start()
    {
        mainBeat.Post(listener, callbackType, callbackFunction);
        //mainMusic.Post(gameObject);
        mainMusic2.Post(gameObject);
    }


    public void callbackFunction (object in_cookie, AkCallbackType in_type, object in_info)
    {
        // set window cue
        if (in_type == AkCallbackType.AK_MusicSyncUserCue)
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
        
        // on beat cue
        if (in_type == AkCallbackType.AK_MusicSyncBeat)
        {
            if (enemyInRange == true)
            {
                enemyPreAttack.Post(enemy);
                timesInRange = timesInRange + 1;
            }

            if (timesInRange == 2)
            {
                preAttackTarget = cueCount + 4;
            }
        }
    }

    private void Update()
    {
        // managing enemy attack
        if(Input.GetKeyDown(KeyCode.Z))
        {
            enemyInRange = true;
        }

        if (timesInRange == 3)
        {
            enemyInRange = false;
            timesInRange = 0;
        }
    }

}
