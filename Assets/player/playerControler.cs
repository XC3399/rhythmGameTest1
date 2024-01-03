using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControler : MonoBehaviour
{
    private PlayerActionMap playerActionMap;
    private InputAction movement;

    public GameObject gridManagerObj;
    public gridManager gridManagerScript;

    public GameObject musicManagerObj;
    public musicManager musicManagerScript;

    public int attack2Time;
    
    private float raycastLength = 3;
    private RaycastHit outInfo;
    public GameObject currentTile;
    public string tileName;
    
    private void Awake()
    {   
        //using an instance of the player action map
        playerActionMap = new PlayerActionMap();
    }
    private void OnEnable()
    {
        movement.Enable();
        
        //cache the player movement refernce
        movement = playerActionMap.player.movement;
        movement.performed += moveCheck;
    }
    private void OnDisable()
    {
        movement.Disable();
    }
    void moveCheck(InputAction.CallbackContext value)
    {
        
        Debug.Log("moving");
    }

    
    
    
    private void Start()
    {
        //get grid manager script
        gridManagerScript = gridManagerObj.GetComponent<gridManager>();

        //get music manager script
        musicManagerScript = musicManagerObj.GetComponent<musicManager>();
    }

    private void Update()
    {
        //name of the current tile
        bool hit = Physics.Raycast(this.transform.position, Vector3.down, out outInfo, raycastLength);

        if (hit)
        {
            if (outInfo.transform.CompareTag("groundTile"))
            {
                tileName = outInfo.collider.gameObject.name;
                //currentTile = gridManagerScript.gridUnits[].name;
            }
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if (gridManagerScript.gridUnits)
            {
                
            }
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
            //every count if 2, +4 to wait a beat
            if (musicManagerScript.window == true && attack2Time < musicManagerScript.cueCount+4)
            {
                Debug.Log("2 in window");
                attack2Time = musicManagerScript.cueCount;
            }
            else
            {
                Debug.Log("2 out window");
            }
        }
    }
}
