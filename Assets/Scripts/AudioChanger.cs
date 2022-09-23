using UnityEngine;

public class AudioChanger : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] clip;
    private int _clipIndex;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if(!_audioSource.isPlaying)
        {
            _clipIndex++;
            _audioSource.clip = clip[_clipIndex];
            _audioSource.Play();
        }

        if(_clipIndex > clip.Length-1){
            _clipIndex = 0;
        }
    }
}
