using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snake;
    public GameObject head;
    public GameObject bodySeg;
    GameObject tailSeg;
    LinkedList<GameObject> snakeData;
    float offset;
    Vector3 prevPosition;
    GameObject prevSeg;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        snakeData = new LinkedList<GameObject>();
        snakeData.AddFirst(head);
        offset = -0.5f;
        Application.targetFrameRate = 30;
        prevPosition = new Vector3(0.0f, 1.0f, 0.0f);
        temp = new Vector3(0.0f, 1.0f, 0.0f);
        prevSeg = head;
        tailSeg = head;
    }

    public void grow()
    {
        //clear prevoius tail of "tailSeg" tag
        GameObject newBodySeg = Instantiate(bodySeg, snake.transform) as GameObject;
        snakeData.AddLast(newBodySeg);
        //Vector3 offsetPos = offset * tailSeg.GetComponent<Rigidbody2D>().velocity.normalized;
        newBodySeg.transform.position = tailSeg.transform.position + offset * tailSeg.GetComponent<BodySeg>().getDirection();
        tailSeg = newBodySeg;
    }

    // Update is called once per frame
    void Update()
    {
        // get enumerator
        LinkedList<GameObject>.Enumerator snakeEnum = snakeData.GetEnumerator();
        // go through each element in linkedList
        while (snakeEnum.MoveNext())
        {
            if (snakeEnum.Current == snakeData.First.Value)
            {
                //if(head.transform.position.normalized)
                prevPosition = snakeEnum.Current.transform.position;
                prevSeg = snakeEnum.Current;
            }
            else
            {
                temp = snakeEnum.Current.transform.position;
                // add offset in direction opposite the overall direction of the snake
                snakeEnum.Current.transform.position = prevPosition;
                //snakeEnum.Current.transform.position = prevPosition + offset * head.GetComponent<Head>().getDirection();
                //Debug.Log("head direction is: " + head.GetComponent<Head>().getDirection());
                // Vector3 = prevSeg.GetComponent<BodySeg>().getObjVelocity().normalized
                Debug.Log("prevSeg gameObject print: " + prevSeg);
                //+ offset * prevSeg.GetComponent<BodySeg>().getDirection();
                snakeEnum.Current.transform.position = prevPosition;
                //Debug.Log(prevSeg.GetComponent<Rigidbody2D>().velocity);
                //Debug.Log("vel normalized is: " + prevSeg.GetComponent<Rigidbody2D>().velocity.normalized);
                prevPosition = temp;
                prevSeg = snakeEnum.Current;
            }
            
        }
    }
}
