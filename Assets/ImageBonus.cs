using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageBonus : MonoBehaviour
{
    static bool bonusReceived = false;
    ARTrackedImageManager trackedImageManager;
    public GameObject treePrefab;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        //trackedImageManager = FindObjectOfType<ARSessionOrigin>().GetComponent<ARTrackedImageManager>();
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    void OnEnable() => trackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => trackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Handle added event
            if(bonusReceived == false)
            {
                bonusReceived = true;
                MoneyManager mm = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
                mm.IncreaseMoney(100.0f);
            }
            UpdateImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            // Handle updated event
            UpdateImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            // Handle removed event

        }
    }
    void UpdateImage(ARTrackedImage trackedImage)
    {
        Vector3 position = trackedImage.transform.position;
        GameObject tree = Instantiate(treePrefab);
        tree.transform.position = position;
        tree.transform.Rotate(90, 0, 0);
        tree.transform.localScale -= new Vector3(0.9f, 0.9f, 0.9f);
    }
}
