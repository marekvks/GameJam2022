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
    public GameObject playMenu;
    public GameObject customOptions;
    public GameObject main;
    public static string currentDifficulty;

    public Animator animator;

    private List<GameObject> menuList = new List<GameObject>();

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape) && !isInMain)
    //    {
    //        ReturnToPrevMenu();
    //    }
    //}

    public void ReturnButton(string identifier)
    {
        currentDifficulty = identifier;
    }

    public void Transition()
    {
        animator.SetTrigger("menuTransition");
    }

    public void BeginGame()
    {
        Camera.main.gameObject.SetActive(false);
        EventSystem.current.gameObject.SetActive(false);
        main.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DifficultyOptions()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(playMenu);
    }

    public void EnterCustomOptions()
    {
        playMenu.SetActive(false);
        customOptions.SetActive(true);
        menuList.Add(playMenu);
        menuList.Add(customOptions);
    }

    public void EnterCredits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
        menuList.Add(mainMenu);
        menuList.Add(creditMenu);

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
        menuList[menuList.Count - 2].SetActive(true);
        menuList[menuList.Count - 1].SetActive(false);
    }

    public void ReturnToMain()
    {
        playMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
