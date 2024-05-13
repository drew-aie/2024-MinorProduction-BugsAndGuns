using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Tooltip("The speed which the player can't pass")] private float _maxSpeed;
    [SerializeField, Tooltip("How fast the player reaches max speed")] private float _acceleration;

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
        //Move the player's RigidBody towards the movement input given
        _rigidBody.MovePosition(transform.position + _movementInput * _acceleration * Time.deltaTime);

        //Clamp velocity to _maxSpeed
        Vector3 velocity = _rigidBody.velocity;
        float newXSpeed = Mathf.Clamp(_rigidBody.velocity.x, -_maxSpeed, _maxSpeed);
        velocity.x = newXSpeed;
        _rigidBody.velocity = velocity;
    }
}
