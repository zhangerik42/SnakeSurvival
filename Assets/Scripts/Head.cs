using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    public AudioManager audioManager;
    Vector3 direction;
    bool slowTimeEnabled;

    public Snake parent;
    public Image timeBar;
    public GameObject blackEye;
    public GameObject greenEye;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 0);
        slowTimeEnabled = false;
        AudioManager.instance.Play("MediumBGMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("right");
            direction = new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("left");
            direction = new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            direction = new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("down");
            direction = new Vector3(0, -1, 0);
        }

        
        // slowing time mechanic code below
        if (Input.GetKeyDown(KeyCode.Space) && !timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
        {
            if (!slowTimeEnabled)
            {
                Time.timeScale = 0.5f;
                slowTimeEnabled = true;
                AudioManager.instance.GetAudioSource("MediumBGMusic").pitch = 0.7f;
                greenEye.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                slowTimeEnabled = false;
                AudioManager.instance.GetAudioSource("MediumBGMusic").pitch = 1.0f;
                greenEye.SetActive(false);
            }
        }

        if (Time.timeScale != 1.0f)
        {
            timeBar.GetComponent<TimeBar>().DecrementTime();
            Debug.Log("DECREMENTING TIME");
        }
        else
        {
            slowTimeEnabled = false;
            timeBar.GetComponent<TimeBar>().IncrementTime();
            greenEye.SetActive(false);
        }

        if (timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
        {
            Time.timeScale = 1.0f;
            AudioManager.instance.GetAudioSource("MediumBGMusic").pitch = 1.0f;
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
            AudioManager.instance.Play("Eat");
        }

        if((col.gameObject.layer == 7 || col.gameObject.layer == 8) && !slowTimeEnabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
