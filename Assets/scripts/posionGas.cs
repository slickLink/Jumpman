using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posionGas : MonoBehaviour
{
    private float timer = 0f;
    private float gasReleaseInterval = 1f;
    private float durationCutOff = 5f;
    private float gasTimer = 0f;
    private float gasDamageInterval = 1f;
    public float radius = 5f;
    private bool gasReleased = false;
    private GameObject gasInstance;
    public GameObject gas;
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= gasReleaseInterval && !gasReleased)
        {
            releaseGas();
            gasReleased = true;
        }

        if( timer > gasReleaseInterval) //&& timer < durationCutOff)
        {
            gasTimer += Time.deltaTime;

            if(gasTimer >= gasDamageInterval)
            {
                gasTimer -= gasDamageInterval;
                tickDamage();
            }

        }

       /* if(timer > durationCutOff)
        {
            Destroy(gameObject);
        } */
	}

    private void releaseGas()
    {
        // release the gas 
        gasInstance = Instantiate(gas, transform.position + new Vector3(0,0, -1f), Quaternion.identity);
    }
    private void tickDamage()
    {
        Debug.Log("tickDamageInitiated : "+ Time.timeSinceLevelLoad);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            if (nearby.tag == "Player")
            {
                Debug.Log("player Damaged : From poison");
                player.P.takeDamage(1);
            }
        }
    }
}
