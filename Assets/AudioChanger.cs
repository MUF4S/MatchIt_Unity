using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clip;
    int i = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(i + " Playlista");
        if(!audioSource.isPlaying)
        {
            i++;
            audioSource.clip = clip[i];
            audioSource.Play();
        }

        if(i > clip.Length-1){
            i = 0;
        }
    }
}
