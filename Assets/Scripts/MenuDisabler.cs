
using UnityEngine;

public class MenuDisabler : MonoBehaviour
{
    [SerializeField]private GameManager _GameManager;
    // Start is called before the first frame update
    public void DisableMenu(){
        _GameManager.ContinuePlaying(transform.parent.gameObject);
    }
}
