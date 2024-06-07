using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBehaviour : MonoBehaviour
{
    [SerializeField] private ProjectileSpawnerBehaviour _projectileSpawner;

    [SerializeField] private float _shotSpeed;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = transform.root.GetComponentInChildren<Animator>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_projectileSpawner.Fire(transform.forward * _shotSpeed * Time.deltaTime))
        {
            if (_animator)
                _animator.SetTrigger("Hornet_Atk");
        }
    }
}
