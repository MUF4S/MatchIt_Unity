using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slide;
    private float defaultTime;
    public float newTime;
   
    private float currentTime;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        slide.maxValue = newTime;
        defaultTime = newTime;
        currentTime = defaultTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        slide.value = currentTime;
        
        if(currentTime <=0)
        {
            gm.GameOver("Sorry :(     End of Time.");
        }

    }

    public void ResetTimer(){
        currentTime = defaultTime;
    }
}
