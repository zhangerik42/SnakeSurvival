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
    public float waitTime;
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
        // 2nd block gets the first block's exact position
        timeSinceLastStep += Time.deltaTime;
        if (timeSinceLastStep > waitTime)
        {
            timeSinceLastStep -= waitTime;
            // move head
            //head.transform.position = head.gameObject.transform.position + offset * head.GetComponent<Head>().GetDirection();
            LinkedList<GameObject>.Enumerator snakeEnum = snakeData.GetEnumerator();
            // go through each element in linkedList
            while (snakeEnum.MoveNext())
            {
                if (snakeEnum.Current == snakeData.First.Value)
                {
                    prevPosition = snakeEnum.Current.transform.position;
                    head.transform.position = head.gameObject.transform.position + offset * head.GetComponent<Head>().GetDirection();
                }
                else
                {
                    temp = snakeEnum.Current.transform.position;
                    snakeEnum.Current.transform.position = prevPosition;
                    prevPosition = temp;
                }

            }
        }
    }
}
