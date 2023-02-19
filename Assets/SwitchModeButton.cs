using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchModeButton : MonoBehaviour
{
    public GameObject gameplay_canvas;

    static GameObject gameplay_canvas_instance;

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
    public void OnSwitchButtonPressed()
    {
        
        if(SceneManager.GetActiveScene().name == "interaction_scene")
        {
            SceneManager.LoadScene("exploration_scene");
        }
        else
        {
            SceneManager.LoadScene("interaction_scene");
        }
    }
}
