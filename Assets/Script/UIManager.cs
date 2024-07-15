using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel; // welcome Panel
    public GameObject[] infoPanels; // info Panel
    public Button tickButton;
    public Button untickButton;

    public Button leftButton;
    public Button rightButton;
    private int currentPanelIndex = 0;



    void Start()
    {
        welcomePanel.SetActive(true);    
    }

    public void DisableWelcomPanel()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        welcomePanel.SetActive(false); // Disable the panel when continue button is clicked
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

        UpdateNavigationButtons();
    }


    private void UpdateNavigationButtons()
    {
        
        leftButton.gameObject.SetActive(currentPanelIndex > 0); // Disable left button on 1st panel
        rightButton.gameObject.SetActive(currentPanelIndex < infoPanels.Length - 1); // Enable right button last panel
    }

    public void OnInfoButtonClick()
    {
        AudioManager.instance.PlayGeneralButtonSound();
        DisableWelcomPanel(); // Call the Disable welcom panel method to activate the info panels
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
