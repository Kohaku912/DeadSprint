using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Rigidbody _rigidbody;

    private ItemSlot _slot;
    private bool _slotted = false;
    
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnUse()
    {
        
    }
    
    public virtual bool OnPickUp()
    {
        if (_slotted && !TryExtract())
            return false;
        
        _rigidbody.isKinematic = true;
        _rigidbody.detectCollisions = false;
        _slotted = false;
        return true;
    }
    
    public virtual void OnDrop()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.detectCollisions = true;
        _slotted = false;
    }

    public virtual void OnInsert(ItemSlot slot)
    {
        _rigidbody.isKinematic = true;
        _rigidbody.detectCollisions = true;
        _slot = slot;
        _slotted = true;
    }

    protected virtual bool TryExtract()
    {
        return _slot.ExtractItem() != null;
    }
    
    public virtual void OnExtract()
    {
        _slotted = false;
        _slot = null;
    }
    
    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
