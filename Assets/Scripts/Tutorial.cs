using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject checkpt1;
    public GameObject checkpt2;
    public GameObject checkpt3;
    public GameObject checkpt4;
    public GameObject checkpt5;

    public GameObject instr1;
    public GameObject instr2;
    public GameObject instr3;
    public GameObject instr4;
    public GameObject instr5;
    public GameObject instr6;

    private void Start()
    {
        setAllInactive();
        instr1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpt5 == null && ScoreManager.instance.GetScore() == 10)
        {
            setAllInactive();
            instr6.SetActive(true);
        }
        else if (checkpt4 == null)
        {
            setAllInactive();
            instr5.SetActive(true);
        }
        else if (checkpt3 == null)
        {
            setAllInactive();
            instr4.SetActive(true);
        }
        else if(checkpt2 == null)
        {
            setAllInactive();
            instr3.SetActive(true);
        }
        else if(checkpt1 == null)
        {
            setAllInactive();
            instr2.SetActive(true);
        }
    }

    void setAllInactive()
    {
        instr1.SetActive(false);
        instr2.SetActive(false);
        instr3.SetActive(false);
        instr4.SetActive(false);
        instr5.SetActive(false);
        instr6.SetActive(false);
    }
}
