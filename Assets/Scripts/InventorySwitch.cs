using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject handycam;
    private bool isFlashlightActive;
    private bool isHandycamActive;

    void Start()
    {
        flashlight.SetActive(false);
        handycam.SetActive(false);
        isFlashlightActive = false;
        isHandycamActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlashlightActive)
            {
                flashlight.SetActive(false);
                isFlashlightActive = false;
            }
            else
            {
                flashlight.SetActive(true);
                handycam.SetActive(false);
                isFlashlightActive = true;
                isHandycamActive = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isHandycamActive)
            {
                handycam.SetActive(false);
                isHandycamActive = false;
            }
            else
            {
                handycam.SetActive(true);
                flashlight.SetActive(false);
                isHandycamActive = true;
                isFlashlightActive = false;
            }
        }
    }

    public bool IsFlashlightActive()
    {
        return isFlashlightActive;
    }

    public bool IsHandycamActive()
    {
        return isHandycamActive;
    }
}
