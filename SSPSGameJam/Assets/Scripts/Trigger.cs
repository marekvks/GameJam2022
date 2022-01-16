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
        if (collision.tag == "Collectables")
        {
            isNearbyList = true;
            hint.SetActive(true);
        } else if (collision.tag == "Scientists")
        {
            isNearbyScientist = true;
            hint.SetActive(true);
        } else if (collision.tag == "Keys")
        {
            isNearbyKey = true;
            hint.SetActive(true);
        }
        
        if (collision.name == "ReactorTrigger")
        {
            MonsterAI.isInReactor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearbyList = false;
        isNearbyScientist = false;
        isNearbyKey = false;
        animator.SetBool("hide", true);
    }
}