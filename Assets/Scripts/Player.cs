using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 30;
    public float damageTimer = 0f;
    public float damageTimerMax = 0.85f;

    public void Start()
    {
        // Set health to whatever maxHealth is at start
        health = maxHealth;
    }

    public void Update()
    {
        damageTimer += Time.deltaTime;
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

    void OnTriggerStay(Collider collision)
    {
        Player damages = collision.GetComponentInChildren<Player>();
        if (collision.CompareTag("Enemy"))
        {
            if (damageTimer >= damageTimerMax)
            {
                TakeDamage(damage);
                damageTimer = 0;
            }
        }
    }
}