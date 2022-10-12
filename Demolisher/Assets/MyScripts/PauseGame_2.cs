using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame_2 : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
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
        pauseMUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;

    }
    void Pause()
    {
        pauseMUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
