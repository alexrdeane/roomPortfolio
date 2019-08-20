using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 30;

    public void Start()
    {
        // Set health to whatever maxHealth is at start
        health = maxHealth;
    }

    // Call this function to make Player take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Enemy damages = collision.GetComponentInChildren<Enemy>();

        if (collision.transform.tag == "Enemy")
        {
            damages.TakeDamage(damage);
        }
    }
}