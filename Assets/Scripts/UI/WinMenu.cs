using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button replay, nextLevel, quit, yes, no;
    [SerializeField] private GameObject quitPanel, winPanel;

    private int nextLevelIndex;


    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("LastPlayedLevelIndex", nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void Start()
    {
        replay.onClick.AddListener(Replay);
        nextLevel.onClick.AddListener(LoadNextLevel);
        quit.onClick.AddListener(Quit);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
        nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   

    private void Quit()
    {
        winPanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    private void Yes()
    {
        Application.Quit();
    }

    private void No()
    {
        quitPanel.SetActive(false);
        winPanel.SetActive(true);
    }
}
