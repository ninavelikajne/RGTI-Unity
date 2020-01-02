using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerManager : MonoBehaviour
{
    public bool vertical;
    public int speed;
    public int changeTime;
    public GameObject target;
    private Vector3 initLocation;
    private bool following;
    private Rigidbody rigidbody;
    private float timer;
    private int direction = 1;
    private Vector3 lookDirection;
    private int dwarfSeen;
    void Start()
    {
  
        initLocation = transform.position;
        following = false;
        rigidbody = GetComponent<Rigidbody>();
        timer = changeTime;
        dwarfSeen = 0;
        if (vertical) 
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            lookDirection = new Vector3(0,0,1);

        }
        else 
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            lookDirection = new Vector3(1,0,0);
            transform.Rotate(0f, 90f, 0f);
        }
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        move();
        look();
    }

    void move() 
    {
        if (following && dwarfSeen == 0) {
            transform.position = initLocation;
            following = false;
        }
        if (dwarfSeen <= 0)
        {   
            
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
                GetComponent<Rigidbody>().freezeRotation = false;
                if (vertical)
                {
                    lookDirection.z = -lookDirection.z;
                    transform.Rotate(0f, 180f, 0f);

                }
                else
                {
                    lookDirection.x = -lookDirection.x;
                    transform.Rotate(0f, 180f, 0f);
                }
                GetComponent<Rigidbody>().freezeRotation = true;
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
            Vector3 targetDirection = target.transform.position - transform.position;
            this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDirection, 1.0f * Time.deltaTime, 0.0f));
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.06f);
            dwarfSeen--;   
        }
    }

    void look() 
    {
        Debug.DrawRay(transform.position, lookDirection * 7, Color.green); 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, lookDirection, out hit, 7, LayerMask.GetMask("Berkmandlc")))
        {
            if (hit.collider != null)
            {
                following = true;
                target = hit.collider.gameObject;
                dwarfSeen = 600;
                BerkmandlcManager manager = target.GetComponent<BerkmandlcManager>();
                manager.speed = 7;
            }
        }
    }
}
