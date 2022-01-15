using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public static bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenu.SetActive(true);
            Paused();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            Resume();
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && !isPaused)
        {
            inventoryMenu.SetActive(true);
            Paused();
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isPaused)
        {
            inventoryMenu.SetActive(false);
            Resume();
        }
    }

    void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }


}
