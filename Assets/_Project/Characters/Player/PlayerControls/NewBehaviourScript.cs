using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Tooltip("Player max speed")] private float _maxSpeed;
    [SerializeField, Tooltip("Player Acceleration")] private float _acceleration;

    private Rigidbody _rigidBody;
    private Vector3 _movementInput;

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.action.ReadValue<Vector3>();
    }

    private void Update()
    {
        Vector3 force = _movementInput * _acceleration * Time.deltaTime;
        _rigidBody.MovePosition(force);

        Debug.Log(_movementInput);
    }
}
