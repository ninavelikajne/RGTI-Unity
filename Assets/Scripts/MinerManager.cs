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
    private Vector3 lookDirection;
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        timer = changeTime;
        if (vertical) 
        {
            lookDirection = new Vector3(0,0,1);
        }
        else 
        {
            lookDirection = new Vector3(1,0,0);
        }
    }

    void Update()
    {
        move();
        look();
    }

    void move() 
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            if (vertical)
            {
                Debug.Log(lookDirection.y);
                lookDirection.z = -lookDirection.z;
            }
            else 
            {
                lookDirection.x = -lookDirection.x;
            }
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

    void look() 
    {
        Debug.DrawRay(transform.position, lookDirection * 5, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, lookDirection * 5, out hit, 3f, LayerMask.GetMask("Berkmandlc"))) 
        {
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }
    }
}
