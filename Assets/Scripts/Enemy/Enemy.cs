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

    public ParticleSystem particlesSystem;
    public bool includeChildren = true;

    // Health Slider
    //public Slider healthBar;
    //public Canvas myCanvas;
    public Material enemyMaterialAim;

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
        // Get Slider
        //myCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        //healthBar = myCanvas.transform.Find("Slider").GetComponent<Slider>();
        curHealth = 100;
        //healthBar.value = Mathf.Clamp01(curHealth / 100);

        system.Stop(includeChildren, ParticleSystemStopBehavior.StopEmitting);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(orb.position, orb.position + orb.forward * 1000f);
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        //healthBar.value = Mathf.Clamp01(curHealth / 100);

        system.Play(includeChildren);

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<Player>().health -= damage;
            //p.TakeDamage(damage);
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
}