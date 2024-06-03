using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBehaviour : MonoBehaviour
{
    [SerializeField] private ProjectileSpawnerBehaviour _projectileSpawner;

    [SerializeField] private float _shotSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _projectileSpawner.Fire(transform.forward * _shotSpeed);
    }
}
