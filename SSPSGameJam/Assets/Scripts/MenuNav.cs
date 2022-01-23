using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuNav : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;
    public GameObject optionsMenu;
    public GameObject main;

    private List<GameObject> menuList = new List<GameObject>();
    private bool isInMain = false;

    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInMain)
        {
            ReturnToPrevMenu();
        }
    }

    public void BeginGame()
    {
        Camera.main.gameObject.SetActive(false);
        EventSystem.current.gameObject.SetActive(false);
        main.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTransition()
    {
        animator.SetTrigger("transition");
    }

    public void EnterCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(creditMenu);

        isInMain = false;
    }

    public void EnterOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(optionsMenu);
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
