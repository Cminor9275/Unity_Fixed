using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{
    public static int globalVariable;
    public static int Enemies_alive;
    void Start()
    {
        globalVariable = 0;
        Enemies_alive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Global Variable = " + Enemies_alive);
        globalVariable++;
    }
}
