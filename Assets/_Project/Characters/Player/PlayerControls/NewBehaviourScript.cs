using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Tooltip("The projectile spawner the player should currently be using")] private ProjectileSpawnerBehaviour _projectileSpawner;
    [SerializeField, Tooltip("How fast the player's projectiles should be going")] private float _shotSpeed;
    [SerializeField, Tooltip("The speed which the player can't pass")] private float _maxSpeed;
    [SerializeField, Tooltip("How fast the player reaches max speed")] private float _acceleration;

    private Rigidbody _rigidBody;
    private Vector3 _movementInput;
    private bool _isShooting = false;
    private State _currentState;

    enum State
    {
        IDLE,
        MOVING,
        ATTACKING,
        DYING
    };

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.action.ReadValue<Vector3>();
        _currentState = State.MOVING;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isShooting = true;
            _currentState = State.ATTACKING;
        }

        else if (context.canceled)
        {
            _isShooting = false;
        }
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

        //If the player is shooting and has a projectile spawner, fire bullets
        if (_isShooting && _projectileSpawner)
        {
            _projectileSpawner.Fire(transform.forward * _shotSpeed);
        }
    }
}