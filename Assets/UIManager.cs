using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel; // welcome Panel
    public GameObject[] infoPanels; // welcome Panel
    public Button tickButton;
    public Button untickButton;

    public Button leftButton;
    public Button rightButton;
    private int currentPanelIndex = 0;



    void Start()
    {
        welcomePanel.SetActive(true); // panel will be visible at start

    
    }

    public void DisablePanel()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        welcomePanel.SetActive(false); // Disable the panel when the continue button is clicked
        infoPanels[0].SetActive(true);

    }

    public void OnTickClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        tickButton.gameObject.SetActive(false);
        untickButton.gameObject.SetActive(true);
    }
    
    public void OnUnTickClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        tickButton.gameObject.SetActive(true);
        untickButton.gameObject.SetActive(false);
    }

    public void OnLeftClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        if (currentPanelIndex > 0)
        {
            infoPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex--;
            infoPanels[currentPanelIndex].SetActive(true);
        }

        // Update navigation buttons' state
        UpdateNavigationButtons();
    }

    public void OnRightClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        if (currentPanelIndex < infoPanels.Length - 1)
        {
            infoPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            infoPanels[currentPanelIndex].SetActive(true);
        }

        // Update navigation buttons' state
        UpdateNavigationButtons();
    }


    private void UpdateNavigationButtons()
    {
        // Disable left button if on the first panel, otherwise enable it
        leftButton.gameObject.SetActive(currentPanelIndex > 0);

        // Disable right button if on the last panel, otherwise enable it
        rightButton.gameObject.SetActive(currentPanelIndex < infoPanels.Length - 1);
    }

    public void OnInfoButtonClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        DisablePanel(); // Call the DisablePanel method to activate the panels
    }
    public void OnCancelButtonClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        // Disable all info panels
        foreach (GameObject panel in infoPanels)
        {
            panel.SetActive(false);
        }

    }
}
