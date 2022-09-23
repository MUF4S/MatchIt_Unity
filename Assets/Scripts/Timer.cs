using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public Slider slide;
    public GameManager gm;
    
    public float defaultTime;
    public float newTime;
    public bool stopTime = false;
    public float currentTime;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        slide.maxValue = newTime;
        defaultTime = newTime;
        currentTime = defaultTime;
    }
    private void Update()
    {
        if(stopTime == false){
            currentTime -= Time.deltaTime;
            slide.value = currentTime;
        }
        
        print($"Stop time?: {stopTime}");
        
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
