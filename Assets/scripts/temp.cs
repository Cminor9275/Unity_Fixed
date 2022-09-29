using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    float state_timer = 2.0f;
    bool player_walk = true;
    public float rotate_speed = 0.01f;
    public float speed = 5f;
    Transform mesh_transform;
    Rigidbody rb;
    float rotate_timer = 0;
    float walk_timer = 9.8f;
    bool is_walking = true;
    bool is_rotating = false;
    

    Animator anim_comp;


    void Start()
    {
        anim_comp = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mesh_transform = transform.Find("Robot_mesh");
        //player_walk = !player_walk;

        //anim_comp.SetBool("Do_walk", player_walk);
    }

    // Update is called once per frame
    void Update()
    {
       
        rotate_timer -= Time.deltaTime;
        walk_timer -= Time.deltaTime;
        if(rotate_timer > 0)
        {
            is_rotating = true;
            player_walk = false;
        }
        if(walk_timer > 0)
        {
            is_walking = true;
            player_walk = true;
            
        }
        
        
    }
    private void FixedUpdate()
    {
        //Vector3 vel = new Vector3(0, 0, speed);
        Vector3 vel = transform.forward * speed;
        if(is_walking == true)
        {
            
            vel = transform.forward * speed;
            rb.velocity = vel;
            anim_comp.SetBool("Do_walk", player_walk);
            if (walk_timer <= 0)
            {
                is_walking = false;
                rotate_timer = 4f;
            }
            
        }
       
        if (is_rotating == true)
        {
            vel = new Vector3(0, 0, 0);
            rb.velocity = vel;
            anim_comp.SetBool("Do_walk", player_walk);
            transform.Rotate(0, 90 * rotate_speed, 0.0f, Space.Self);
            if(rotate_timer <= 0)
            {
                is_rotating = false;
                walk_timer = 9.8f;
            }
        }
        





    }
}
