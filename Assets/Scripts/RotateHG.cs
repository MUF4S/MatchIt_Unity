using UnityEngine;
public class RotateHG : MonoBehaviour
{ 
    private void Update()
    { 
        transform.Rotate(new Vector3(0f,0f,-100f) * Time.deltaTime);
    }
}
