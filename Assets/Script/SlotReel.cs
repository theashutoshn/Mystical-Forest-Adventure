using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotReel : MonoBehaviour
{
    public Image[] reelImages; // Array to hold the reel Image components
    public Sprite[] slotSymbols; // Array to hold the symbols for the slot machine
    public float spinDuration = 5f; // Duration of the spin in seconds
    public float spinSpeed = 500f; // Speed of the reel spin

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpinReels());

        }
    }

    private IEnumerator SpinReels()
    {
        float elapsedTime = 0f;

        // Randomize the initial symbols on the reels
        for (int i = 0; i < reelImages.Length; i++)
        {
            reelImages[i].sprite = slotSymbols[Random.Range(0, slotSymbols.Length)];
        }

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;

            // Spin each reel independently
            for (int i = 0; i < reelImages.Length; i++)
            {
                SpinReel(reelImages[i]);
            }

            yield return null;
        }

        // Stop the reels and set final symbols
        for (int i = 0; i < reelImages.Length; i++)
        {
            reelImages[i].sprite = slotSymbols[Random.Range(0, slotSymbols.Length)];
        }
    }

    private void SpinReel(Image reelImage)
    {
        // Calculate the new position for the reel image
        Vector3 newPosition = reelImage.transform.position;
        newPosition.y -= spinSpeed * Time.deltaTime;

        // Reset position if the reel image moves out of view
        if (newPosition.y < -reelImage.rectTransform.sizeDelta.y)
        {
            newPosition.y += reelImage.rectTransform.sizeDelta.y * reelImages.Length;
            reelImage.sprite = slotSymbols[Random.Range(0, slotSymbols.Length)];
        }

        reelImage.transform.position = newPosition;
    }
}
