using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void loadTutorial()
    {
        Snake.waitTime = 0.22f;
        SceneManager.LoadScene("Tutorial");
    }

    public void loadEasy()
    {
        Snake.waitTime = 0.22f;
        SceneManager.LoadScene("EasyLevel");
    }

    public void loadMedium()
    {
        Snake.waitTime = 0.18f;
        SceneManager.LoadScene("MediumLevel");
    }

    public void loadHard()
    {
        Snake.waitTime = 0.14f;
        SceneManager.LoadScene("MediumLevel");
    }
}
