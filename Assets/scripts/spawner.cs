using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy_prefab;
    public int num_enemies = 5;
    float second_between_spawn = 2;
    float enemy_radius;
    int enemies_remaining;
    float timer = 5;
    int total_enemies;



    GameObject ui_game_object;
    Ui_script ui_Script;
    


    


    void Start()
    {
        enemy_radius = (2 * Mathf.PI) / num_enemies;
        enemies_remaining = num_enemies;
        second_between_spawn -= Time.deltaTime;    
        ui_game_object = GameObject.Find("Main_Ui");
        ui_Script = ui_game_object.GetComponent<Ui_script>();
        
    }

    // Update is called once per frame
    void Update()
    {

        GlobalVariableStorage.Enemies_alive += num_enemies;
        ui_Script.change_ui_Score(GlobalVariableStorage.Enemies_alive);
        while (num_enemies > 0)
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
