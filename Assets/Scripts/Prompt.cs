using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prompt : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Prototype");
        }
    }

    public void loadEasy()
    {
        Snake.waitTime = 0.2f;
        SceneManager.LoadScene("Prototype");
    }

    public void loadMedium()
    {
        Snake.waitTime = 0.15f;
        SceneManager.LoadScene("MediumLevel");
    }

    public void loadHard()
    {
        Snake.waitTime = 0.12f;
        SceneManager.LoadScene("MediumLevel");
    }
}
