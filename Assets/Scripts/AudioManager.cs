using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public static int Audioindex;
    private void Awake() {
        Audioindex++;
        print($"Źródła dźwięku: {Audioindex}");
        _audioSource = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(_audioSource);
    }
}
