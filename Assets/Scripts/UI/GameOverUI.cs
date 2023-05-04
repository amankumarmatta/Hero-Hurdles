using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button restart;
    public Button quit;
    public Button mainMenu;

    private void Start()
    {
        restart.onClick.AddListener(RestartGame);
        quit.onClick.AddListener(Quit);
        mainMenu.onClick.AddListener(MainMenu);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void RestartGame()
    {
        int lastPlayedLevelIndex = PlayerPrefs.GetInt("LastPlayedLevelIndex");
        SceneManager.LoadScene(lastPlayedLevelIndex);
    }
}
