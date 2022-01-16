using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNav : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditMenu;
    private List<GameObject> menuList = new List<GameObject>();

    public void BeginGame()
    {

    }

    public void EnterOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(optionsMenu);
    }

    public void EnterCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(creditMenu);
    }

    public void ReturnToPrevMenu()
    {
        menuList[0].SetActive(true);
        menuList[1].SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
