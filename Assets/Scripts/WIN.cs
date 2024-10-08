using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WIN : MonoBehaviour

{
    public AudioSource AS;
    public AudioClip goal;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.name == "First Person Player")
        {

        Debug.Log("you win!");
            AS.PlayOneShot(goal);
        }
    }
}


