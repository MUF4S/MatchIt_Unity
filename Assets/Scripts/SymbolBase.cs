using UnityEngine;


public class SymbolBase : MonoBehaviour {

    [SerializeField]
    public Sprite[] image;
    public static SymbolBase Instance;

    private void Awake() {
        Instance = this;
    }    
}
