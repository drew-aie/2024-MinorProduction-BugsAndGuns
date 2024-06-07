using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _health;

    [Space, Header("Death")]
    [SerializeField]
    private float _delayBeforeDeath = 2f;

    [SerializeField]
    private string _deathAnimationTriggerName = "";

    [Space]
    public UnityEvent OnDeath;

    private bool _alive = true;
    private Animator _animator;

    public float Health
    {
        get
        {
            return _health;
        }
    }

    public float MaxHealth { get => _maxHealth; }

    /// <summary>
    /// Subtracts the given damage value from the health
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;
    }

    private void Start()
    {
        _animator = transform.root.GetComponentInChildren<Animator>(true);
    }

    // Update is called once per frame
    void Update()
    {
        //If the object health is lower or equal to 0, destroy the object
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        if (!_alive) return;
        _alive = false;

        Debug.Log("Die");
        if (_animator && _deathAnimationTriggerName != "")
            _animator.SetTrigger(_deathAnimationTriggerName);
        Destroy(gameObject, _delayBeforeDeath);
    }
}

