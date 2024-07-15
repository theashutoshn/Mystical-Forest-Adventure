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
    private const float betIncrement = 0.10f; // Increment value

    

    void Start()
    {
        UpdateBetCountText();
        UpdateBalanceText();
        
    }

    
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

    
    void UpdateBetCountText()
    {
        betCountText.text = betCount.ToString("F2");
    }

    void UpdateBalanceText()
    {
        balanceText.text = (balanceAmount - betCount).ToString("F2");
    }
}
