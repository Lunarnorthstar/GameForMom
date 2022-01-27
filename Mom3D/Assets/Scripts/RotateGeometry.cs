using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script is applied to the object to be rotated, "Object"
public class RotateGeometry : MonoBehaviour
{
    private Quaternion objectRotation; //Stores the desired angle of Object

    public float rotateSensitivity = 1; //Controls how fast Object turns

    private float objectX, objectY; //These variables store the movements of the mouse on the X and Y axes, respectively

    [SerializeField] private Boolean invertRotation = true; //Controls whether the rotation of Object is "inverted" or not
    private int mult = 1; //And this actually multiplies the value
    
    void Update()
    {
        if (invertRotation)
        {
            mult = 1;
        }
        else
        {
            mult = -1;
        }
        
        
        objectX += Input.GetAxis("Mouse X"); //Apply horizontal mouse movements to a variable
        objectY += Input.GetAxis("Mouse Y"); //Apply vertical mouse movements to a variable

        objectRotation = Quaternion.Euler(objectY * (-rotateSensitivity * mult), objectX * (rotateSensitivity * mult), 0); //Apply said changes to the quaternion...

        transform.rotation = objectRotation; //...and apply that quaternion to Object's transform to rotate it.
    }
}
