using UnityEngine;

public class ValveRotator : MonoBehaviour
{ 
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float minRotationAngle = 0f;
    [SerializeField] private float maxRotationAngle = -720;
    
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    private bool _isRotating;

    private float _rotationSumm = 0f;
    
    private void Update()
    {
        if(_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * sensitivity * Time.deltaTime;

            _rotationSumm += _rotation.y;

            if (_rotationSumm <= minRotationAngle && _rotationSumm >= maxRotationAngle)
            {
                transform.Rotate(_rotation);
                _mouseReference = Input.mousePosition;
                
            }
            else
            {
                if (_rotationSumm >minRotationAngle)
                    _rotationSumm = minRotationAngle;

                if (_rotationSumm < maxRotationAngle)
                    _rotationSumm = maxRotationAngle;
                
                _isRotating = false;
            }
        }
    }
     
    private void OnMouseDown()
    {
        _isRotating = true;
        _mouseReference = Input.mousePosition;
    }
     
    private void OnMouseUp()
    {
        _isRotating = false;
    }
}
