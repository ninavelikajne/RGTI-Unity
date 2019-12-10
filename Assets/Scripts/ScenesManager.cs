using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public static void StartFromStart()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public static void Victory()
    {
        SceneManager.LoadScene("Victory", LoadSceneMode.Single);
    }
}
