using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform enemySpawnLocation;
	// Use this for initialization
	void Start ()
    {
        // pick a random enemy and spawn it at the spawn location
        int num = Random.Range(0, enemies.Length - 1);
        if(enemies[num] != null)
        {
            Instantiate(enemies[num], enemySpawnLocation.position, Quaternion.identity);
        }
    }
	
	
}
