using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel; // welcome Panel
    public Button tickButton;
    public Button untickButton;

    void Start()
    {
        welcomePanel.SetActive(true); // panel will be visible at start

    
    }

    public void DisablePanel()
    {
        
        welcomePanel.SetActive(false); // Disable the panel when the continue button is clicked
    }

    public void OnTickClick()
    {
        tickButton.gameObject.SetActive(false);
        untickButton.gameObject.SetActive(true);
    }
    
    public void OnUnTickClick()
    {
        tickButton.gameObject.SetActive(true);
        untickButton.gameObject.SetActive(false);
    }
}
