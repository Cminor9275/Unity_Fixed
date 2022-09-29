using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float movespeed = 5f;
    private Rigidbody rb;

    public Material normal_mat;
    public Material agro_mat;
    float material_timer = 2f;

    MeshRenderer mr;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        material_timer -= Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        //print(distance);
        if (distance <= 10)
        {
            mr.material = agro_mat;
            //print("changing material");
        }
        else
        {
            mr.material = normal_mat;
            //print("changing material");
        }
    }

    private void FixedUpdate()
    {
        
        
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance <= 10)
        {
            this.gameObject.transform.LookAt(player.transform);
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        }


    }
   
}
