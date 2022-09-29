using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    public float speed = 5.0f;
    Rigidbody rb;
    Vector2 move_input;
    public float Health = 100;

    // used for doing the ray cast for mouse aiming
    Ray mouse_aim_ray;
    bool aim_needs_recalculated = false;
    Camera main_cam;

    public GameObject bullet_prefab;

    Transform mesh_transform;
    Transform aim_transform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh_transform = transform.Find("Player_mesh");
        aim_transform = mesh_transform.Find("Aim_pt");

        main_cam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health > 100)
        {
            Health = 100;
        }
        if(Health <= 0)
        {
            Application.Quit();
            
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 vel = new Vector3(move_input.x, 0, move_input.y) * speed;
        rb.velocity = vel;

        //Do the mouse-aim raycast, if necessary
        if (aim_needs_recalculated)
        {
            // Turn off aiming until the mouse moves again
            aim_needs_recalculated = false;

            // Do the actual raycast
            RaycastHit hit_result;
            string[] my_layers = { "Ground" };
            if (Physics.Raycast(mouse_aim_ray, out hit_result, LayerMask.GetMask(my_layers)))
            {
                Vector3 aim_pt = new Vector3(hit_result.point.x, mesh_transform.position.y, hit_result.point.z);
                mesh_transform.LookAt(aim_pt, Vector3.up);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Robot")
        {
            print("robot hit");
            Health -= 100;
        }
    }

    public void fire(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0.5f && context.performed)
        {
            GameObject new_inst = GameObject.Instantiate(bullet_prefab);
            new_inst.transform.position = aim_transform.position;
            new_inst.transform.rotation = aim_transform.rotation;
        }
    }
    public void move(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
    }
    public void look_at(InputAction.CallbackContext context)
    {
        Vector2 mouse_offset = context.ReadValue<Vector2>();
        PlayerInput input_comp = GetComponent<PlayerInput>();
        if(input_comp.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 mouse_pos = Mouse.current.position.ReadValue();
            aim_needs_recalculated = true;
            mouse_aim_ray = main_cam.ScreenPointToRay(mouse_pos);
        }
        // To-do: make a gamepad case here.
    }
}
