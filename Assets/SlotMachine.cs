using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    public RectTransform reelFrame; // Assign the RectTransform of the Reel Frame
    public GameObject[] slotImages; // Assign the Slot Image GameObjects
    public float spinSpeed = 5f; // Speed of the spin
    public float spinDuration = 2f; // Duration of the spin

    private bool isSpinning = false;

    void Start()
    {
        // Initialize the positions of the slot images
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

    // private void InitializeReel()
    // {
    //     float imageHeight = reelFrame.rect.height / slotImages.Length;
    //     for (int i = 0; i < slotImages.Length; i++)
    //     {
    //         RectTransform rt = slotImages[i].GetComponent<RectTransform>();
    //         rt.sizeDelta = new Vector2(reelFrame.rect.width, imageHeight);
    //         rt.anchoredPosition = new Vector2(0, -i * imageHeight);
    //     }
    // }

    private void InitializeReel()
{
    int rows = 3; // Number of rows
    int columns = 5; // Number of columns

    float imageHeight = reelFrame.rect.height / rows;
    float imageWidth = reelFrame.rect.width / columns;

    for (int i = 0; i < slotImages.Length; i++)
    {
        RectTransform rt = slotImages[i].GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(imageWidth, imageHeight);

        // Calculate the row and column position
        int row = i % rows;
        int column = i / rows;

        rt.anchoredPosition = new Vector2(column * imageWidth, -row * imageHeight);
    }
}

}
