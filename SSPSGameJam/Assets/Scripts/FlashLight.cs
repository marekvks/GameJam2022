using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLight : MonoBehaviour
{
    public TextMeshProUGUI percentText;
    public GameObject flashlight;
    private float maxCapacity = 60;
    private float battery = 60;
    private float percent;
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
                battery += 2;
            }
        }

        if (percent > 100)
        {
            battery = 60;
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

        PercentAndUI();
    }

    void PercentAndUI()
    {
        percent = Mathf.Round(battery / (maxCapacity / 100));
        PickUp.ChangeText(percentText, $"battery: { percent }%");
    }
}
