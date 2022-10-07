using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5.0f;
    GameObject ui_game_object;
    Ui_script ui_Script;

    void Start()
    {
        ui_game_object = GameObject.Find("Main_Ui");
        ui_Script = ui_game_object.GetComponent<Ui_script>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("ignore because player");
        }
        else if (other.gameObject.tag == "Enemy")
        {
            print("hit an enemy");
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);
            GlobalVariableStorage.Enemies_alive -= 1;
            


        }
        else
        {
            print("I hit: " + other.gameObject.name);
            GameObject.Destroy(gameObject);
        }
        ui_Script.change_ui_Score(GlobalVariableStorage.Enemies_alive);
    }
}
