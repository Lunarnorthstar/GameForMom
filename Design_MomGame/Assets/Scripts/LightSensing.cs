using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be placed on the "Sensor" item
public class LightSensing : MonoBehaviour
{
    public GameObject lightbeam;
    
    public Boolean redReq, blueReq, greenReq;
    public Boolean active = false;

    // Start is called before the first frame update
    void Start()
    {
        lightbeam = GameObject.Find("Beam"); //Set the lightbeam variable to the beam of light used to send messages and change states
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Struck()
    {
        if (lightbeam.GetComponent<LightBeam>().red == redReq && lightbeam.GetComponent<LightBeam>().blue == blueReq &&
            lightbeam.GetComponent<LightBeam>().green == greenReq) //If the beam's current colors match the sensor requirements...
        {
            active = true;
        }
    }

    public void UnStruck()
    {
        active = false;
    }
}