using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject deathScene;
    public GameObject toBeContinued;
    public static bool isGamepaused = false;
    public GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;

    public void DeathScene()
    {
        deathScene.SetActive(!deathScene.activeSelf);
    }

    public void ToBeContinued()
    {
        toBeContinued.SetActive(true);
        Invoke("LoadMenu", 4f);
       
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamepaused == true)
            {
                Resume();
            }
            else

            {
                Pause();
            }
        }
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void OptionsOff()
    {
        optionsMenu.SetActive(false);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamepaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamepaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
