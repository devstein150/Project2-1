using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using System;
using System.Globalization;
using System.IO;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class OrbitCamera : MonoBehaviour

//This will do the same thing for the compass (hopefully)
{
    private float current_y_rot = 55;
    private float current_x_rot = 0;
    private float current_z_rot = 0;
    private float current_y_loc = 85.4f;
    private float current_x_loc = 0;
    private float current_z_loc = -48.5f;
    public float radius = 20.0f;
    private float key_presses_d = 0.0f;
    private float key_presses_w = 0.0f;
    private float key_presses_s = 0.0f;
    private float key_presses_a = 0.0f;

    public float push_factor;
    //private string current_camera = "Overhead View";
    public Transform player_avatar;
    public Vector3 offset;
    private float current_x_axis;
    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(transform.position, player_avatar.transform.position);
        print(radius);

    }

    float t = 0.0f;
    float h = 0.0f;

    // Update is called once per frame
    void Update()
    {
       // transform.position = player_avatar.position + offset;
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

        // 
        //  if (Keyboard.IsKeyDown(Key.A) && Keyboard.IsKeyDown(Key.W))


        if (Input.GetKey(KeyCode.W) && transform.position.y > 0)
        {
            //0 85.4   -48.5
            //117 2.5     -28
            h += 0.005f;
            transform.position = new Vector3((player_avatar.position.x), (Mathf.Cos(h) * radius), (Mathf.Sin(h) * radius));

            //transform.position = new Vector3((player_avatar.position.x), (Mathf.Cos(h) * radius) + transform.position.y, (Mathf.Sin(h) * radius) + transform.position.z);

        }
        if (Input.GetKey(KeyCode.D))
        {
            t += 0.005f;
            transform.position = new Vector3(Mathf.Cos(t) * radius, (player_avatar.position.y + 85.4f), Mathf.Sin(t) * radius);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > 0)
        {
            h -= 0.005f;
            transform.position = new Vector3((player_avatar.position.x), (Mathf.Cos(h) * radius), (Mathf.Sin(h) * radius));

        }
        else if (Input.GetKey(KeyCode.A))
        {
            t -= 0.005f;
            transform.position = new Vector3(Mathf.Cos(t) * radius, (player_avatar.position.y + 85.4f), Mathf.Sin(t) * radius);
        }

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

