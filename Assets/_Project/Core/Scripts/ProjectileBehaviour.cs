 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [Tooltip("How much damage this bullet will do.")]
    [SerializeField]
    private float _damage;

    [Tooltip("The amount of time it takes for this bullet to despawn after being fired.")]
    [SerializeField]
    private float _despawnTime;

    [Tooltip("This bullet will not hurt anything with this tag")]
    [SerializeField]
    private string _tag;

    public Rigidbody Rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    private void Awake()
    {
        //Get a reference to this object's rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Destroy this object once after enough time has passed
        Destroy(gameObject, _despawnTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tag)
            return;

        //Grab the health or life behaviour attached to the object
        HealthBehaviour health = other.GetComponent<HealthBehaviour>();
        PlayerLifeBehaviour lives = other.GetComponent<PlayerLifeBehaviour>();

        //If the health behaviour isn't null, deal damage
        if (health)
            health.TakeDamage(Damage);

        //If the life behaviour isn't null, subtract a life
        if (lives)
            lives.LoseLife();
    }
}