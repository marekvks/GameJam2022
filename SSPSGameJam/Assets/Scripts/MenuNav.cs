using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;
    private List<GameObject> menuList = new List<GameObject>();
    private bool isInMain = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInMain)
        {
            ReturnToPrevMenu();
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnterCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(creditMenu);

        isInMain = false;
    }

    public void ReturnToPrevMenu()
    {
        menuList[0].SetActive(true);
        menuList[1].SetActive(false);
        menuList.Clear();

        isInMain = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
