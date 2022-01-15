using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTrigger : MonoBehaviour
{

    public LayerMask collectables;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            Debug.Log("Press E");
        }
    }
}
