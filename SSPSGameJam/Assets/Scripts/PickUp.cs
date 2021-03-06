using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    private char id;
    private GameObject list;
    private GameObject gameList;
    private List<char> tempList = new List<char>();
    private int maxListCount = 6;

    public TextMeshProUGUI scientistsSavedText;
    private GameObject scientist;
    private int savedScientists = 0;
    private int maxScientistCount = 6;
    

    private GameObject key;
    public static bool isKeyPickedUp = false;



    public GameObject endMenu;
    public GameObject trueEndMenu;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Trigger.isNearbyList)
        {
            list.SetActive(false);
            ListAssign();
        } else if (Input.GetKeyDown(KeyCode.E) && Trigger.isNearbyScientist)
        {
            scientist.SetActive(false);
            savedScientists += 1;
            ChangeText(scientistsSavedText, $"Scientists Saved: { savedScientists }");
        }
        else if (Input.GetKeyDown(KeyCode.E) && Trigger.isNearbyKey)
        {
            key.SetActive(false);
            isKeyPickedUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables") 
        { 
            list = collision.gameObject; 
        } else if (collision.tag == "Scientists") 
        { 
            scientist = collision.gameObject; 
        } else if (collision.tag == "Keys") 
        { 
            key = collision.gameObject; 
        }

        if (collision.name == "CameraTrigger")
        {
            if(tempList.Count == maxListCount && savedScientists == maxScientistCount)
            {
                trueEndMenu.SetActive(true);
            }
            else
            {
                endMenu.SetActive(true);
            }
            
        }
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

    public static void ChangeText(TextMeshProUGUI textObject, string message)
    {
        textObject.text = message;
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}