using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public static class God
{
    public static GOD GM;
    public static FirstPersonController FP;
}

public class GOD : MonoBehaviour
{
    public int Score = 0;
    public TextMeshPro ScoreText;
    public GameObject Thing;
          

    void Awake()
    {
        God.GM = this;
        ScoreText.text = "Score: " + Score;
    }

    public void Getpoint()
    {
        Score++;
        ScoreText.text = "Score: " + Score;
        
        if (Score == 2)
        {  
           Thing.SetActive(true);
        }

    }

    //I can use a static variable to make this available
    //from anywhere in my code
    public static GOD Me;


    //The prefab for the monster that spawns
    public NPCController FriendPrefab;
    //How long until the next monster spawns?
    public float SpawnTimer = 0;
    //Once a monster spawns, how long until the next?
    public float SpawnMaxTimer = 3;
    //Where do the monsters spawn?
    public Vector3 EnemySpawnPos;
    public int ToSpawn = 3;

    //A link to the player
    public FirstPersonController Player;
    //Keep a list of all the monsters
    public List<NPCController> AllEnemies;
    public AudioSource AS;

    void Start()
    {
        //Register myself to the static variable
        GOD.Me = this;
    }
    public AudioClip hey;
    void Update()
    {
        //The spawn timer always counts down in real time
        SpawnTimer -= Time.deltaTime;
        //When it hits 0. . .
        if (SpawnTimer <= 0 && ToSpawn >0 )
        {
            //Reset it
            SpawnTimer = SpawnMaxTimer;
            //Spawn an enemy at the EnemySpawnPos position
            NPCController e = Instantiate(FriendPrefab,
                EnemySpawnPos, Quaternion.identity);
            ToSpawn--;
            AS.PlayOneShot(hey);
            
        }
      
    }
}