using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls how the player moves and interacts with the world
public class player_movement : MonoBehaviour
{

    // variables
    public float speed = 5f;
    public float runSpeed = 10f;
    public float jumpStrength = 6f;
    public float gravityStrength = 6f;
    public float moving = 0f;
    public int numOfJumps = 0;
    public bool midAir = false;
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isFacingRight = true;
    private Rigidbody rb;
    // Update is called once per frame
    void Awake()
    {
        // getting a reference to the rigidbody so i only call GetComponent once
        rb = GetComponent<Rigidbody>();
    }
    void Update ()
    {
        if(level_Manager_1.LM1.isPlaying)
        {
            // move left when 'A' is pressed
            moving = Input.GetAxisRaw("Horizontal");
            // jump when the spacebar is pressed and check for number of jumps 
            if (Input.GetButtonDown("Jump") && numOfJumps < 2)
            {
                isJumping = true;
            }
            // running should occur as long as the button is held down
            if (Input.GetButton("Run"))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            // move character
            movePlayer(moving, isJumping, isRunning);
            if (isFacingRight == false && moving > 0)
            {
                flip();
            }
            else if (isFacingRight == true && moving < 0)
            {
                flip();
            }

        }
    }

    private void movePlayer(float direction, bool jump, bool run)
    {
       
        // check if character is running, if not just move at normal speed
        if(run)
        {

            transform.position += new Vector3(direction, 0, 0).normalized * runSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(direction, 0, 0).normalized * speed * Time.deltaTime;
        }
        // jump if needed
        if(jump)
        {
            rb.velocity = Vector3.up * jumpStrength;
            midAir = true;
            numOfJumps++;
            isJumping = false;
        }
        //check if character is mid air and falling change its gravity so the character falls quicker 
        if (midAir && rb.velocity.y < 1)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravityStrength - 1) * Time.deltaTime;
        }

    }

    // so far just handles collision with the ground or platform
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            midAir = false;
            //reset double jump mechanic
            numOfJumps = 0;
        }
    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
    }
}
