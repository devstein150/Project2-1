using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastMouse : MonoBehaviour
{
    public GameObject[] landmarks;
    public GameObject[] panels;
    static GameObject currentActivePanel = null;
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject diagPanel = GameObject.Find("DiagPanel");
        panels[0] = (diagPanel);
        panels[1] = (diagPanel);
        panels[2] = (diagPanel);
        panels[3] = (diagPanel);
        panels[4] = (diagPanel);*/
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {   
        float distance = 100f;
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "exploration_scene")
        {
            print("creatingRay");
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_result;
            if (Physics.Raycast(ray, out hit_result))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit_result.point);
                //log $$anonymous$$t area to the console
                Debug.Log(hit_result.point);
                Transform objectHit = hit_result.transform;
                //GameObject[] landmarks = GameObject.FindGameObjectsWithTag("Landmark");
                GameObject landmarkSelected;
                int count = 0;
                foreach(GameObject landmark in landmarks)
                {
                    if(Mathf.Abs(landmark.transform.position.x - objectHit.position.x) < 5.0f &&
                        Mathf.Abs(landmark.transform.position.y - objectHit.position.y) < 5.0f &&
                        Mathf.Abs(landmark.transform.position.z - objectHit.position.z) < 5.0f)
                    {
                        landmarkSelected = landmark;
                        print("in");
                        print(panels.Length);
                        print(panels);
                        currentActivePanel = panels[count];
                        currentActivePanel.SetActive(true);
                        currentActivePanel.transform.position = GameObject.Find("GameplayCanvas").transform.position;
                        break;
                    }
                    ++count;
                }

            }
            else
            {
                if (currentActivePanel != null)
                {
                    currentActivePanel.SetActive(false);
                    currentActivePanel = null;
                }
            }
        }
    }
}
