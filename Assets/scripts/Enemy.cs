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

    public UnityEngine.AI.NavMeshAgent agent;
    [Range(0, 100)] public float wander_speed;
    [Range(1, 500)] public float wander_radius;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        mr = GetComponent<MeshRenderer>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = wander_speed;
            agent.SetDestination(RandomMeshLocation());
        }
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
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        }
        else
        {
            if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(RandomMeshLocation());
            }
        }


    }
    public Vector3 RandomMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * wander_radius;
        randomPosition += transform.position;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out UnityEngine.AI.NavMeshHit hit, wander_radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
   
}
