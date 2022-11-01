using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private const int TUTORIAL_SCORE_TO_WIN = 1000;
    private const int LEVEL_1_SCORE_TO_WIN = 35;
    private const int LEVEL_2_SCORE_TO_WIN = 60;
    private const int LEVEL_3_SCORE_TO_WIN = 63;
    public static GameStateManager instance;

    private int scoreToWin;
    bool winScreenLoaded = false;
    private Scene currScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        currScene = SceneManager.GetActiveScene();
        if (currScene.name != "WinScreen")
        {
            if (currScene.name == "Tutorial")
            {
                scoreToWin = TUTORIAL_SCORE_TO_WIN;
            }
            if (currScene.name == "EasyLevel")
            {
                scoreToWin = LEVEL_1_SCORE_TO_WIN;
            }
            if (currScene.name == "MediumLevel")
            {
                scoreToWin = LEVEL_2_SCORE_TO_WIN;
            }
            if (currScene.name == "HardLevel")
            {
                scoreToWin = LEVEL_3_SCORE_TO_WIN;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currScene.name != "WinScreen")
        {
            if ((ScoreManager.instance.GetScore() == scoreToWin) && winScreenLoaded == false)
            {
                AudioManager.instance.Play("Win");
                winScreenLoaded = true;
                ScoreManager.instance.resetScore();
                if (currScene.name == "EasyLevel")
                {
                    SceneManager.LoadScene("WinSmurf");
                }
                if (currScene.name == "MediumLevel")
                {
                    SceneManager.LoadScene("WinMedusa");
                }
            }

        }
    }
}