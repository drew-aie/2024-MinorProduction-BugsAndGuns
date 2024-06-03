using DG.Tweening.Plugins.Core.PathCore;
using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    [SerializeField] private PathCreator _pathCreator;

    private PathFollower _pathFollower;

    [SerializeField] private float _defaultSpawnInterval = 30f;

    [SerializeField] private float _currentSpawnInterval;

    private void Start()
    {
        _pathFollower = _enemy.GetComponent<PathFollower>();
        _pathFollower.pathCreator = _pathCreator;
    }

    private void Update()
    {
        _currentSpawnInterval -= Time.deltaTime;

        if (_currentSpawnInterval <= 0.000001f)
            StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        //Spawn the enemy.
        Instantiate(_enemy);

        //Wait until the spawn interval is up.
        yield return new WaitForSeconds(_currentSpawnInterval);


        //Reset the spawn timer.
        _currentSpawnInterval = _defaultSpawnInterval;

        //If the spawn interval is greater than 4 seconds, subtract 2 seconds.
        if (_defaultSpawnInterval >= 4.00000)
            _defaultSpawnInterval -= 2;
    }
}
