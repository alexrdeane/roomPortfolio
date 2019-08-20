using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Travel speed of projectile
    private Rigidbody rigid; // Reference to rigidbody
    private int damage = 10;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Destroy(gameObject, 1);
    }

    // Fire's this bullet in a given direction (using defined speed)
    public void Fire(Vector3 direction)
    {
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider collision)
    {
        Player damages = collision.GetComponentInChildren<Player>();
        DeflectionMechanic deflection = collision.GetComponentInChildren<DeflectionMechanic>();

        if (collision.transform.tag == "Player")
        {
            if (deflection.bulletIn == true)
            {
                damages.TakeDamage(damage);
            }
        }
    }
}