using System.Collections;
using UnityEngine;

public class Handycam : MonoBehaviour
{
    public Light flashLight;
    public float flashDuration = 0.1f;
    public AudioSource cameraSound;

    private InventorySwitch inventorySwitch;

    private bool isFlashing;

    void Start()
    {
        inventorySwitch = FindObjectOfType<InventorySwitch>();
        flashLight.enabled = false;
        isFlashing = false;
    }

    void Update()
    {
        if (inventorySwitch.IsHandycamActive() && Input.GetButtonDown("Fire1") && !isFlashing)
        {
            StartCoroutine(FlashCoroutine());
        }
    }

    private IEnumerator FlashCoroutine()
    {
        isFlashing = true;

        cameraSound.Play();
        flashLight.enabled = true;

        yield return new WaitForSeconds(flashDuration);

        flashLight.enabled = false;
        isFlashing = false;

        ActivateTriggersAndDisableLights();
    }

    private void ActivateTriggersAndDisableLights()
    {
        Debug.Log("Photo event triggered");

        // Find and activate triggers
        GameObject[] triggersToActivate = GameObject.FindGameObjectsWithTag("AfterLightIsOff");

        foreach (GameObject trigger in triggersToActivate)
        {
            Collider triggerCollider = trigger.GetComponent<Collider>();
            if (triggerCollider != null)
            {
                triggerCollider.enabled = true;
                Debug.Log("Activated trigger: " + trigger.name);
            }
            else
            {
                Debug.LogWarning("No Collider found on trigger: " + trigger.name);
            }
        }

        // Find and disable lights
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            if (light.CompareTag("HouseLight"))
            {
                light.enabled = false;
            }
        }
    }

}

