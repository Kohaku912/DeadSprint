using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    [SerializeField] private Color crosshair_inactive = Color.white;
    [SerializeField] private Color crosshair_active = Color.green;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetCrosshairState(bool state)
    {
        crosshair.material.color = state ? crosshair_active : crosshair_inactive;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
