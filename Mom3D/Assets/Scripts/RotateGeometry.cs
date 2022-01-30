using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

//Script is applied to the object to be rotated, "Object"
//Dependencies (Components); Rigidbody (not kinematic)
//Dependencies (Scene); Requires the starting position of the object to be at (0, -2, 0) (or another uniform position across all scenes, in which case the values will need to be changed)
public class RotateGeometry : MonoBehaviour
{
    private Quaternion objectRotation; //Stores the desired angle of Object
    private float randOffset; //Stores a random offset for Object to start at.

    public float rotateSensitivity = 1; //Controls how fast Object turns

    private float objectX, objectY; //These variables store the movements of the mouse on the X and Y axes, respectively


    private float dropOffset; //The amount the object has dropped
    public float dropSpeed = 1; //The rate at which the object approaches the hole
    [SerializeField] private Boolean invertRotation = true; //Controls whether the rotation of Object is "inverted" or not
    private int mult = 1; //And this actually multiplies the value
    public float xShiftPos = 3; //The X position Object will move to when shifted

    Random randomRotation = new Random(); //Generates a random number, used for the starting rotation of the object

    public Rigidbody rB; //The object's rigidbody component


    private void Start()
    {
        randOffset = randomRotation.Next(0, 180); //Generate a random number to use as a starting offset

        rB = GetComponent<Rigidbody>(); //Get the rigidbody component
    }

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

        objectRotation = Quaternion.Euler(objectY * (-rotateSensitivity * mult) + randOffset, objectX * (rotateSensitivity * mult) + randOffset, 1); //Apply said changes to the quaternion... (plus starting offset)

        transform.rotation = new Quaternion(objectRotation.x, objectRotation.y, objectRotation.z, 0); //...And apply the quaternion to the transform.

        objectMoving();
    }

    void objectMoving()
    {
        /*dropOffset -= (dropSpeed / 4) * Time.deltaTime; //Passively reduce the offset - the amount Object has been lowered. This means if it's not descending it will move upwards back to the original position.
        if (dropOffset < 0)
        {
            dropOffset = 0; //This if statement prevents Object from rising above the original position.
        }
        
        if (Input.GetKey(KeyCode.Q)) //When the Q key is pressed...
        {
            dropOffset += dropSpeed * Time.deltaTime; //Start increasing the drop offset. This lowers the object.
        }
        
        
        transform.position = new Vector3(transform.position.x, -2 - dropOffset, transform.position.z); //Apply the changes. Note the hardcoded static starting value is to prevent acceleration. It may need to be changed.*/
        //~~~~~~ The above is a legacy movement option that didn't work out with the colliders, it's only here for emergencies. ~~~~~

        if (Input.GetKey(KeyCode.DownArrow)) //When the Q key is pressed...
        {
            rB.AddForce(0, -dropSpeed * Time.deltaTime, 0); //Start adding force to Object's rigidbody
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = new Vector3(0, -2, 0); //When the move key is released, set the position back to the default.
            rB.velocity = Vector3.zero; //And reset the velocity too.
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, xShiftPos, 0.1f), -2, 0);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position = new Vector3(0, -2, 0);
        }
    }
}
