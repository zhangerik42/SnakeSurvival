using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10;
    Vector3 direction;
    int size = 0;

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
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

void OnCollisionEnter2D(Collision2D col)
    {
        // if colliding with food, increase size of snake by one segment & destroy food. 
        if(col.gameObject.layer == 6)
        {
            parent.grow();
            ScoreManager.instance.AddPoint();
            Destroy(col.gameObject);
        }

        if(col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
