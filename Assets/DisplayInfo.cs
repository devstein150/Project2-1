using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using System;
using System.Globalization;
using System.IO;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
public class DisplayInfo : MonoBehaviour

{
    public GameObject Panel;
    public GameObject player_object;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - player_object.transform.position;

        if (Input.GetKey(KeyCode.N))
        {
            print("HEY WE GOT HERE!!!");
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
           // Panel.transform.position = player_object.transform.position;
        }
    }

    public void UIgeneration()
    {


    }
}
