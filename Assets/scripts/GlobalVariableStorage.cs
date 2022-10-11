using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariableStorage : MonoBehaviour
{
    public static int globalVariable;
    public static int Enemies_alive;

    public AudioSource music;
    void Start()
    {
        music.Play();
        globalVariable = 0;
        Enemies_alive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies_alive <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
