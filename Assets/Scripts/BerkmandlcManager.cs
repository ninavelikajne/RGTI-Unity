using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerkmandlcManager : MonoBehaviour
{

    public int speed;
    void Start()
    {
        speed = 5;
    }

   
    void Update()
    {
        Debug.Log(transform.localPosition);
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
        GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector4(-1f * (mouseY * 90f), mouseX * 360f, transform.localRotation.z)));
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
            GameManager.score++;
        }
        else if (col.collider.tag == "Key") 
        {
            Destroy(col.gameObject);
            GameManager.keyIsCollected = true;
        }
        else if (col.collider.tag == "Home" && GameManager.keyIsCollected) 
        {
            ScenesManager.Victory();
        }
    }
}
