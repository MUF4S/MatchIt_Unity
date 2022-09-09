using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;


    
   public void Play(){
    DontDestroyOnLoad(audioSource);
    SceneManager.LoadScene(1);
   }
}
