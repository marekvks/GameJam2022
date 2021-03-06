using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class FreezeGame : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public Animator pauseMenuAnimator;
    public Animator inventoryAnimator;
    public static bool isPaused = false;
    public static bool isInInventory = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInInventory && !isPaused)
        {
            Paused();
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isInInventory && isPaused) { Resume(); }
        if (Input.GetKeyDown(KeyCode.Tab) && !isPaused)
        {
            isInInventory = true;
            Paused();
            inventoryMenu.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Tab) && isPaused) { Resume(); }
    }
    void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        if (!isInInventory)
        {
            pauseMenuAnimator.SetBool("hide", true);
        }
        else
        {
            inventoryAnimator.SetBool("hide", true);
        }
        isInInventory = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMain()
    {
        Resume();
        pauseMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        Camera.main.gameObject.SetActive(false);
        EventSystem.current.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
