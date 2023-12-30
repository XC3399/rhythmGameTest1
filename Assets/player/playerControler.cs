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
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if (gridManagerScript.gridUnits)
            {
                
            }
            if (musicManagerScript.window == true)
            {
                Debug.Log("in window");
            }
            else
            {
                Debug.Log("out window");
            }

            //Debug.Log("moving in A");
            
        }
    }
}
