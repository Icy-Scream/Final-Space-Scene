using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ChangeofView : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> cinemachineVirtualCameras = new List<CinemachineVirtualCamera>();
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject cockpit;
    CinemachineVirtualCamera _currentCam;
    public void Start()
    {
        _currentCam = cinemachineVirtualCameras[0];
        ChangeCameraPriority(_currentCam, 10);
    }
    private void Update()
    {
        Debug.Log(_currentCam);
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (_currentCam == cinemachineVirtualCameras[0]) 
            {
                ship.SetActive(false);
                cockpit.SetActive(true);
                ChangeCameraPriority(_currentCam, 9);
                _currentCam = cinemachineVirtualCameras[1];
                ChangeCameraPriority(_currentCam, 10);
            } 
          else if (_currentCam == cinemachineVirtualCameras[1]) 
            {
                ship.SetActive(true);
                cockpit.SetActive(false);
                ChangeCameraPriority(_currentCam, 9);
                _currentCam = cinemachineVirtualCameras[0];
                ChangeCameraPriority(_currentCam, 10);
            }
        }
    }



    private void ChangeCameraPriority(CinemachineVirtualCamera cam, int priority) 
    {
        cam.Priority = priority;
    }
}
