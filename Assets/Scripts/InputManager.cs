using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public enum AxisName
    {
        Walk_ForwardBackward, Walk_LeftRight, LookUpDown, LookLeftRight,
    }

    public enum ActionName
    {
        Pause, Leave,
        Interact, UseItem, DropItem, StowItem, Jump, Crouch, View1, View2
    }
    
    [SerializeField]
    public InputActionMap inputMap;
    
    private void Awake()
    {
        instance = this;
        inputMap.Enable();
    }

    public static string GetActionNameString(ActionName a)
    {
        return a.ToString().ToLower();
    }
    
    public static string GetAxisNameString(AxisName a)
    {
        return a.ToString().ToLower();
    }
    
    public float GetAxis(AxisName axis)
    {
        return inputMap[GetAxisNameString(axis)].ReadValue<float>();
    }

    public bool GetActionDown(ActionName action)
    {
        return inputMap[GetActionNameString(action)].triggered;
    }
    
    public bool GetAction(ActionName action)
    {
        return inputMap[GetActionNameString(action)].IsPressed();
    }
}

