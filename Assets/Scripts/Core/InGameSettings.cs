using UnityEngine;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{
    [SerializeField] private Button settings;

    private void Start()
    {
        settings.onClick.AddListener(SettingsButton);   
    }

    private void SettingsButton()
    {
        
    }
}
