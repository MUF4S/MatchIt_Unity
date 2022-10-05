using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagment : MonoBehaviour
{
    public int sceneIndex;
    private void Awake() {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeScene);
    }
    public void ChangeScene(){
        SceneManager.LoadScene(sceneIndex);
    }
}
