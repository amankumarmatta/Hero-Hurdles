using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button start, options, quit, back, yes, no;
    [SerializeField] private GameObject mainPanel, confirmationPanel, OptionsPanel;


    private void Start()
    {
        start.onClick.AddListener(StartButton);
        options.onClick.AddListener(OptionsButton);
        quit.onClick.AddListener(QuitButton);
        back.onClick.AddListener(BackButton);
        yes.onClick.AddListener(YesButton);
        no.onClick.AddListener(NoButton);
    }

    private void StartButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void OptionsButton()
    {
        mainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    private void QuitButton()
    {
        mainPanel.SetActive(false);
        confirmationPanel.SetActive(true);
    }
    
    private void BackButton()
    {
        OptionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void YesButton()
    {
        Application.Quit();
    }

    private void NoButton()
    {
        confirmationPanel.SetActive(false);
        mainPanel.SetActive(true); 
    }
}
