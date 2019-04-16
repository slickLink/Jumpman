using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    public GameObject parent;
    public GameObject fireballEffect;
    private GameObject fire;
    public float speed = 0.5f;
    public Vector3 offset;
    // Update is called once per frame
    private void Start()
    {
       fire = Instantiate(fireballEffect, transform.position, Quaternion.identity);
    }
    void Update()
    {
        transform.RotateAround(parent.transform.position, Vector3.forward, speed * Time.deltaTime);
        fire.transform.position = transform.position + offset;
    }
}
