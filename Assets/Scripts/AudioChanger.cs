using UnityEngine;
using UnityEngine.UI;

public class AudioChanger : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private Image _image;
    public AudioClip[] clip;
    private int _clipIndex;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(_audioSource);
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

    public void MuteAudio(){
        gameObject.SetActive(!gameObject.active);
        _image.gameObject.SetActive(!gameObject.active);
    }
}
