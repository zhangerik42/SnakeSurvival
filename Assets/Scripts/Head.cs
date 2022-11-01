using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    Vector3 direction;
    bool slowTimeEnabled;
    private AudioSource currBGMusicSource;

    public Snake parent;
    public GameObject timeBar;
    public GameObject blackEye;
    public GameObject blueEye;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 0);
        slowTimeEnabled = false;
        // there's prolly better way to do this, come back
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("TutorialBGMusic");
        }
        else if (SceneManager.GetActiveScene().name == "EasyLevel")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("EasyBGMusic");
        }
        else if(SceneManager.GetActiveScene().name == "MediumLevel")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("MediumBGMusic");
        }
        else if (SceneManager.GetActiveScene().name == "HardLevel")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("HardBGMusic");
        }
        currBGMusicSource.Play();
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


        // slowing time mechanic
        // don't allow this when game's 
        if (Time.timeScale != 0) {
            if (Input.GetKeyDown(KeyCode.Space) && !timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
            {
                if (!slowTimeEnabled)
                {
                    Time.timeScale = 0.5f;
                    slowTimeEnabled = true;
                    currBGMusicSource.pitch = 0.7f;
                    blueEye.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1.0f;
                    slowTimeEnabled = false;
                    currBGMusicSource.pitch = 1.0f;
                    blueEye.SetActive(false);
                }
            }

            if (slowTimeEnabled && !timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
            {
                timeBar.GetComponent<TimeBar>().DecrementTime();
            }
            else
            {
                slowTimeEnabled = false;
                timeBar.GetComponent<TimeBar>().IncrementTime();
                blueEye.SetActive(false);
            }

            if (timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
            {
                Time.timeScale = 1.0f;
                currBGMusicSource.pitch = 1.0f;
            }
        }
 
    }

    public bool isSnakeTime()
    {
        return slowTimeEnabled;
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

        if (col.gameObject.layer == 9)
        {
            Destroy(col.gameObject);
            timeBar.GetComponent<TimeBar>().GrowTimeBar();
        }

    }

}
