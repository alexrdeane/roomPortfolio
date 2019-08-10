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

    private void Start()
    {
        clone = bullet;
    }

    public void Deflect()
    {
        anim.Play("attack");
        if (bulletIn == true)
        {
            Instantiate(clone, spawnPoint);
            Destroy(activeBullet);
        }
        bulletIn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
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
