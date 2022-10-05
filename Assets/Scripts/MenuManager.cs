using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake() {
        DontDestroyOnLoad(audioSource);
    }
}
