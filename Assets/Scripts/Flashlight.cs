using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    private bool isOn;
    private InventorySwitch inventorySwitch;

    void Start()
    {
        isOn = false;
        flashlight.SetActive(false);
        inventorySwitch = FindObjectOfType<InventorySwitch>();
    }

    void Update()
    {
        if (inventorySwitch.IsFlashlightActive())
        {
            if (!isOn && Input.GetButtonDown("Fire1"))
            {
                flashlight.SetActive(true);
                turnOn.Play();
                isOn = true;
            }
            else if (isOn && Input.GetButtonDown("Fire1"))
            {
                flashlight.SetActive(false);
                turnOff.Play();
                isOn = false;
            }
        }
    }
}
