using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject inGameMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void CloseInGameMenu()
    {
        inGameMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit.");
    }

    public void SelectLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level01")
        {
            SceneManager.LoadScene(2);
        }

        if (scene.name == "Level02")
        {
            SceneManager.LoadScene(3);
        }

        if (scene.name == "Level03")
        {
            Debug.Log("Game Complete.");
        }
    }
}
