using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button replay, nextLevel, quit, yes, no;
    [SerializeField] private GameObject quitPanel, winPanel;


    private void Start()
    {
        replay.onClick.AddListener(Replay);
        nextLevel.onClick.AddListener(LoadNextLevel);
        quit.onClick.AddListener(Quit);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No); 
    }

    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
