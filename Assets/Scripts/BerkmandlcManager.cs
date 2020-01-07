using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BerkmandlcManager : MonoBehaviour
{
    public AudioClip eatingSound;
    public AudioClip drinkingSound;
    public AudioClip keySound;
    public Text findKey;


    public int speed;
    void Start()
    {
        speed = 3;
    }

   
    void Update()
    {
        if (!GameManager.pause)
        {
            move();
        }

    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.right * speed * Time.deltaTime;
            position[1] = 0f;
            GetComponent<Rigidbody>().MovePosition(transform.localPosition-position);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.right * speed * Time.deltaTime;
            position[1] = 0f;
            GetComponent<Rigidbody>().MovePosition(transform.localPosition + position);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = transform.forward * speed * Time.deltaTime;
            position[1] = 0f;
            GetComponent<Rigidbody>().MovePosition(transform.localPosition + position);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = transform.forward * speed * Time.deltaTime;
            position[1] = 0f;
            GetComponent<Rigidbody>().MovePosition(transform.localPosition - position);
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * 2, 0);
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y") *1, 0, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Miner")
        {
            ScenesManager.GameOver();
        }
        else if (col.collider.tag == "Food")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = eatingSound;
            GetComponent<AudioSource>().Play();
            GameManager.score++;
        }
        else if (col.collider.tag == "Drink")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = drinkingSound;
            GetComponent<AudioSource>().Play();
            GameManager.score++;
        }
        else if (col.collider.tag == "Key")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().clip = keySound;
            GetComponent<AudioSource>().Play();
            GameManager.keyIsCollected = true;
        }
        else if (col.collider.tag == "Home" && GameManager.keyIsCollected)
        {
            ScenesManager.Victory();
        }
        else if (col.collider.tag == "Home" && !GameManager.keyIsCollected)
        {
            findKey.text = "NAJPREJ POIŠČI KLJUČ!";
            Invoke("Hide", 3);
        }
    }

    void Hide() {
        findKey.text = "";
    }
}
