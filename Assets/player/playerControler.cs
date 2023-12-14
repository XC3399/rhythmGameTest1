using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControler : MonoBehaviour
{
    private PlayerActionMap playerActionMap;
    private InputAction movement;

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
}
