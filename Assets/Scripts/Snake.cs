using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snake;
    public GameObject head;
    public GameObject bodySeg;
    LinkedList<GameObject> snakeData;
    float offset;
    Vector3 prevPosition;
    Vector3 temp;
    float timeSinceLastStep = 0.0f;
    float waitTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        snakeData = new LinkedList<GameObject>();
        snakeData.AddFirst(head);
        offset = 1.0f;
        prevPosition = new Vector3(0.0f, 1.0f, 0.0f);
        temp = new Vector3(0.0f, 1.0f, 0.0f);
    }

    public void grow()
    {
        //clear prevoius tail of "tailSeg" tag
        GameObject newBodySeg = Instantiate(bodySeg, new Vector3(-50,-100,0), Quaternion.identity) as GameObject;
        snakeData.AddLast(newBodySeg);
    }

    // Update is called once per frame
    void Update()
    {
        // if time since lastStep > timeStep, call step
        // in step move the head, then update every other element in the list

        timeSinceLastStep += Time.deltaTime;
        if (timeSinceLastStep > waitTime)
        {
            timeSinceLastStep -= waitTime;
            head.transform.position = head.gameObject.transform.position + offset * head.GetComponent<Head>().GetDirection();
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
                    snakeEnum.Current.transform.position = prevPosition;
                    prevPosition = temp;
                }

            }
        }
    }
}
