using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateTriggersAndDisableLights()
    {
        Debug.Log("ActivateTriggersAndDisableLights called!");

        // Disable lights with the "HouseLight" tag
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            if (light.CompareTag("HouseLight"))
            {
                light.enabled = false;
            }
        }

        GameObject[] triggersToActivate = GameObject.FindGameObjectsWithTag("AfterLightIsOff");
        foreach (GameObject trigger in triggersToActivate)
        {
            trigger.GetComponent<Collider>().enabled = true;
        }

    }
}
