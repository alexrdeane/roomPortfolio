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

    private void Start()
    {
        clone = bullet;
    }
    private void Update()
    {
        if (bulletIn == true)
        {
            Instantiate(clone, spawnPoint.position, spawnPoint.rotation);
            bulletIn = false;
        }
    }
}
