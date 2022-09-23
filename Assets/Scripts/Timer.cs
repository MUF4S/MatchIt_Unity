using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Slider slide;
    
    public float defaultTime;
    public float newTime;
    public bool stopTime = false;
    public float currentTime;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        slide.maxValue = newTime;
        defaultTime = newTime;
        currentTime = defaultTime;
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if(stopTime == false){
            currentTime -= Time.deltaTime;
        slide.value = currentTime;
        }
        
        Debug.Log("Stop time?: " + stopTime);
        
        if(currentTime <=0)
        {
            gm.GameOver("Sorry :(     End of Time.");
        }

    }

    public void ResetTimer(){
        currentTime = defaultTime;
    }
    public void StopTime(){
        stopTime = !stopTime;
    }
}
