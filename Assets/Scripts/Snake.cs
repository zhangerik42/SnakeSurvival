using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject head;
    public GameObject bodySeg;
    GameObject tailSeg;
    LinkedList<GameObject> snakeData;
    float offset;
    Vector3 prevPosition;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        snakeData = new LinkedList<GameObject>();
        snakeData.AddFirst(head);
        offset = -0.5f;
        prevPosition = new Vector3(0.0f, 1.0f, 0.0f);
        temp = new Vector3(0.0f, 1.0f, 0.0f);
    }

    public void grow()
    {
        GameObject newBodySeg = Instantiate(bodySeg) as GameObject;
        snakeData.AddLast(newBodySeg);
        newBodySeg.transform.position = new Vector3(0,0,0);
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
            }
            else
            {
                temp = snakeEnum.Current.transform.position;
                // add offset in direction opposite the overall direction of the snake
                //+ offset * head.GetComponent<Head>().getDirection()
                snakeEnum.Current.transform.position = prevPosition;
                prevPosition = temp;
            }
            
        }
    }
}
