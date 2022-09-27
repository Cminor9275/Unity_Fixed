using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy_prefab;
    public int num_enemies = 5;
    int second_between_spawn = 2;
    float enemy_radius;
    int enemies_remaining;
    float timer = 5;
    void Start()
    {
        enemy_radius = (2 * Mathf.PI) / num_enemies;
        enemies_remaining = num_enemies;
    }

    // Update is called once per frame
    void Update()
    {
        while(num_enemies > 0)
        {
            int dist = 2;
            Vector3 offset = new Vector3(Mathf.Cos(enemy_radius * enemies_remaining), 0, Mathf.Sin(enemy_radius * enemies_remaining)) * dist;
            GameObject new_inst = GameObject.Instantiate(enemy_prefab);
            new_inst.transform.position = transform.position + offset;
            num_enemies--;
            enemies_remaining--;
        }
    }
}
