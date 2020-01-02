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

    public GameObject[] foodPrefab;
    public GameObject minerPrefab;
    public GameObject keyPrefab;

    public Camera cameraOne;
    public Camera cameraTwo;
    public Text scoreText;
    public Text timerText;

    private float timer;

    private List<Location> foods = new List<Location>();
    private List<Miner> miners = new List<Miner>();
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
            int n = Random.Range(0, 5); 
            GameObject foodObject = Instantiate(foodPrefab[n], new Vector3(food.x, 3, food.z), Quaternion.identity);
            foodObject.transform.Rotate(-90f, 0f, 0f);
        });

        int ranNumber = Random.Range(0, 4);
        Instantiate(keyPrefab, new Vector3(key[ranNumber].x, key[ranNumber].y, key[ranNumber].z), Quaternion.identity);

        miners.ForEach(miner =>
        {
            GameObject minerObject = Instantiate(minerPrefab, new Vector3(miner.location.x, miner.location.y, miner.location.z), Quaternion.identity);
            MinerManager minerManager = minerObject.GetComponent<MinerManager>();
            minerManager.vertical = miner.vertical;
            minerManager.speed = miner.speed;
            minerManager.changeTime = miner.changeTime;
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
            


            miners.Add(new Miner(new Location(-1.3f, 4f, 10.3f), false, 3, 3));
            miners.Add(new Miner(new Location(-7f, 4f, 5f), false, 3, 3));
            miners.Add(new Miner(new Location(-28f, 4f, 0.2f), false, 2, 3));
            miners.Add(new Miner(new Location(-23.2f, 4f, -19.5f), false, 3, 4));


            key.Add(new Location(-27f, 3.5f, 7.5f));
            key.Add(new Location(2f, 3.5f, -15f));
            key.Add(new Location(-29f, 3.5f, -8f));
            key.Add(new Location(-19.5f, 3.5f, 14f));
            key.Add(new Location(-14f, 3.5f, 19f));
        }
        else if (difficulty == 1)
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



            miners.Add(new Miner(new Location(-1.3f, 4f, 10.3f), false, 3, 3));
            miners.Add(new Miner(new Location(-7f, 4f, 5f), false, 3, 3));
            miners.Add(new Miner(new Location(-28f, 4f, 0.2f), false, 2, 3));
            miners.Add(new Miner(new Location(-23.2f, 4f, -19.5f), false, 3, 4));
            miners.Add(new Miner(new Location(-5f, 4f, 23.3f), false, 3, 3));
            miners.Add(new Miner(new Location(-9.5f, 4f, -11.5f), false, 3, 3));   
            miners.Add(new Miner(new Location(-23f, 4f, -9f), true, 3, 3));



            key.Add(new Location(-27f, 3.5f, 7.45f));
            key.Add(new Location(2f, 3.5f, -14.4f));
            key.Add(new Location(-28f, 3.5f, -8.4f));
            key.Add(new Location(-19.34f, 3.5f, 14f));
            key.Add(new Location(-14.5f, 3.5f, 19.2f));

        }
        else {
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



            miners.Add(new Miner(new Location(-1.3f, 4f, 10.3f), false, 3, 3));
            miners.Add(new Miner(new Location(-7f, 4f, 5f), false, 3, 3));
            miners.Add(new Miner(new Location(-28f, 4f, 0.2f), false, 2, 3));
            miners.Add(new Miner(new Location(-23.2f, 4f, -19.5f), false, 3, 4));
            miners.Add(new Miner(new Location(-5f, 4f, 23.3f), false, 3, 3));
            miners.Add(new Miner(new Location(-9.5f, 4f, -11.5f), false, 3, 3));
            miners.Add(new Miner(new Location(-23f, 4f, -9f), true, 3, 3));
            miners.Add(new Miner(new Location(5.6f, 4f, -5.5f), true, 3, 3));



            key.Add(new Location(-27f, 3.5f, 7.5f));
            key.Add(new Location(2f, 3.5f, -15f));
            key.Add(new Location(-29f, 3.5f, -8f));
            key.Add(new Location(-19.5f, 3.5f, 14f));
            key.Add(new Location(-14f, 3.5f, 19f));
        }
    }
}
