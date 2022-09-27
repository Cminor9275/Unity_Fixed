using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    float state_timer = 2.0f;
    bool player_walk = false;

    Animator anim_comp;


    void Start()
    {
        anim_comp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        state_timer -= Time.deltaTime;
        if(state_timer < 0)
        {
            state_timer = 2;
            player_walk = !player_walk;

            anim_comp.SetBool("Do_walk", player_walk);
        }
    }
}
