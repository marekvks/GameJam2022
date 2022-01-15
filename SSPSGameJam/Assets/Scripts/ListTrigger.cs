using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTrigger : MonoBehaviour
{
    public GameObject hint;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables")
        {
            hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("hide", true);
    }
}
