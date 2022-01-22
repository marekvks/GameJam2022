using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject hint;

    public Animator animator;

    public static bool isNearbyList = false;
    public static bool isNearbyScientist = false;
    public static bool isNearbyKey = false;
    public static bool isNearbyGarage = false;

    public GameObject storageMonster;
    public GameObject labMonster;
    public GameObject garageMonster;
    public GameObject generatorMonster;

    private float randomNumber;

    private void Update()
    {
        if (FreezeGame.isPaused && (isNearbyList || isNearbyScientist))
        {
            hint.SetActive(false);
        } else if (!FreezeGame.isPaused && (isNearbyList || isNearbyScientist))
        {
            hint.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        randomNumber = Random.value;

        switch (collision.tag)
        {
            case "Collectables":
                isNearbyList = true;
                hint.SetActive(true);
                break;
            case "Scientists":
                isNearbyScientist = true;
                hint.SetActive(true);
                break;
            case "Keys":
                isNearbyKey = true;
                hint.SetActive(true);
                break;
            case "Garage Door":
                isNearbyGarage = true;
                hint.SetActive(true);
                break;
        }

        switch (collision.name)
        {
            case "GarageTrigger":
                garageMonster.SetActive(true);
                SlowMonster();
                break;
            case "LabTrigger":
                if (randomNumber >= 0.5f) 
                {
                    labMonster.SetActive(true);
                    SlowMonster();
                }
                break;
            case "StorageTrigger":
                if (randomNumber >= 0.66f) 
                {
                    storageMonster.SetActive(true);
                    SlowMonster();
                }
                break;
            case "GeneratorTrigger":
                if (randomNumber >= 0.66f)
                {
                    generatorMonster.SetActive(true);
                    SlowMonster();
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearbyList = false;
        isNearbyScientist = false;
        isNearbyKey = false;
        isNearbyGarage = false;
        animator.SetBool("hide", true);
    }

    private void SlowMonster()
    {
        MonsterAI.monsterSpeed = 4.8f;
        MonsterAI.time = 0f;
    }
}