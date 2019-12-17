using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public bool vertical;
    public int speed;
    public int changeTime;
    public GameObject target;

    private Rigidbody rigidbody;
    private float timer;
    private int direction = 1;
    private Vector3 lookDirection;
    private int dwarfSeen;
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        timer = changeTime;
        dwarfSeen = 0;
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
        if (dwarfSeen <= 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
                if (vertical)
                {
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
        else 
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.06f);
            dwarfSeen--;
        }
    }

    void look() 
    {
        Debug.DrawRay(transform.position, lookDirection * 3, Color.green); 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, lookDirection, out hit, 3, LayerMask.GetMask("Berkmandlc")))
        {
            if (hit.collider != null)
            {
                dwarfSeen = 600;
                BerkmandlcManager manager = target.GetComponent<BerkmandlcManager>();
                manager.speed = 7;
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }
    }
}
