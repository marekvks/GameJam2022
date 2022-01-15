using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTrigger : MonoBehaviour
{
    public GameObject hint;

    public Animator animator;

    private bool isNearby = false;

    private void Update()
    {
        if (FreezeGame.isPaused && isNearby)
        {
            hint.SetActive(false);
        } else if (!FreezeGame.isPaused && isNearby)
        {
            hint.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables")
        {
            isNearby = true;
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearby = false;
        animator.SetBool("hide", true);
    }
}