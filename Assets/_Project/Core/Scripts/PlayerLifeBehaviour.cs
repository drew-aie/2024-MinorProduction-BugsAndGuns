using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBehaviour : MonoBehaviour
{
    [SerializeField] private int _maxLives;

    [SerializeField] private int _remainingLives;

    private bool _isInvincible = false;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public int Lives
    {
        get
        {
            return _remainingLives;
        }
    }

    public float MaxLives { get => _maxLives; }

    //Subtract a life from the players remaining lives.
    public void LoseLife()
    {
        if (_isInvincible)
            return;

        _remainingLives--;

        StartCoroutine(InvincibilityTimer());

        if (_remainingLives < 0)
            _remainingLives = 0;
    }

    //Start a timer that gives the player short invincibility
    public IEnumerator InvincibilityTimer()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(2);
        _isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_isInvincible);
        //If the player has no lives remaining, destroy the player.
        if (_remainingLives <= 0)
        {
            _animator.SetBool("PlayerDeath", true);
            Destroy(gameObject);
        }
            
    }
}
