using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputProvider
{
    private static PlayerInput input = new();

    public void Enable()
    {
        input.Player.Walk.Enable();
    }

    public void Disable()
    {
        input.Player.Walk.Disable();
    }

    /* Walk */
    public Vector2 Walk()
    {
        return input.Player.Walk.ReadValue<Vector2>();
    }

    /*
    /* Button 
    public event Action<InputAction.CallbackContext> GrabItem
    {
        // 觸發 Event 的三個時間段
        add
        {
            input.Player.Grab.started += value;
        }
        remove
        {
            input.Player.Grab.started -= value;
        }
    }

    public event Action<InputAction.CallbackContext> ThrowItem
    {
        // 觸發 Event 的三個時間段
        add
        {
            input.Player.Throw.started += value;
        }
        remove
        {
            input.Player.Throw.started -= value;
        }
    }

    public event Action<InputAction.CallbackContext> PauseMenu
    {
        // 觸發 Event 的三個時間段
        add
        {
            input.Player.Pause.started += value;
        }
        remove
        {
            input.Player.Pause.started -= value;
        }
    }
    */
}