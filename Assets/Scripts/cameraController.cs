using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject virtualCamera;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            virtualCamera.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            virtualCamera.SetActive(false);
        }
    }
}
