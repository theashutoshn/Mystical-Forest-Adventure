using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrigger : MonoBehaviour
{
    public SlotMachineReel[] reels; // Assign all 5 reel objects in the Inspector
    //public Button spinButton; // Assign your spin button in the Inspector

    void Start()
    {
        // Add a listener to the spin button
        //spinButton.onClick.AddListener(SpinAllReels);
    }

    public void SpinAllReels()
    {
        foreach (SlotMachineReel reel in reels)
        {
            reel.Spin();
        }
    }
}
