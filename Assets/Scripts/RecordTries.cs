using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordTries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // at every new attempt of the game, record it as a "try"
        if (SceneManager.GetActiveScene().name == "EasyLevel")
        {
            int smurfTries = PlayerPrefs.GetInt("SmurfTries");
            PlayerPrefs.SetInt("SmurfTries", smurfTries + 1);
        }
        if (SceneManager.GetActiveScene().name == "MediumLevel")
        {
            int medusaTries = PlayerPrefs.GetInt("MedusaTries");
            PlayerPrefs.SetInt("MedusaTries", medusaTries + 1);
        }
        PlayerPrefs.Save();
    }
}
