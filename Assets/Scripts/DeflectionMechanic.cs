using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class DeflectionMechanic : MonoBehaviour
{
    public Collider col;
    public GameObject bullet;
    public GameObject clone;
    public bool bulletIn;
    public Transform spawnPoint;
    public GameObject activeBullet;
    public Animator anim;

    public GameObject projectilePrefab;
    public Transform orb;
    private int damage = 10;

    public void Deflect()
    {
        anim.Play("attack");
        if (bulletIn == true)
        {
            // Spawn projectile at position and rotation of player
            GameObject projectile = Instantiate(projectilePrefab);
            // Get Rigidbody from projectile
            Bullet bullet = projectile.GetComponent<Bullet>();
            bullet.Fire(orb.forward);

            projectile.transform.position = orb.position;
            //Instantiate(clone, spawnPoint);

            Destroy(activeBullet);
            Bullet.bulletDeflected = true;
        }

        bulletIn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player damages = other.GetComponentInChildren<Player>();

        if (bulletIn == true)
        {
            damages.TakeDamage(damage);
        }

        if (other.CompareTag("bullet"))
        {
            bulletIn = true;
            activeBullet = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            bulletIn = false;
        }
    }
}
