using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
}
