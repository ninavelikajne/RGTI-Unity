using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public bool vertical;
    public int speed;
    public int changeTime;

    private Rigidbody rigidbody;
    private float timer;
    private int direction = 1;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timer = changeTime;
    }

    void Update()
    {
        move();
    }

    void move() 
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector3 position = rigidbody.position;

        if (vertical)
        {
            position.z = position.z + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody.MovePosition(position);
    }
}
