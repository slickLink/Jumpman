using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls general player attributes
public class player : MonoBehaviour
{
    public static player P;
    public int lives = 3;
    public GameObject instance;
    public int enemiesDestroyed = 0;
    public int collected = 0;
    public string level;

    private void Awake()
    {
        if( P == null)
        {
            P = this;
        }
        if(instance == null)
        {
            instance = this.gameObject;
        }
    }
    private void Update()
    {
        if(lives <= 0)
        {
            dead();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // handles activation of procedural generation
        if(other.name == "point_3")
        {
            // allow level_Manager to spawn the next zone
            other.enabled = false;
            level_Manager_1.LM1.setUpNextZone();
        }
        //handles killing an enemy using their weak spot
        if (other.name == "head" && other.transform.parent.GetComponent<enemy>().enemyKillabe == true)
        {
            Debug.Log("killed enemy");
            Destroy(other.transform.parent.gameObject);
            enemiesDestroyed++;
        }
        // handles taking damage when player bumps into an enemy
        if (other.tag == "enemy")
        {
            lives--;
            Debug.Log("player took damage : " + Time.timeSinceLevelLoad);
        }

        //handles falling to death
        if (other.tag == "deathZone")
        {
            lives = 0;
        }
        //handles wining the game
        if (other.tag == "winPlatform")
        {
            level_Manager_1.LM1.levelBeat = true;
            level_Manager_1.LM1.isPlaying = false;
        }
    }

    public void takeDamage(int damage)
    {
        lives -= damage;
    }

    private void dead()
    {
        // restart level
        SceneChanger.SC.changeScene(level);
        Debug.Log("player dead : " + Time.timeSinceLevelLoad);
    }
}
