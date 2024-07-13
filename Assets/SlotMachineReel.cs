using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotMachineReel : MonoBehaviour
{
    public List<Sprite> symbols; // Assign 12 symbol sprites in the Inspector
    public float spinDuration = 2f;
    public float spinSpeed = 1000f;
    public int visibleSymbols = 12;

    public float symbolWidth = 100f;
    public float symbolHeight = 100f;
    public float spacing = 10f;

    public Vector2 position1Offset = Vector2.zero; // Offset for Position1 GameObject

    private GameObject position1;
    private List<GameObject> reelObjects;
    private float totalSymbolHeight;
    private bool isSpinning = false;

    void Start()
    {
        InitializeReel();
    }

    void InitializeReel()
    {
        // Create Position1 GameObject
        position1 = new GameObject("Position1");
        position1.transform.SetParent(transform, false);
        RectTransform position1RectTransform = position1.AddComponent<RectTransform>();
        position1RectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        position1RectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        position1RectTransform.anchoredPosition = position1Offset;

        reelObjects = new List<GameObject>();
        totalSymbolHeight = symbolHeight + spacing;

        // Create symbols for the reel (visible + extra for smooth looping)
        for (int i = 0; i < visibleSymbols + 3; i++)
        {
            GameObject symbol = new GameObject("Symbol");
            symbol.transform.SetParent(position1.transform, false);
            RectTransform rectTransform = symbol.AddComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(symbolWidth, symbolHeight);
            symbol.AddComponent<UnityEngine.UI.Image>();
            reelObjects.Add(symbol);
        }

        // Adjust Position1 size
        position1RectTransform.sizeDelta = new Vector2(symbolWidth, totalSymbolHeight * visibleSymbols - spacing);

        ResetReelPosition();
        ShuffleSymbols();
    }

    void ResetReelPosition()
    {
        for (int i = 0; i < reelObjects.Count; i++)
        {
            reelObjects[i].transform.localPosition = new Vector3(0, i * totalSymbolHeight, 0);
        }
    }

    void ShuffleSymbols()
    {
        for (int i = 0; i < reelObjects.Count; i++)
        {
            int randomIndex = Random.Range(0, symbols.Count);
            reelObjects[i].GetComponent<UnityEngine.UI.Image>().sprite = symbols[randomIndex];
        }
    }

    public void Spin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinReel());
        }
    }

    IEnumerator SpinReel()
    {
        isSpinning = true;
        float elapsedTime = 0f;
        float startPosition = reelObjects[0].transform.localPosition.y;

        while (elapsedTime < spinDuration)
        {
            float delta = spinSpeed * Time.deltaTime;
            foreach (GameObject symbol in reelObjects)
            {
                symbol.transform.localPosition += Vector3.down * delta;

                if (symbol.transform.localPosition.y < -symbolHeight)
                {
                    symbol.transform.localPosition = new Vector3(0, reelObjects[reelObjects.Count - 1].transform.localPosition.y + symbolHeight, 0);
                    reelObjects.Remove(symbol);
                    reelObjects.Add(symbol);
                    break;
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the reel stops at a proper position
        float offset = reelObjects[0].transform.localPosition.y % symbolHeight;
        foreach (GameObject symbol in reelObjects)
        {
            symbol.transform.localPosition -= new Vector3(0, offset, 0);
        }

        isSpinning = false;
    }
}