using UnityEngine;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{
    [SerializeField] private Button settings, resume, options, quit, yes, no, back;
    [SerializeField] private GameObject settingsPanel, optionsPanel, quitPanel;

    private bool isPaused = false;

    private void Start()
    {
        settings.onClick.AddListener(SettingsButton);
        resume.onClick.AddListener(Resume);
        options.onClick.AddListener(Options);
        quit.onClick.AddListener(Quit);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
        back.onClick.AddListener(Back);
        settingsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    private void SettingsButton()
    {
        isPaused = true;
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
    }

    private void Options()
    {
        Time.timeScale = 0f;
        optionsPanel.SetActive(true);
    }

    private void Quit()
    {
        Time.timeScale = 0f;
        quitPanel.SetActive(true);
    }

    private void Yes()
    {
        Application.Quit();
    }

    private void No()
    {
        quitPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void Back()
    {
        optionsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    void Update()
    {
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
}
