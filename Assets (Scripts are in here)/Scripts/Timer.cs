using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool finished = false;
    public bool running = true;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (running == true)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2"); // defines only 2 decimals in the seconds float

            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            timerText.color = Color.yellow;
        }
           
            

       

        
    }


}
