using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    void Start() 
    {
        // set default difficulty
        GameManager.difficulty = 0;
    }

    public void StartGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public static void StartFromStart()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public static void GameOver()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public static void Victory()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Victory", LoadSceneMode.Single);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
