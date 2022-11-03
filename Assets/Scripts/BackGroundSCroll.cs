using UnityEngine;
using UnityEngine.UI;

public class BackGroundSCroll : MonoBehaviour
{
    [SerializeField] private RawImage _backGroundImage;
    [SerializeField] private float _xValue;
    [SerializeField] private float _yValue;

    
    void Update()
    {
       _backGroundImage.uvRect =new Rect(_backGroundImage.uvRect.x + _xValue * Time.deltaTime,_backGroundImage.uvRect.y + _yValue * Time.deltaTime,5,5);
    }
}
