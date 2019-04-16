using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 5f;
    

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player")
        {
            // damage player too
            Destroy(this.gameObject);
        }
    }
}
