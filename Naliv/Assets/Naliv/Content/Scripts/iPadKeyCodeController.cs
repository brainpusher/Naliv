using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iPadKeyCodeController : MonoBehaviour
{
    [SerializeField] private GameObject iPadVerticalModel;
    [SerializeField] private GameObject iPadHorizontalModel;

    private GameObject _currentIPadModel;
    
    private void Start()
    {
        _currentIPadModel = iPadVerticalModel;
    }
    
    private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EnableIPad();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToVertical();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToHorizontal();
        }
    }

    private void SwitchToVertical()
    {
        iPadHorizontalModel.SetActive(false);
        iPadVerticalModel.SetActive(true);
        _currentIPadModel = iPadVerticalModel;
    }
    
    private void SwitchToHorizontal()
    {
        iPadHorizontalModel.SetActive(true);
        iPadVerticalModel.SetActive(false);
        _currentIPadModel = iPadHorizontalModel;
    }

    private void EnableIPad()
    {
        if(!_currentIPadModel.activeSelf)
            _currentIPadModel.SetActive(true);
    }
}
