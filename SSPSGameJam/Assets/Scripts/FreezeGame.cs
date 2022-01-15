using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public Animator pauseMenuAnimator;
    public static bool isPaused = false;
    public static bool isInInventory = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInInventory)
        {
            pauseMenu.SetActive(!isPaused);
            if (isPaused) { pauseMenuAnimator.SetBool("hide", true); Resume(); } else { Paused(); }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInInventory = true;
            inventoryMenu.SetActive(!isPaused);
            if (isPaused) { Resume(); } else { Paused(); }
        }
    }
    void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isInInventory = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    

}
