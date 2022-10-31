using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prompt : MonoBehaviour
{

    public void loadTutorial()
    {
        Snake.waitTime = 0.2f;
        SceneManager.LoadScene("Tutorial");
    }

    public void loadEasy()
    {
        Snake.waitTime = 0.2f;
        SceneManager.LoadScene("EasyLevel");
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
