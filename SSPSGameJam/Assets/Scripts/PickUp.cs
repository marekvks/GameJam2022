using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private char id;
    private GameObject list;
    private GameObject gameList;
    private List<char> tempList = new List<char>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Trigger.isNearby)
        {
            list.SetActive(false);
            ListAssign();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables") { list = collision.gameObject; }
    }


    private void ListAssign()
    {
        foreach(char c in list.name)
        {
            tempList.Add(c);
        }
        id = tempList[tempList.Count - 1];
        tempList.Clear();

        gameList = GameObject.Find("Game/UI/Inventory/Selection/Part" + id);
        Debug.Log(gameList.name);
        gameList.SetActive(true);
    }
}