using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public int scoreToWin;
    bool winScreenLoaded = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((ScoreManager.instance.GetScore() == scoreToWin) && winScreenLoaded == false)
        {
            // AudioManager.instance.Play("Win");
            SceneManager.LoadScene("WinScreen");
            winScreenLoaded = true;
            ScoreManager.instance.resetScore();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype");
            winScreenLoaded = false;
        }
    }
}