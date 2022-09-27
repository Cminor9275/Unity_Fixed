using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float movespeed = 5f;
    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
       
    }
   
}
