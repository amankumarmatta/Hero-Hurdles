using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button replay, nextLevel, quit;

    private void Start()
    {
        replay.onClick.AddListener(Replay);
        nextLevel.onClick.AddListener(NextLevel);
        quit.onClick.AddListener(Quit);
    }

    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
