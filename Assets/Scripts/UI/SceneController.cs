using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [ContextMenu("Restart current level")]
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

        yield return new WaitForSeconds(0.3f);

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

    [ContextMenu("Go to how to play")]
    public void GoToHowToPlay()
    {
        if (SceneManager.loadedSceneCount <= 1f) // checks if menu is already loaded
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
        }
        else if (SceneManager.GetSceneByName("HowToPlay").isLoaded) // menu loaded is HowToPlay
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

    [ContextMenu("Pause")]
    public void GoToPauseMenu()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        if (current == 1 || current == 3) // game only pauses in levels
        {
            if (SceneManager.loadedSceneCount <= 1f) // checks if menu is already loaded
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            }
            else if (SceneManager.GetSceneByName("PauseMenu").isLoaded) // menu loaded is PauseMenu
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

    [ContextMenu("Go to Credits Screen")]
    public void GoToCreditsScreen()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.loadedSceneCount <= 1f) // checks if menu is already loaded
        {
            SceneManager.LoadScene("CreditsScreen", LoadSceneMode.Additive);
        }
        else if (SceneManager.GetSceneByName("CreditsScreen").isLoaded) // menu loaded is CreditsScreen
        {
            UnloadCreditsScreen();
        }
    }

    [ContextMenu("Unload Credits Screen")]
    public void UnloadCreditsScreen()
    {
        SceneManager.UnloadSceneAsync("CreditsScreen");
    }
}