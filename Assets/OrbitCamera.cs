using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour

    //This will do the same thing for the compass (hopefully)
{
    private float current_y_rot = 55;
    private float current_x_rot = 0;
    private float current_z_rot = 0;
    private float current_y_loc = 85.4f;
    private float current_x_loc = 0;
    private float current_z_loc = -48.5f;


    public float push_factor;
    //private string current_camera = "Overhead View";
    public Transform player_avatar;
    public Vector3 offset;
    private float current_x_axis;
    // Start is called before the first frame update
    void Start()
    {

    }

    float t = 0.0f;
    float h = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //transform.position = player_avatar.position + offset;
        //float h = push_factor * Input.GetAxis("Mouse X");
        // float v = push_factor * Input.GetAxis("Mouse Y");
        // transform.Rotate(v, h, 0);

        //t += Time.deltaTime;
        Vector3 xz_plane_offset = new Vector3(Mathf.Cos(t), 0.0f, Mathf.Sin(t));
        Vector3 yz_plane_offset = new Vector3(0.0f, Mathf.Cos(h), Mathf.Sin(h));

        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse x value [" + Input.GetAxis("Mouse X") + "]");
        }
        

        transform.position = player_avatar.position + Vector3.up * 5 + xz_plane_offset * 4.0f;
        transform.position = player_avatar.position + Vector3.up * 5 + yz_plane_offset * 4.0f;
        if ( Input.GetKey(KeyCode.D) | Input.GetKeyDown(KeyCode.A))
            t += 1.0f * Time.deltaTime;
        if ( Input.GetKey(KeyCode.W) | Input.GetKeyDown(KeyCode.S))
            h += 1.0f * Time.deltaTime;


        //if (Input.GetMouseButton(0))
        //{
        //Input.getaxis returns a number which we can scale with a public feel it out value
        //if (Input.GetAxis("Mouse Y") != 0 || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        //   shiftCamera();
        //if (Input.GetAxis("Mouse X") != 0)
        //  rotateCamera();

        transform.LookAt(player_avatar, Vector3.up);
    }

}

    /*void rotateCamera()
    {
        current_x_loc+= Mathf.Cos(push_factor * Input.GetAxis("Mouse X"));
        current_y_loc += Mathf.Sin(push_factor * Input.GetAxis("Mouse X"));
        transform.position = new Vector3(current_x_loc, current_y_loc, current_z_loc);
    
    }*/

    /*void shiftCamera(){ // vertical swipe, go to overhead view or down
        current_y_loc += Mathf.Cos(push_factor * Input.GetAxis("Mouse Y"));
        current_z_loc += Mathf.Sin(push_factor * Input.GetAxis("Mouse Y"));
        transform.position = new Vector3(current_x_loc, current_y_loc, current_z_loc);
        // if (current_camera == "Overhead View")
        // {
        //   current_camera == "Side View";
        //transform.rotation = Quaternion.Euler(current_x_axis, current_y_axis + 90, gameObject.transform.localRotation.eulerAngles.z);
        /// }

    }*/

