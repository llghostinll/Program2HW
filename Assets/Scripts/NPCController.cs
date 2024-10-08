using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NPCController : MonoBehaviour
{
    //My components
    public Rigidbody RB;
    public Animator Anim;
    public AudioSource AS;

    //My stats
    public float Speed = 2;

    //Who do I walk towards?
    public FirstPersonController Target;

    void Start()
    {

        Target =
            GameObject.FindObjectOfType<FirstPersonController>();

        //At the start of the game I should play my walk animation
        Anim.Play("Walking");
        //I just walk forever, for now.
    }

    private void Update()
    {

        //Rotate to look at the player
        transform.LookAt(Target.transform);
        //Make a temp velocity variable to calculate how I should move
        //By default, I keep my old momentum

        Vector3 vel = RB.velocity;
        //Walk forwards, but don't do it perfectly. Lerp towards my desired speed
        //This makes it so that if I take a knockback it takes a second for me to recover


        if (Vector3.Distance(transform.position, Target.transform.position) < 30)
        {
            vel = Vector3.Lerp(vel, transform.forward * Speed, 10 * Time.deltaTime);

        }

        //Use my old Y velocity, though. I shouldn't be able to fly
        vel.y = RB.velocity.y;
        //Plug it into my rigidbody
        RB.velocity = vel;
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.name == "First Person Player")
        {
            Debug.Log("you Lose!");
        }

    }
}
