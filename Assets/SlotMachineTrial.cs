using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineTrial : MonoBehaviour
{
    public RectTransform reelFrame; // Assign the RectTransform of the Reel Frame
    public GameObject[] slotImages; // Assign the Slot Image GameObjects
    public float spinSpeed = 500f; // Speed of the spin
    public float spinDuration = 2f; // Duration of the spin

    private bool isSpinning = false;
    private int visibleImages = 3; // Number of visible images at a time

    void Start()
    {
        InitializeReel();
    }

    public void SpinReel()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinReelCoroutine());
        }
    }

    private IEnumerator SpinReelCoroutine()
    {
        isSpinning = true;
        float timer = 0f;

        while (timer < spinDuration)
        {
            for (int i = 0; i < slotImages.Length; i++)
            {
                RectTransform rt = slotImages[i].GetComponent<RectTransform>();
                rt.anchoredPosition -= new Vector2(0, spinSpeed * Time.deltaTime);

                if (rt.anchoredPosition.y <= -reelFrame.rect.height)
                {
                    rt.anchoredPosition += new Vector2(0, slotImages.Length * rt.rect.height);
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }

        isSpinning = false;
    }

    private void InitializeReel()
    {
        float imageHeight = 1034 / visibleImages;
        for (int i = 0; i < slotImages.Length; i++)
        {
            RectTransform rt = slotImages[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(reelFrame.rect.width, imageHeight);
            rt.anchoredPosition = new Vector2(0, -i * imageHeight);
        }
    }
}
