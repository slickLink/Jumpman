using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleZone : MonoBehaviour
{
    public int zoneId = 1;
    public GameObject[] platforms_GO;
    public Transform[] platform_SpawnPoints;

 
    public void spawn ( Transform [] points)
    {
        int index;
        foreach (Transform t in points)
        {
            if(t.tag == "zonepoint") // only spawn platform on a platform point
            {
                // get new index spot for platforms
                index = Random.Range(0, platforms_GO.Length);
                // instantiate platform
                Instantiate((GameObject)platforms_GO[index], t);
            }
        }
    }
}
