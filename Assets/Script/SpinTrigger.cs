using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrigger : MonoBehaviour
{
    public SlotMachineReel[] reels;

    void Start()
    {
        
    }

    public void SpinAllReels()
    {
        foreach (SlotMachineReel reel in reels)
        {
            reel.Spin();
        }
    }
}
