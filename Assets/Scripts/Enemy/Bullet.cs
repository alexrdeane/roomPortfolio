using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Travel speed of projectile
    private Rigidbody rigid; // Reference to rigidbody
    private int damage = 20;
    public GameObject bullet;
    public static bool bulletDeflected = false;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        bulletDeflected = false;

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
        if (collision.CompareTag("PlayerHurt"))
        {
            Player player = collision.transform.GetComponentInParent<Player>();
            player.TakeDamage(damage);
            Destroy(gameObject, 0.05f);
        }

        if (collision.CompareTag("Enemy"))
        {
            if (bulletDeflected == true)
            {
                Destroy(collision.gameObject);
                bulletDeflected = false;
            }
        }
    }
}