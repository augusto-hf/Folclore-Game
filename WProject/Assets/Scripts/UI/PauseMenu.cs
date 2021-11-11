using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool InventoryActive = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject InventoryMenuUI;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                if (optionsMenuUI == true)
                {
                    BackOptionsMenu();
                }
                if(InventoryMenuUI == true)
                {
                    Resume();
                }
                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        InventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        InventoryActive = false;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void OptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackOptionsMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Fase_1");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
