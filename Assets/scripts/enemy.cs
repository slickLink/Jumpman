using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 3f;
    private float teleportTimer = 0f;
    private float teleportInterval = 5f;
    private float explosionTimer = 0f;
    private float explosionInterval = 1f;
    private float riserInterval = 3f;
    private float poisonDropTime = 3f;
    private Rigidbody bullet;
    private Rigidbody poison;

    public Rigidbody bulletPrefab;
    public Transform firePosition;
    public GameObject playerGO;
    public GameObject tnt;
    public GameObject fireball;
    public Rigidbody poisonCapsulePrefab;
    public Collider head;
    public float speed = 5f;
    public int enemyType = 1;
    public float teleportingSpeed = 0.5f;
    public bool rose = true;
    public bool movingLeft = true;
    public bool enemyKillabe = true;
    public Vector3 offset;
    public Vector3 position2;
    public Vector3 position1;
    public int thrown = 0;
    public float radius = 5f;

    private void Start()
    {
        playerGO = player.P.instance;
        position1 = transform.position;
        position2 = transform.position + new Vector3(-4, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        // update timers
        timer += Time.deltaTime;
        teleportTimer += Time.deltaTime;
        riserInterval -= Time.deltaTime;
        poisonDropTime -= Time.deltaTime;

        // action for enemytype 1
        if(timer >= interval && enemyType == 1)
        {
            // reset timer
            timer -= interval;
            //fire projectile
            fireBullet();
        }

        //action for enemytype 2
        if(teleportTimer >= teleportInterval && enemyType == 2)
        {
            // reset timer
            teleportTimer -= teleportInterval;

            // make sure player is in range
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearby in colliders)
            {
                Rigidbody rb = nearby.GetComponent<Rigidbody>();
                if (rb != null && rb.tag == "Player")
                {
                    // teleport
                    teleport();
                    // create explosion
                    Instantiate(tnt, transform.position - offset, Quaternion.identity);
                }
            }  
        }
        enemyKillabe = true;
        // action for enemytype 3
        if(riserInterval < 0 && enemyType == 3)
        {
            // player cannot damage this enemytype;
            head.enabled = false;
            riserInterval = 3f;
            if(rose)
            {
                fall();
                rose = false;
            }
            else
            {
                rise();
                rose = true;
            }
        }

        //action for enemytype 4
        if(poisonDropTime < 0 && enemyType == 4/* && thrown < 1 */)
        {
           // thrown++;
            poisonDropTime = 7f;
            //drops a poisonous object towards the player
            throwPoison();
        }

        //action for enemyType 5
        if(enemyType == 5)
        {
            if (movingLeft && transform.position != position2 ) // if we havent reached our desired location and are moving left
            {
                // move to desired location
                patrol(transform.position, position2);

                // checking if we are close enough to the desired position and changing direction if needed
                float distance = Vector3.Distance(transform.position, position2);
                if(distance < 0.13f)
                {
                    movingLeft = false;
                }
            }
            if(!movingLeft && transform.position != position1) // if we havent reached our desired location and are moving right
            {
                // move to desired location
                patrol(transform.position, position1);
                // checking if we are close enough to the desired position and changing direction if needed
                float distance = Vector3.Distance(transform.position, position1);
                if (distance < 0.13f)
                {
                    movingLeft = true;
                }
            }   
        }
	}

    private void fireBullet()
    {
        bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        Vector3 dir = playerGO.transform.position - transform.position;
        bullet.AddForce(dir.normalized * speed, ForceMode.Impulse);
    }

    private void teleport()
    {
        transform.position = playerGO.transform.position + offset;
        enemyKillabe = false;
    }

    private void rise()
    {
        transform.position += Vector3.up;
    }
    private void fall()
    {
        transform.position += Vector3.down;
    }
    private void throwPoison()
    {
        poison = Instantiate(poisonCapsulePrefab, firePosition.position, Quaternion.identity);
        Vector3 dir = playerGO.transform.position - firePosition.position;
        poison.AddForce(dir.normalized * speed, ForceMode.Impulse);
    }
    private void patrol(Vector3 from, Vector3 to)
    {
        Vector3 desiredPosition = Vector3.Lerp(from, to, speed * Time.deltaTime);
        transform.position = desiredPosition;
    }
  
}
