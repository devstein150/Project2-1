using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mapbox.Utils;


public class InventorySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cursor;
    public AudioClip spawn_sound_effect;
    void Start()
    {
        Button inventoryButton = transform.Find("Viewport").Find("Content").Find("MagnoliaButton").GetComponent<Button>();
        TextMeshProUGUI quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
        quantity_text.text = UnityEngine.Random.Range(1, 9).ToString();
        inventoryButton.onClick.AddListener(OnPressTree0);

        inventoryButton = transform.Find("Viewport").Find("Content").Find("PalmButton").GetComponent<Button>();
        quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
        quantity_text.text = UnityEngine.Random.Range(1, 9).ToString();
        inventoryButton.onClick.AddListener(OnPressTree1);

        inventoryButton = transform.Find("Viewport").Find("Content").Find("PineButton").GetComponent<Button>();
        quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
        quantity_text.text = UnityEngine.Random.Range(1, 9).ToString();
        inventoryButton.onClick.AddListener(OnPressTree2);
    }

    void OnPressTree0()
    {
        if (SceneManager.GetActiveScene().name == "interaction_scene")
        {
            Button inventoryButton = transform.Find("Viewport").Find("Content").Find("MagnoliaButton").GetComponent<Button>();
            TextMeshProUGUI quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
            if (float.Parse(quantity_text.text) > 0)
            {
                cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
                SpawnTree("magnolia", cursor.position, true);
                quantity_text.text = (float.Parse(quantity_text.text) - 1).ToString();
                AudioSource.PlayClipAtPoint(spawn_sound_effect, Camera.main.transform.position);
            }
        }
    }
    void OnPressTree1()
    {
        if (SceneManager.GetActiveScene().name == "interaction_scene")
        {
            Button inventoryButton = transform.Find("Viewport").Find("Content").Find("PalmButton").GetComponent<Button>();
            TextMeshProUGUI quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
            if (float.Parse(quantity_text.text) > 0)
            {
                cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
                SpawnTree("palm", cursor.position, true);
                quantity_text.text = (float.Parse(quantity_text.text) - 1).ToString();
                AudioSource.PlayClipAtPoint(spawn_sound_effect, Camera.main.transform.position);
            }
        }
    }
    void OnPressTree2()
    {
        if (SceneManager.GetActiveScene().name == "interaction_scene")
        {
            Button inventoryButton = transform.Find("Viewport").Find("Content").Find("PineButton").GetComponent<Button>();
            TextMeshProUGUI quantity_text = inventoryButton.transform.Find("quantity_text").GetComponent<TextMeshProUGUI>();
            if (float.Parse(quantity_text.text) > 0)
            {
                cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
                SpawnTree("pine", cursor.position, true);
                quantity_text.text = (float.Parse(quantity_text.text) - 1).ToString();
                AudioSource.PlayClipAtPoint(spawn_sound_effect, Camera.main.transform.position);
            }
        }
    }

    public GameObject palm_tree_prefab;
    public GameObject pine_tree_prefab;
    public GameObject magnolia_tree_prefab;

    //public Mapbox.Unity.Location.EditorLocationProviderLocationLog script;
    //public TreeDataManager script;
    
    public void SpawnTree(string tree_type, Vector3 location, bool interaction)
    {
        print("spawnTree: " + tree_type + " " + location + " " + interaction);
        //Vector2d current_player_latlong = new Vector2d(LocationProvider.GetComponent<LocationInfo>().latitude, LocationProvider.GetComponent<LocationInfo>().longitude);//Mapbox.Unity.Location.AbstractLocationProvider._currentLocation;// EditorLocationProviderLocationLog.current_player_latlong;
        float varianceAmount = 0.0003f;
        Vector2d variance = new Vector2d(Random.Range(-varianceAmount, varianceAmount), Random.Range(-varianceAmount, varianceAmount));
        Vector2d latlong = SwitchModeButton.currentLocation + variance;

        GameObject new_tree;
        if (tree_type == "palm")
        {   
            new_tree = GameObject.Instantiate(palm_tree_prefab);
        }
        else if (tree_type == "pine")
        {
            new_tree = GameObject.Instantiate(pine_tree_prefab);
        }
        else if (tree_type == "magnolia")
        {
            new_tree = GameObject.Instantiate(magnolia_tree_prefab);
        }
        else
        {
            new_tree = GameObject.Instantiate(magnolia_tree_prefab);
        }
        new_tree.transform.SetPositionAndRotation(location, cursor.rotation * Quaternion.Euler(0, 0, 0));
        new_tree.transform.localScale -= new Vector3(0.9f, 0.9f, 0.9f);
        TreeDataManager.all_trees.Add(new TreeDatum(tree_type, latlong, 0.0f, 1.0f));
        print(latlong);
        print(TreeDataManager.all_trees.Count);
    }
    // Update is called once per frame
    void Update()
    {

    }
}