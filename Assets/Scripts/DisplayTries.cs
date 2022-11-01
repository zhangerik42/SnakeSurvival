using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayTries : MonoBehaviour
{
    public TextMeshProUGUI tries;
    // Start is called before the first frame update
    void Start()
    {
        // SmurfTries records # of deaths, add 1 to include first try.
        if (SceneManager.GetActiveScene().name == "WinSmurf")
        {
            tries.text = PlayerPrefs.GetInt("SmurfTries").ToString();
        }

        if (SceneManager.GetActiveScene().name == "WinMedusa")
        {
            tries.text = PlayerPrefs.GetInt("MedusaTries").ToString();
        }

    }

}
