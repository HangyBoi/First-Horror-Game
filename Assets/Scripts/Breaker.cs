using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    public GameObject turnOnBreaker;

    //public AudioSource fuseSound;

    public bool inReach;

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            turnOnBreaker.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            turnOnBreaker.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach && Input.GetButtonDown("Interact"))
        {
            Light[] lights = FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.CompareTag("HouseLight"))
                {
                    light.enabled = true;
                }
            }
        }

    }

}
