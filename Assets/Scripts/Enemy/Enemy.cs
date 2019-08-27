using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Enemy : Aiming
{
    public Transform orb;
    public float curHealth = 100;
    public GameObject projectilePrefab;
    public int damage = 20;
    public ParticleSystem particlesSystem;
    public bool includeChildren = true;

    public Material enemyMaterialAim;
    public static float damageTimer = 0f;
    public float damageTimerMax = 0.85f;

    ParticleSystem system
    {
        get
        {
            if (particlesSystem == null)
                particlesSystem = GetComponent<ParticleSystem>();
            return particlesSystem;
        }
    }

    public void Start()
    {
        curHealth = 100;
        system.Stop(includeChildren, ParticleSystemStopBehavior.StopEmitting);
    }

    public void TakeDamage(int damage)
    {
        curHealth -= 20;
        system.Play(includeChildren);
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void Aim(Player p)
    {
        // Get orb to look at enemy
        orb.LookAt(p.transform);
        body.GetComponent<Renderer>().material = enemyMaterialAim;
        //gameObject.GetComponent<Enemy>().GetComponent<Renderer>().material.color = Color.red;
    }

    public override void Attack(Player p)
    {
        // Spawn projectile at position and rotation of player
        GameObject projectile = Instantiate(projectilePrefab);
        // Get Rigidbody from projectile
        Bullet bullet = projectile.GetComponent<Bullet>();
        bullet.Fire(orb.forward);
        projectile.transform.position = orb.position;
    }

    void OnTriggerStay(Collider collision)
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            if (damageTimer >= damageTimerMax)
            {
                enemy.TakeDamage(damage);
                damageTimer = 0;
            }
        }
    }
}