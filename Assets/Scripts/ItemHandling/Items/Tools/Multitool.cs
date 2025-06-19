using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multitool : Item
{
    [SerializeField] private AudioSource scanSound;

    private bool _isActivated;
    private float _scanState = 0.0f;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void OnUse()
    {
        base.OnUse();
        _scanState += Time.deltaTime * 2.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        _scanState = Mathf.Clamp01(_scanState);
        scanSound.volume = _scanState;
        scanSound.pitch = Mathf.Lerp(0.8f, 1.15f, _scanState);
        
        if (_scanState > 0.0f)
        {
            if(!scanSound.isPlaying)
                scanSound.Play();
        }
        else
        {
            if(scanSound.isPlaying)
                scanSound.Stop();
        }
        _scanState -= Time.deltaTime;
    }
}
