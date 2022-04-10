using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    private float time;
    public TMPro.TextMeshProUGUI timer;
    public TMPro.TextMeshProUGUI loseText;
    // Start is called before the first frame update
    void Start()
    {
        time = 15f;
        loseText.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        string tStr = "Time Remaining: " + time.ToString("F0");
        if (time > 0)
        {
            timer.text = tStr;
        }
        else {
            timer.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            loseText.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            loseText.text = "You've been caught!";
        }
    }
}
