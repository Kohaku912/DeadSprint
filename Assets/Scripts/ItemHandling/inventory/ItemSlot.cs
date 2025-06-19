using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public bool IsInteractable = true;
    
    [SerializeField] private GameObject slotItemObject;
    private Item _slotItem;
    [SerializeField] private Transform itemSlotTransform;
    
    protected Item _itemInSlot;
    private bool _hasItem;
    
    // Start is called before the first frame update
    void Start()
    {
        _slotItem = slotItemObject.GetComponent<Item>();
        
        _itemInSlot = GetComponentInChildren<Item>();
        _hasItem = _itemInSlot != null;
    }

    public virtual bool InsertItem(Item item)
    {
        if (!IsInteractable)
            return false;
        
        if (_hasItem)
            return false;

        if (_slotItem.GetType() != item.GetType())
            return false;

        _itemInSlot = item;
        _itemInSlot.OnInsert(this);
        _itemInSlot.transform.SetParent(itemSlotTransform);
        _itemInSlot.transform.localPosition = Vector3.zero;
        _itemInSlot.transform.localRotation = Quaternion.identity;

        _hasItem = true;
        
        return true;
    }

    public Item ExtractItem()
    {
        if (!IsInteractable)
            return null;
        
        _itemInSlot?.OnExtract();
        Item item = _itemInSlot;
        _itemInSlot = null;
        
        if (_itemInSlot == null)
            _hasItem = false;
        
        return item;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
