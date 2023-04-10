using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] Character _character;
    public void MoveDirection( InputAction.CallbackContext context )
    {
        _character.MoveDirection = context.ReadValue<Vector2>();
    }
    public void SetAimDirection(InputAction.CallbackContext context)
    {
        if (Camera.main != null)
        _character.AimPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
