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
    public GameObject gameplay_canvas;

    static GameObject gameplay_canvas_instance;

    public GameObject switchModeButton;

    public GameObject playerTarget;

    public GameObject[] Squirrels;

    public GameObject[] Trees;


    public AbstractMap map;
    public void Start()
    {
        if (gameplay_canvas_instance == null)
        {
            gameplay_canvas_instance = gameplay_canvas;
            DontDestroyOnLoad(gameplay_canvas);
        }
        else
        {
            Destroy(gameplay_canvas);
        }
    }

    public static Vector2d currentLocation;
    public GameObject character;
    public void OnSwitchButtonPressed()
    {
        
        if(SceneManager.GetActiveScene().name == "interaction_scene")
        {
            SceneManager.LoadScene("exploration_scene");
            TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText("Interact");
            
        }
        else
        { //exploration scene
            SceneManager.LoadScene("interaction_scene");
            TextMeshProUGUI text = switchModeButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText("Explore");
            Vector2d tempLocation = map.WorldToGeoPosition(character.transform.position);
            currentLocation = new Vector2d(tempLocation.x, tempLocation.y);
            print(currentLocation);


            Squirrels = GameObject.FindGameObjectsWithTag("Squirrel");
            Trees = GameObject.FindGameObjectsWithTag("Tree");
            foreach (GameObject Squirrel in Squirrels)
            {
                Vector3 diff = Squirrel.transform.position - playerTarget.transform.position;
                if ( diff.sqrMagnitude < 200.0f)
                {
                    SpawnTreeScene();
                }

            }
            foreach (GameObject Tree in Trees)
            {
                Vector3 diff = Tree.transform.position - playerTarget.transform.position;
                if (diff.sqrMagnitude < 200.0f)
                {
                    SpawnSquirrelScene();
                }

            }

        }
    }

    void SpawnSquirrelScene()
    {
        SceneManager.LoadScene("interaction_scene");

    }

    void SpawnTreeScene()
    {

    }
}
