using UnityEngine;

     
public class MovementController : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float gravity = 20.0f;
    
    [Header("Mouse Look settings")]
    [SerializeField] private float sensitivityX = 15F;
    [SerializeField] private float sensitivityY = 15F;
    [SerializeField] private float minimumY = -60F;
    [SerializeField] private float maximumY = 60F;
    
    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes = RotationAxes.MouseXAndY;
    private Vector3 _moveDirection = Vector3.zero;
    
    private float _rotationY = 0F;
    
    private void Update()
    {
        if (characterController.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection) * speed;
            _moveDirection *= speed;
        }
        _moveDirection.y -= gravity * Time.deltaTime; 
        characterController.Move(_moveDirection * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                _rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                _rotationY = Mathf.Clamp(_rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                _rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                _rotationY = Mathf.Clamp(_rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-_rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}