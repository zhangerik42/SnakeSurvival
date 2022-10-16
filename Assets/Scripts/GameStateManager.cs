using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    bool winScreenLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((ScoreManager.instance.GetScore() == 10) && winScreenLoaded == false)
        {
            SceneManager.LoadScene("WinScreen");
            winScreenLoaded = true;
            ScoreManager.instance.resetScore();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype");
            winScreenLoaded = false;
            Debug.Log("reload game");
        }
    }
}
