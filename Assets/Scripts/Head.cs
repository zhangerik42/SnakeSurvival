using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10;
    Vector3 direction;
    Vector3 displacement;

    public Snake parent;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(1, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            direction = new Vector3(-1, 0, 0);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            direction = new Vector3(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = new Vector3(0, -1, 0);
        }
        //Debug.Log("default: " + speedVect);
        //Debug.Log("normalized: " + speedVect.normalized);
        // not quite sure why normalizing speedvect causes continual movement when the normalized and un-normalized 
        // vectors are the same 
        displacement = direction.normalized * speed * Time.deltaTime;
        //Debug.Log("currentPosition is" + rb.transform.position);
        rb.transform.position += displacement;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

void OnCollisionEnter2D(Collision2D col)
    {
        // if colliding with food, increase size of snake by one segment & destroy food. 
        if(col.gameObject.layer == 6)
        {
            parent.grow();
            Debug.Log("OnCollisionEnter2D");
            Destroy(col.gameObject);
        }
    }

}
