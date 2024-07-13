using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssetPreloader : MonoBehaviour
{
    public string assetsFolderName = "UIAssets"; // Folder name within Resources containing your assets
    public Image progressBarImage; // Reference to the UI Image for progress bar

    private string[] assetNames; // Array to store asset names

    private void Start()
    {
        LoadAssetNames();
        StartCoroutine(PreloadAssets());
    }

    private void LoadAssetNames()
    {
        Object[] assets = Resources.LoadAll(assetsFolderName);
        assetNames = new string[assets.Length];
        for (int i = 0; i < assets.Length; i++)
        {
            assetNames[i] = assets[i].name;
        }
    }

    private IEnumerator PreloadAssets()
    {
        int totalAssets = assetNames.Length;
        for (int i = 0; i < totalAssets; i++)
        {
            // Load the asset from Resources folder
            yield return StartCoroutine(LoadAsset(assetNames[i]));

            // Update the progress bar
            float progress = (i + 1) / (float)totalAssets;
            progressBarImage.fillAmount = progress;

            // Wait for a frame to update the UI
            yield return null;
        }

        // Loading complete, proceed to the next step (e.g., loading the main scene)
        OnLoadingComplete();
    }

    private IEnumerator LoadAsset(string assetName)
    {
        // Load the asset from Resources
        ResourceRequest request = Resources.LoadAsync(assetName);
        yield return request;

        // Optionally handle the loaded asset (e.g., instantiate if it's a prefab)
        GameObject asset = request.asset as GameObject;
        if (asset != null)
        {
            // For example, instantiate the asset if it's a prefab
            Instantiate(asset);
        }
    }

    private void OnLoadingComplete()
    {
        // Proceed to the next scene or gameplay
        Debug.Log("Loading complete!");
        SceneManager.LoadScene(1);
    }
}
