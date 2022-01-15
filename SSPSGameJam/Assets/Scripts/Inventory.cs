using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject selectionMenu;
    public GameObject partMenu;
    private GameObject tempPart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FreezeGame.isInInventory)
        {
            tempPart.SetActive(false);
            partMenu.SetActive(false);
            selectionMenu.SetActive(true);
        }
    }
    public void OnClick(GameObject fullText)
    {
        tempPart = fullText;
        selectionMenu.SetActive(false);
        partMenu.SetActive(true);
        tempPart.SetActive(true);

    }
}