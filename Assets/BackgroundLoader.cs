using UnityEngine;
using Spine.Unity;

public class BackgroundLoader : MonoBehaviour
{
    public SkeletonDataAsset skeletonDataAsset;

    void Start()
    {
        if (skeletonDataAsset == null)
        {
            Debug.LogError("Skeleton Data Asset is not assigned.");
            return;
        }

        GameObject background = new GameObject("Background");
        SkeletonAnimation skeletonAnimation = background.AddComponent<SkeletonAnimation>();
        skeletonAnimation.skeletonDataAsset = skeletonDataAsset;
        skeletonAnimation.Initialize(true);

        background.transform.position = Vector3.zero; // Adjust as needed
    }
}
