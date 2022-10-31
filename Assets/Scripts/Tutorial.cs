using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject checkpt1;
    public GameObject checkpt2;
    public GameObject checkpt3;
    public GameObject checkpt4;

    public GameObject instr1;
    public GameObject instr2;
    public GameObject instr3;
    public GameObject instr4;
    public GameObject instr5;

    private void Start()
    {
        instr1.SetActive(true);
        instr2.SetActive(false);
        instr3.SetActive(false);
        instr4.SetActive(false);
        instr5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpt4 == null)
        {
            instr4.SetActive(false);
            instr5.SetActive(true);
        }
        else if (checkpt3 == null)
        {
            instr3.SetActive(false);
            instr4.SetActive(true);
        }
        else if(checkpt2 == null)
        {
            instr2.SetActive(false);
            instr3.SetActive(true);
        }
        else if(checkpt1 == null)
        {
            instr1.SetActive(false);
            instr2.SetActive(true);
        }
    }
}
