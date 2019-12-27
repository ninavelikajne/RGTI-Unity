using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool keyIsCollected;
    public static int difficulty;  //{0,1,2}
    public static int score;
    public static bool pause;

    public GameObject foodPrefab;
    public GameObject minerPrefab;
    public GameObject keyPrefab;

    public Camera cameraOne;
    public Camera cameraTwo;
    public Text scoreText;
    public Text timerText;

    private float timer;

    private List<Location> foods = new List<Location>();
    private List<Location> miners = new List<Location>();
    private List<Location> key = new List<Location>();

    void Start() 
    {
        timer = 0f;
        timerText.text = "00:00";
        scoreText.text = "Točke: 0";
        cameraOne.enabled = true;
        cameraTwo.enabled = false;
        Cursor.visible = false;
        keyIsCollected = false;
        score = 0;
        difficulty = 0; // pol zbirs

        pause = false;
        Cursor.visible = false;
        AudioListener.pause = false;
        Time.timeScale = 1f;

        initLocations();
        placeObjects();
    }

    void Update()
    {
        timerCount();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseButton.TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraOne.enabled = !cameraOne.enabled;
            cameraTwo.enabled = !cameraTwo.enabled;
        }

        scoreText.text = "Točke: " + score.ToString();
    }

    void timerCount() 
    {
        timer += Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        string m = "";
        string s = "";
        if (minutes < 10)
        {
            m = "0" + minutes.ToString();
        }
        else
        {
            s = Mathf.RoundToInt(minutes).ToString();
        }


        if (seconds < 10)
        {
            s = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else 
        {
            s = Mathf.RoundToInt(seconds).ToString();
        }

        timerText.text = m + ":" + s + "  ";
    }


    void placeObjects() {
        foods.ForEach(food =>
        {
            Instantiate(foodPrefab, new Vector3(food.x, food.y, food.z), Quaternion.identity);
        });

        int ranNumber = Random.Range(0, 4);
        Instantiate(keyPrefab, new Vector3(key[ranNumber].x, key[ranNumber].y, key[ranNumber].z), Quaternion.identity);

        miners.ForEach(miner =>
        {
            Instantiate(minerPrefab, new Vector3(miner.x, miner.y, miner.z), Quaternion.identity);
        });
    }


    void initLocations()
    {
        if (difficulty == 0)
        {
            foods.Add(new Location(10.4f, 4f, 23.2f));
            foods.Add(new Location(-10f, 4f, 23.2f));
            foods.Add(new Location(8f, 4f, 12.5f));
            foods.Add(new Location(8f, 4f, 1f));
            foods.Add(new Location(-7f, 4f, 1.5f));
            foods.Add(new Location(-8.7f, 4f, 9.6f));
            foods.Add(new Location(-8.7f, 4f, 12.5f));
            foods.Add(new Location(-26.5f, 4f, 19f));
            foods.Add(new Location(-29f, 4f, -4f));
            foods.Add(new Location(-24f, 4f, -11f));
            foods.Add(new Location(13.5f, 4f, 1.7f));
            foods.Add(new Location(27f, 4f, -2f));
            


            miners.Add(new Location(-1.3f, 4f, 10.3f));
            miners.Add(new Location(2.5f, 4f, 5f));
            miners.Add(new Location(-28f, 4f, 0.2f));
            miners.Add(new Location(-23.2f, 4f, -20f));


            key.Add(new Location(-26.5f, 4f, 7.5f));
            key.Add(new Location(2f, 4f, -15f));
            key.Add(new Location(-29f, 4f, -8f));
            key.Add(new Location(-19.5f, 4f, 14f));
            key.Add(new Location(-14f, 4f, 19f));
        }
        /*
        else if (difficulty == 1)
        {
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());

            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());

            key.append(new Location());
            key.append(new Location());
            key.append(new Location());
            key.append(new Location());
            key.append(new Location());

        }
        else {
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());
            foods.append(new Location());

            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());
            miners.location(new Location());

            key.append(new Location());
            key.append(new Location());
            key.append(new Location());
            key.append(new Location());
            key.append(new Location());
        }*/
    }
}
