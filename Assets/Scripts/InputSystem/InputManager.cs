using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager
{
    public event Action<Vector2> OnHit;

    private GameControls gameControls;

    public InputManager()
    {
        gameControls = new GameControls();
        gameControls.Enable();
        gameControls.Player.Hit.performed += Hit;
    }

    private void Hit(InputAction.CallbackContext context)
    {
        TouchSimulation.Enable();
        Vector2 touchPosition = Touchscreen.current.position.ReadValue();

        Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        OnHit?.Invoke(touchPosition);
    }

    public void DisableInput()
    {
        gameControls.Disable();
    }

    private void EnableInput() 
    {
        gameControls.Enable();
    }
}
