using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    [SerializeField] private Transform hand;
    
    private Item _itemInHand;
    private bool _hasItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateControls()
    {
        if (InputManager.instance.GetAction(InputManager.ActionName.DropItem))
        {
            DropItem();
        }

        if (InputManager.instance.GetAction(InputManager.ActionName.UseItem))
        {
            UseItem();
        }
    }
    
    private void DropItem()
    {
        _itemInHand?.OnDrop();
        _itemInHand?.transform.SetParent(null);
        _itemInHand = null;
        _hasItem = false;
    }

    private void UseItem()
    {
        _itemInHand?.OnUse();
    }
    
    public void PickUpItem(Item item)
    {
        if (_hasItem || item == null)
            return;
        
        if(item.OnPickUp())
        {
            _itemInHand = item;
            _itemInHand.transform.SetParent(hand);
            _itemInHand.transform.localPosition = Vector3.zero;
            _itemInHand.transform.localRotation = Quaternion.identity;
            _hasItem = true;
        }
    }

    public void InsertExtractItem(ItemSlot slot)
    {
        if (_hasItem)
        {
            InsertItem(slot);
        }
        else
        {
            ExtractItem(slot);
        }
    }
    
    public void InsertItem(ItemSlot slot)
    {
        if (slot.InsertItem(_itemInHand))
        {
            _itemInHand = null;
            _hasItem = false;
        }
    }

    public void ExtractItem(ItemSlot slot)
    {
        Item slotItem = slot.ExtractItem();
        PickUpItem(slotItem);
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateControls();
    }
}
