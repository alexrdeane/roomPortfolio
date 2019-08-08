using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject clone;
    public Transform spawnPoint;
    void Start()
    {
        clone = bullet;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(clone, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
