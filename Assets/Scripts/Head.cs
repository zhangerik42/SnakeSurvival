using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    Vector3 direction = new Vector3(0, 0, 0);
    bool slowTimeEnabled = false;
    private AudioSource currBGMusicSource;

    public Snake parent;
    public GameObject timeBar;
    public GameObject blackEye;
    public GameObject blueEye;
    public GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("TutorialBGMusic");
        }
        else if (SceneManager.GetActiveScene().name == "EasyLevel")
        {
            currBGMusicSource = AudioManager.instance.GetAudioSource("EasyBGMusic");
        }
        else if (SceneManager.GetActiveScene().name == "MediumLevel")
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
            prompt.SetActive(false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("left");
            direction = new Vector3(-1, 0, 0);
            prompt.SetActive(false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            direction = new Vector3(0, 1, 0);
            prompt.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("down");
            direction = new Vector3(0, -1, 0);
            prompt.SetActive(false);
        }

        // don't allow snake time when game's paused
        if (Time.timeScale != 0)
        {
            // if space is pressed either start slow time or disenable slow time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!slowTimeEnabled)
                {
                    Time.timeScale = 0.5f;
                    currBGMusicSource.pitch = 0.7f;
                    slowTimeEnabled = true;
                    blueEye.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1.0f;
                    currBGMusicSource.pitch = 1.0f;
                    slowTimeEnabled = false;
                    blueEye.SetActive(false);
                }
            }
            // decrement time bar during snake time
            if (slowTimeEnabled && !timeBar.GetComponent<TimeBar>().IsTimeBarDepleted())
            {
                timeBar.GetComponent<TimeBar>().DecrementTime();
            }
            // handles case where time bar hits 0
            else
            {
                if (slowTimeEnabled)
                {
                    Time.timeScale = 1.0f;
                    currBGMusicSource.pitch = 1.0f;
                    blueEye.SetActive(false);
                    slowTimeEnabled = false;
                }
                timeBar.GetComponent<TimeBar>().IncrementTime();
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
        // food 
        if (col.gameObject.layer == 6)
        {
            parent.grow();
            ScoreManager.instance.AddPoint();
            Destroy(col.gameObject);
            AudioManager.instance.Play("Eat");
        }

        // wall / snake
        if ((col.gameObject.layer == 7 || col.gameObject.layer == 8) && !slowTimeEnabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        // time ball
        if (col.gameObject.layer == 9)
        {
            Destroy(col.gameObject);
            timeBar.GetComponent<TimeBar>().GrowTimeBar();
        }

    }

}
