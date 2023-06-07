using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameObject _runnerCam;
    [SerializeField] private GameObject _paintCam;

    private void Awake() 
    {
        _runnerCam.SetActive(true);
        _paintCam.SetActive(false);
    }

    private void OnEnable() 
    {
        Singleton.Instance.PhaseManager.onPaintingPhaseStart += SwitchCamera;
    }

    private void OnDisable() 
    {
        Singleton.Instance.PhaseManager.onPaintingPhaseStart -= SwitchCamera;
    }

    private void SwitchCamera()
    {
        _runnerCam.SetActive(false);
        _paintCam.SetActive(true);
    }
}
