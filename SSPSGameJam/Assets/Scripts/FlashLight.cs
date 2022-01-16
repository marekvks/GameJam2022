using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashlight;
    private float battery = 60;
    private bool isFlashlightOn = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (isFlashlightOn)
            {
                case false:
                    isFlashlightOn = true;
                    flashlight.SetActive(true);
                    break;
                case true:
                    isFlashlightOn = false;
                    flashlight.SetActive(false);
                    break;
            }
        } else if (Input.GetMouseButtonDown(1))
        {
            if (!isFlashlightOn)
            {
                if (battery >= 60)
                {
                    battery = 60;
                } else
                { 
                    battery += 2;
                }
            }
        }

        if (isFlashlightOn)
        {
            if (battery <= 0)
            {
                isFlashlightOn = false;
                flashlight.SetActive(false);
                battery = 0;
            } else
            { 
                battery -= Time.deltaTime;
            }
        }

        Debug.Log(battery);
    }
}
