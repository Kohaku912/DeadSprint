using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public bool CanInteract = true;
    private Camera _mainCam;
    private bool _interact;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
    }

    void UpdateControls()
    {
        if (CanInteract)
        {
            if (InputManager.instance.GetActionDown(InputManager.ActionName.Interact))
            {
                _interact = true;
            }
        }
    }
    
    void UpdateRaycast()
    {
        RaycastHit hit;
        bool valid = Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out hit, 2.0f);
        Interactable interactable = valid ? hit.transform.GetComponentInParent<Interactable>() : null;
        Item item = valid ? hit.transform.GetComponentInParent<Item>() : null;
        ItemSlot slot = valid ? hit.transform.GetComponentInParent<ItemSlot>() : null;
        
        Player.instance.hudController.SetCrosshairState(false);
        
        if (interactable != null)
        {
            Player.instance.hudController.SetCrosshairState(true);

            if (CanInteract)
            {
                if (_interact)
                {
                    interactable.OnInteract();
                }
            }
        }
        else if (item != null)
        {
            Player.instance.hudController.SetCrosshairState(true);

            if (CanInteract)
            {
                if (_interact)
                {
                    Player.instance.itemHandler.PickUpItem(item);
                }
            }
        }
        else if (slot != null)
        {
            Player.instance.hudController.SetCrosshairState(true);

            if (CanInteract)
            {
                if (_interact)
                {
                    Player.instance.itemHandler.InsertExtractItem(slot);
                }
            }
        }
        
        _interact = false;
    }

    void Update()
    {
        UpdateControls();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateRaycast();
    }
}
