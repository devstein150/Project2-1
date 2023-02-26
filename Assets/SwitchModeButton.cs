using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using TMPro;
using UnityEngine.UI;

public class SwitchModeButton : MonoBehaviour
{
    public float spawnTime = 10.0f; // spawn every 40 seconds

    private int update_tree_num = 0;
    public Vector3 offset;
    GameObject[] Trees_array;

    public GameObject gameplay_canvas;

    public GameObject Squirrel__Object;

    static GameObject gameplay_canvas_instance;

    public GameObject switchModeButton;

    public GameObject playerTarget;

    public string what_to_spawn;
    public List<GameObject> Squirrels;

    public List<GameObject> Trees;

    public GameObject interactionScene;

    public static Vector2d currentLocation;
    GameObject character;

    public AbstractMap map;
    public void Start()
    {
        InvokeRepeating("SquirrelSpawn", spawnTime, spawnTime);

        if (gameplay_canvas_instance == null)
        {
            gameplay_canvas_instance = gameplay_canvas;
            DontDestroyOnLoad(gameplay_canvas);

        }
        else
        {
            Destroy(gameplay_canvas);
        }
        character = GameObject.Find("PlayerTarget");
    }

    
    public void OnSwitchButtonPressed()
    {
        //Debug.Log("BUTTON PRESSED");
        if(SceneManager.GetActiveScene().name == "interaction_scene")
        {   // interaction to exploration
            SceneManager.LoadScene("exploration_scene");
            TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText("Interact");
        }
        else if (SceneManager.GetActiveScene().name == "exploration_scene")
        { // exploration to interaction
            TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText("Explore");
            character = GameObject.Find("PlayerTarget");
            map = GameObject.Find("Map").GetComponent<AbstractMap>();
            Vector2d tempLocation = map.WorldToGeoPosition(character.transform.position);
            currentLocation = new Vector2d(tempLocation.x, tempLocation.y);
            SceneManager.LoadScene("interaction_scene");

            /*foreach (GameObject Tree in Trees)
            {
                //Debug.Log("DO WE GET HERE?2132??");

                Vector3 diff = Tree.transform.position - playerTarget.transform.position;

                SceneManager.LoadScene("interaction_scene");

                if (diff.sqrMagnitude < 200000.0f)
                {
                    Debug.Log("DO WE NOT GET HERE>>>>");

                    
                    TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
                    text.SetText("Explore");
                    Vector2d tempLocation = map.WorldToGeoPosition(character.transform.position);
                    currentLocation = new Vector2d(tempLocation.x, tempLocation.y);
                    DontDestroyOnLoad(Tree);
                   // DontDestroyOnLoad(currentLocation);

                    Debug.Log("DO WE GET HERE???");
                    GameObject Spawner = GameObject.Find("SpawnTree");
                    Spawner.GetComponent<SpawnableManager>().what_to_spawn = Tree;
                    Spawner.GetComponent<SpawnableManager>().areyougettingthis = "NO";
                    Debug.Log("DO WE GET HEREeqw???");

                    Spawner.GetComponent<SpawnableManager>().Location = new Vector3((float)currentLocation.x, (float)currentLocation.y, 0.0f);
                    //SpawnTreeScene();

                }
            
                else
                {
                    TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
                    text.SetText("Explore");
                    Vector2d tempLocation = map.WorldToGeoPosition(character.transform.position);
                    currentLocation = new Vector2d(tempLocation.x, tempLocation.y);

                }
            }

            foreach (GameObject Squirrel in Squirrels)
            {
                Vector3 diff = Squirrel.transform.position - playerTarget.transform.position;
                if ( diff.sqrMagnitude < 200.0f)
                {
                    SpawnSquirrelScene(Squirrel);
                    break;
                }

            }*/


        }
    }

    void SpawnSquirrelScene()
    {
        SceneManager.LoadScene("interaction_scene");
        GameObject interactiveTree = Instantiate(Squirrel__Object);
        Vector2d tempLocation = map.WorldToGeoPosition(Squirrel__Object.transform.position);
        currentLocation = new Vector2d(tempLocation.x, tempLocation.y);
        GameObject newSquirrel = Instantiate(Squirrel__Object);
        interactiveTree.transform.position = new Vector3((float)currentLocation.x, (float)currentLocation.y, 0.0f);

    }

    /*void SpawnTreeScene()
    {
        foreach (GameObject Tree in Trees)
        {


            Vector2d tempLocation = map.WorldToGeoPosition(Tree.transform.position);
            currentLocation = new Vector2d(tempLocation.x, tempLocation.y);
            GameObject interactiveTree = Instantiate(Tree);
            interactiveTree.transform.position = new Vector3((float)currentLocation.x, (float)currentLocation.y, 0.0f);
        }
    }*/

    void SquirrelSpawn()
    {
        //float placed_one_squirrel = 3.0f;
        Trees_array = GameObject.FindGameObjectsWithTag("Tree");
        if (Trees_array.Length == 0)
            return;
        var newSquirrel = GameObject.Instantiate(Squirrel__Object);
        GameObject.Find("SwitchModeButton").GetComponent<SwitchModeButton>().Squirrels.Add(newSquirrel);
        newSquirrel.transform.position = Trees[update_tree_num].gameObject.transform.position + offset; // Make sure y is 0
        Squirrels.Add(newSquirrel);
        update_tree_num += 1;
        update_tree_num = update_tree_num % Trees_array.Length;
    }


    void treeAndSquirrelCheck()
    {


        foreach (GameObject Squirrel in Squirrels)
        {
            Vector3 diff = Squirrel.transform.position - playerTarget.transform.position;
            if (diff.sqrMagnitude < 200.0f)
            {
                what_to_spawn = "Squirrel";

                return;
            }
        }
        foreach (GameObject Tree in Trees)
        {

            Vector3 diff = Tree.transform.position - playerTarget.transform.position;

            SceneManager.LoadScene("interaction_scene");

            if (diff.sqrMagnitude < 200.0f)
            {
                what_to_spawn = "Tree";
                Debug.Log("DO WE NOT GET HERE>>>>");
            }
}

