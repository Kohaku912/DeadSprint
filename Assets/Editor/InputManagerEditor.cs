using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codice.Client.BaseCommands;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.InputSystem.Layouts;

[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        InputManager im = (InputManager) target;
        if (GUILayout.Button("Update Actions"))
        {
            if(im.inputMap == null)
                im.inputMap = new InputActionMap();
            
            im.inputMap = UpdateActions(im.inputMap);
            
            im.inputMap.Enable();
        }
    }

    private InputActionMap UpdateActions(InputActionMap inputMap)
    {
        InputActionMap bufferMap = new InputActionMap();
        
        List<InputAction> oldActions = new List<InputAction>(inputMap.actions);
        
        foreach (InputManager.AxisName a in Enum.GetValues(typeof(InputManager.AxisName)))
        {
            string axisname = InputManager.GetAxisNameString(a);

            InputAction action = oldActions.Find(action => action.ToString().Contains(axisname)); 
            if (action != null)
            {
                bufferMap.AddAction(action.name,
                    action.type,
                    null,
                    action.interactions,
                    action.processors,
                    null,
                    action.expectedControlType);
                foreach (var b in action.bindings)
                {
                    bufferMap.AddBinding(b);
                }
            }
            else
            {
                bufferMap.AddAction(axisname, InputActionType.Value).expectedControlType = "Axis";    
            }
        }
        foreach (InputManager.ActionName a in Enum.GetValues(typeof(InputManager.ActionName)))
        {
            string actionname = InputManager.GetActionNameString(a);
            
            InputAction action = oldActions.Find(action => action.ToString().Contains(actionname));
            if (action != null)
            {
                bufferMap.AddAction(action.name,
                    action.type,
                    null,
                    action.interactions,
                    action.processors,
                    null,
                    action.expectedControlType);
                foreach (var b in action.bindings)
                {
                    bufferMap.AddBinding(b);
                }
            }
            else
            {
                bufferMap.AddAction(actionname, InputActionType.Button);    
            }
        }

        return bufferMap;
    }
}
