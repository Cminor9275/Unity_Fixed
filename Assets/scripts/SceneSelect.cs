using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void MainGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MazeGame()
    {
        SceneManager.LoadScene("Maze");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
