using UnityEngine;

public class iPadHomeButton : MonoBehaviour
{
    [SerializeField] private GameObject iPadModel;
    
    private void OnMouseDown()
    {
        iPadModel.SetActive(false);
    }
}
