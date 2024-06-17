using DG.Tweening.Plugins.Core.PathCore;
using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    [SerializeField] private PathCreator _pathCreator;

    [SerializeField] private float _defaultSpawnInterval = 30f;

    [SerializeField] private float _defaultDespawnInterval = 3f;

    private PathFollower _pathFollower;

    private float _despawnTimer;

    private float _currentSpawnInterval;

    private GameObject _newEnemy;

    private void Update()
    {
        _currentSpawnInterval -= Time.deltaTime;

        if (_currentSpawnInterval <= 0.000001f)
            StartCoroutine(SpawnEnemy());

        _despawnTimer -= Time.deltaTime;
    }

    public IEnumerator SpawnEnemy()
    {
        //Spawn the enemy.
        _newEnemy = Instantiate(_enemy);

        _pathFollower = _newEnemy.GetComponent<PathFollower>();
        _pathFollower.pathCreator = _pathCreator;

        //Wait until the spawn interval is up.
        yield return new WaitForSeconds(_currentSpawnInterval);


        //Reset the spawn timer.
        _currentSpawnInterval = _defaultSpawnInterval;

        //If the spawn interval is greater than or equal to 5 seconds, subtract 2 seconds.
        if (_defaultSpawnInterval >= 5.00000)
            _defaultSpawnInterval -= 2;

        //If the despawn timer ends, despawn the previously spawned enemy.
        if (_despawnTimer <= 0.000001f)
            DespawnEnemy(_enemy);
    }

    public void DespawnEnemy(GameObject enemy)
    {
        Destroy(enemy);

        //Reset the despawn timer.
        _despawnTimer = _defaultDespawnInterval;
    }
}
