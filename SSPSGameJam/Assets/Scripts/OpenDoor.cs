using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private GameObject garageDoor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Trigger.isNearbyGarage && PickUp.isKeyPickedUp)
        {
            garageDoor.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Garage Door") { garageDoor = collision.gameObject; }
    }
}
