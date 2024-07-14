using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    public TextMeshProUGUI betCountText; // Reference to the Text component displaying the bet count
    public TextMeshProUGUI balanceText;

    private float betCount = 1.00f; // Variable to store the bet count
    private float balanceAmount = 10000.00f;
    private const float minBet = 0.10f; // Minimum bet
    private const float maxBet = 25.00f; // Maximum bet
    private const float betIncrement = 0.10f; // Increment value for each button press

    

    void Start()
    {
        
        // Initialize the bet count text
        UpdateBetCountText();
        UpdateBalanceText();
        
    }

    // Method to increase the bet count
    public void IncreaseBet()
    {
        if (betCount + betIncrement <= maxBet)
        {
            betCount += betIncrement;
            UpdateBetCountText();
            UpdateBalanceText();
            AudioManager.instance.PlayGeneralButtonSound();
        }
    }

    // Method to decrease the bet count
    public void DecreaseBet()
    {
        if (betCount - betIncrement >= minBet)
        {
            betCount -= betIncrement;
            UpdateBetCountText();
            UpdateBalanceText();
            AudioManager.instance.PlayGeneralButtonSound();
        }
    }

    // Method to update the bet count text
    void UpdateBetCountText()
    {
        betCountText.text = betCount.ToString("F2");
    }

    void UpdateBalanceText()
    {
        balanceText.text = (balanceAmount - betCount).ToString("F2");
    }
}
