using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    
    public PlayerMovementController movementController { get; private set; }
    public PlayerInteractionController interactionController { get; private set; }
    public PlayerItemHandler itemHandler { get; private set; }
    public HUDController hudController { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        movementController = GetComponent<PlayerMovementController>();
        interactionController = GetComponent<PlayerInteractionController>();
        itemHandler = GetComponent<PlayerItemHandler>(); 
        hudController = FindObjectOfType<HUDController>();
    }

    public void DisablePlayer()
    {
        movementController.CanMove = false;
        interactionController.CanInteract = false;
    }

    public void EnablePlayer()
    {
        movementController.CanMove = true;
        interactionController.CanInteract = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
