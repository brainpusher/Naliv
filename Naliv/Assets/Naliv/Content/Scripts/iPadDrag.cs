using UnityEngine;

public class iPadDrag : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    private bool _mouseState;
    private GameObject _target;
    private  Vector3 _screenSpace;
    private Vector3 _offset;
    
    private void Update ()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            RaycastHit hitInfo;
            _target = GetClickedObject (out hitInfo);
            
            if (_target != null) 
            {
                _mouseState = true;
                _screenSpace = mainCamera.WorldToScreenPoint (_target.transform.position);
                _offset = _target.transform.position - mainCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenSpace.z));
            }
        }
        
        if (Input.GetMouseButtonUp (0))
            _mouseState = false;
        
        if (_mouseState) 
        {
            var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenSpace.z);
            var curPosition = mainCamera.ScreenToWorldPoint (curScreenSpace) + _offset;
            _target.transform.position = curPosition;
            Debug.Log("curPosition = " + curPosition);
        }
    }
    
    private GameObject GetClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
