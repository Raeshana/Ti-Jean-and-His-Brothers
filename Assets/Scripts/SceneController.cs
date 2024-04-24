using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GoToHowToPlay();
        }   

        if (Input.GetKeyDown(KeyCode.P))
        {
            GoToPauseMenu();
        }
        
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }       
    }

    [ContextMenu("Restart current level")]
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Go to how to play")]
    public void GoToHowToPlay()
    {
        if (SceneManager.loadedSceneCount <= 1f)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
        }
        else
        {
            UnloadHowToPlay();
        }
    }

    [ContextMenu("Unload How to play")]
    public void UnloadHowToPlay()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("HowToPlay");
    }

    [ContextMenu("Go to next level")]
    public void GoToNextLevel()
    {
        StartCoroutine(GoToNextLevelRoutine());
    }

    private IEnumerator GoToNextLevelRoutine()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(next, LoadSceneMode.Single);
    }

    [ContextMenu("Quit Game")]
    public void QuitGame()
    {
        Application.Quit();
    }

    [ContextMenu("Go to main menu")]
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    [ContextMenu("Pause")]
    public void GoToPauseMenu()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        if (current == 2 || current == 3) // game only pauses in levels
        {
            if (SceneManager.loadedSceneCount <= 1f) // checks if pause menu is already loaded
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
            else
            {
                UnloadPauseMenu();
            }
        }
    }

    [ContextMenu("Unload Pause")]
    public void UnloadPauseMenu()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    [ContextMenu("Go to credits screen")]
    public void GoToCreditsScreen()
    {
        SceneManager.LoadScene("CreditsScreen", LoadSceneMode.Single);
    }
}