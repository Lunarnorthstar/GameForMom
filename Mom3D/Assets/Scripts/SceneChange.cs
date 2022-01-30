using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{

    int nextSceneIndex;

    public void Awake()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {

            SceneManager.LoadScene(nextSceneIndex);

        }
    }
   
}

