using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssetPreloader : MonoBehaviour
{
    public string assetsFolderName = "UIAssets"; // Folder name within Resources Folder
    public Image progressBarImage; // progress bar

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
            
            yield return StartCoroutine(LoadAsset(assetNames[i])); // Load the asset from Resources folder

            float progress = (i + 1) / (float)totalAssets; // ptogress bar update
            progressBarImage.fillAmount = progress;
            yield return null;
        }
        OnLoadingComplete();
    }

    private IEnumerator LoadAsset(string assetName)
    {
        
        ResourceRequest request = Resources.LoadAsync(assetName); // asset load from Resoruce folder
        yield return request;

        GameObject asset = request.asset as GameObject;
        if (asset != null)
        {
            Instantiate(asset);
        }
    }

    private void OnLoadingComplete()
    {
        //Debug.Log("Loading complete!");
        SceneManager.LoadScene(1);
    }
}
