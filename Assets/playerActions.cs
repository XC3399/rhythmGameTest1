using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{
    [SerializeField] GameObject musicManagerObj;
    [SerializeField] musicManager musicManagerScript;

    public int attack2Time;

    [SerializeField] AK.Wwise.Event preAttackEnd;

    // Start is called before the first frame update
    void Start()
    {
        //get music manager script
        musicManagerScript = musicManagerObj.GetComponent<musicManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (musicManagerScript.window == true)
            {
                Debug.Log("1 in window");
            }
            else
            {
                Debug.Log("1 out window");
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //every count is 2, +4 to wait a beat, -1
            if (musicManagerScript.window == true && attack2Time + 3 < musicManagerScript.cueCount)
            {
                //Debug.Log(musicManagerScript.cueCount);
                Debug.Log("2 in window");
                attack2Time = musicManagerScript.cueCount;

            }
            else
            {
                Debug.Log("2 out window");
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) == true | Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            Debug.Log(musicManagerScript.cueCount);

            if (musicManagerScript.preAttackTarget == musicManagerScript.cueCount)
            {
                Debug.Log("started combat");
                preAttackEnd.Post(gameObject);
            }
        }
    }
}
