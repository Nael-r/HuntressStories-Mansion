using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtonUI : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private void Awake()
    {
        if(_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        transform.LookAt(_mainCamera.transform, Vector3.up);
    }

}
