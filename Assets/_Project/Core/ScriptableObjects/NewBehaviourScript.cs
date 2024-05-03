using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 _movementInput;
    private bool _jumpInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.action.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _jumpInput = context.action.ReadValue<float>() > 0;
    }

    private void Update()
    {
        Debug.Log(_jumpInput);
    }
}
