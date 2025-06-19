using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        IsGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        IsGrounded = true;
    }
}
