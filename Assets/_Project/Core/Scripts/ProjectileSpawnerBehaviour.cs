using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The GameObject to be used as a projectile, must have a ProjectileBehaviour attached.")]
    private GameObject _bullet;

    [SerializeField] private float _fireRate = 100f;
    private float _lastFireTime = 0f;

    /// <summary>
    /// Spawns a bullet and applies the given force.
    /// </summary>
    /// <param name="force"></param>
    public bool Fire(Vector3 force)
    {
        if (Time.time < _lastFireTime + (1 / (_fireRate / 60)))
            return false;

        //Spawn a new bullet
        GameObject firedBullet = Instantiate(_bullet, transform.position, transform.rotation);
        //Get a reference to the attached bullet script
        ProjectileBehaviour bulletScript = firedBullet.GetComponent<ProjectileBehaviour>();
        //If the script isn't null, move the projectile's position
        if (bulletScript)
            bulletScript.Rigidbody.AddForce(force, ForceMode.Impulse);

        _lastFireTime = Time.time;
        return true;
    }
}

