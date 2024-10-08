using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class CoinS : MonoBehaviour
{
    public AudioSource AS;
    public int Score = 0;
    public AudioClip coin;
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.name == "First Person Player")
        {
            Score++;
            Destroy(gameObject);
            AS.PlayOneShot(coin);
        }
        God.GM.Getpoint();

    }
}


