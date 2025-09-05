using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Methcounter : MonoBehaviour
{
    public int methcount = 0;
    private TMP_Text methCounter;
    // Start is called before the first frame update
    void Start()
    {
        methCounter = GetComponent<TMP_Text>();
        methCounter.text = "meth: " + methcount;
    }

    // Update is called once per frame
    public void Click()
    {
        methcount++;
        methCounter.text = "meth: " + methcount;
    }
}
