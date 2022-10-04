using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySeg : MonoBehaviour
{
    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    // Start is called before the first frame update
    void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }
    /*
    void FixedUpdate()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }
    */
    private void Update()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.deltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }

    public Vector3 getDirection()
    {
        if(ObjVelocity.normalized.x < 0)
        {
            return  new Vector3(-1, 0, 0);
        }
        else if (ObjVelocity.normalized.x > 0)
        {
            return new Vector3(1, 0, 0);
        }
        else if (ObjVelocity.normalized.y < 0)
        {
            return new Vector3(0, -1, 0);
        }
        else if (ObjVelocity.normalized.y > 0)
        {
            return new Vector3(0, 1, 0);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
