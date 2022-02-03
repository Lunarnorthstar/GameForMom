using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public float timer = 5;

    int nextSceneIndex;

    public GameObject toTurnOn;
    public MeshRenderer visual;

    public void Awake()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Object")
        {
            visual.enabled = false;
            toTurnOn.SetActive(true);

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log(timer);
            }
            else
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
                
            

           
        }
    }
   
}

