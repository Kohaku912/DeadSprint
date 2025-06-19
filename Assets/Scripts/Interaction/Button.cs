using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, Interactable
{
    [SerializeField] private UnityEvent onInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnInteract()
    {
        onInteract.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
