using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerkmandlcManager : MonoBehaviour
{

    private int speed; 

    void Start()
    {
        speed = 5;
    }

   
    void Update()
    {
        if (!PauseButton.pause)
        {
            move();
        }
        else 
        {
            transform.localRotation = Quaternion.Euler(new Vector4(0, 0, 0));
        }
      
    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.right * speed * Time.deltaTime;
            position[1] = 0f;
            transform.localPosition -= position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.right * speed * Time.deltaTime;
            position[1] = 0f;
            transform.localPosition += position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = transform.forward * speed * Time.deltaTime;
            position[1] = 0f;
            transform.localPosition += position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = transform.forward * speed * Time.deltaTime;
            position[1] = 0f;
            transform.localPosition -= position;
        }

        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        if (mouseY > 0.1f) 
        {
            mouseY = 0.1f;
        }
        if (mouseY < -0.1f)
        {
            mouseY = -0.1f;
        }
        transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 90f), mouseX * 360f, transform.localRotation.z));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Miner")
        {
            ScenesManager.GameOver();
        }
        else if (col.tag == "Food") 
        {
            GameManager.score++;
        }
        else if (col.tag == "Key") 
        {
            GameManager.keyIsCollected = true;
        }
        else if (col.tag == "Home" && GameManager.keyIsCollected) 
        {
            ScenesManager.Victory();
        }
    }
}
