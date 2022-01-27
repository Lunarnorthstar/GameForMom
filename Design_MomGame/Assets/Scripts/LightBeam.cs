using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be placed on the "beam" item
public class LightBeam : MonoBehaviour
{
    public Boolean red, blue, green;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            red = true;
        }
        
        if (other.gameObject.tag == "Blue")
        {
            blue = true;
        }
        
        if (other.gameObject.tag == "Green")
        {
            green = true;
        } //These three set the respective colors to true when glass overlaps the beam

        if (other.gameObject.tag == "Sensor")
        {
            other.SendMessage("Struck");
        } //This one sends a signal when it overlaps a sensor
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            red = false;
        }
        
        if (other.gameObject.tag == "Blue")
        {
            blue = false;
        }
        
        if (other.gameObject.tag == "Green")
        {
            green = false;
        } //These three set the respective colors to false when glass stops overlapping the beam.
        
        if (other.gameObject.tag == "Sensor")
        {
            other.SendMessage("UnStruck");
        } //This one stops a signal when it overlaps a sensor
    }
}
