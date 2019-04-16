using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level_Manager_1 : MonoBehaviour
{
    public static level_Manager_1 LM1;
    public GameObject zonePrefab;
    public GameObject finalZone;
    public GameObject menu;
    public Transform[] ZoneSpawnPoints;
    public Text timeText;
    public Text livesText;
    public Text enemiesText;
    public Text collectableText;

    ArrayList zoneList = new ArrayList();
    public bool isPlaying = true;
    public bool spawnNextZone = true;
    public bool isPaused = false;
    public bool levelBeat = false;
    public bool createFinalZone = false;
    public int currentZone = 0;


  
    private float time = 0f;

    private void Awake()
    {
        if(LM1 == null)
        {
            LM1 = this;
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(isPlaying) // if game is playable
        {
            //updated in-game displays
            timeText.text = "Time: " + time;
            livesText.text = "Lives: " + player.P.lives;
            collectableText.text = "Collectables: " + player.P.collected;
            enemiesText.text = "Enemies Destroyed: " + player.P.enemiesDestroyed;

            if(spawnNextZone) // check to see whether to spawn the next zone
            {
                spawnZone(currentZone);
                spawnNextZone = false;
                if(currentZone >= 2)
                {
                    deleteZone();
                }
            }
            if(spawnNextZone == false && createFinalZone == true)
            {
                Instantiate(finalZone, ZoneSpawnPoints[ZoneSpawnPoints.Length - 1].position + new Vector3(25, 2, 0.25f), Quaternion.identity);
                createFinalZone = false;
            }
        }
        else
        {
            // if not playing bring up menu
            if(isPaused == true)
            {
                // pause game
                isPlaying = false;
            }

            if(levelBeat == true)
            {
                isPlaying = false;
                menu.GetComponent<pauseMenu>().WinGame();
                // congradulate player and show stats
            }
        }
    }

    // spawns a zone prefab at a transform point
    private void spawnZone(int index)
    {
        // instantiate a zone prefab as a GameObject at a zone spawning point
        zoneList.Add(Instantiate(zonePrefab, ZoneSpawnPoints[index]) as GameObject);
        /*acess the currently instantiated zone and spawn the platforms it holds.
         * the platform spawning points are found in children of a zonespawn point
         * */
       GameObject current = (GameObject) zoneList[zoneList.Count - 1];
       current.GetComponent<singleZone>().spawn(ZoneSpawnPoints[index].GetComponentsInChildren<Transform>());
    }
    // deletes a zone 
    private void deleteZone()
    {
        GameObject GO = (GameObject)zoneList[0];
        zoneList.RemoveAt(0);
        Destroy(GO.transform.parent.gameObject);
    }

    public void setUpNextZone()
    {
        currentZone++;
        if(currentZone != ZoneSpawnPoints.Length)
        {
            spawnNextZone = true;
        }
        if(currentZone == ZoneSpawnPoints.Length)
        {
            spawnNextZone = false;
            createFinalZone = true;
        }
        
    }
	
}
