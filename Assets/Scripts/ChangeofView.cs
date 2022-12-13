using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.ShaderGraph.Internal;

public class ChangeofView : MonoBehaviour
{
    [SerializeField] List<GameObject> vCamList = new List<GameObject>();
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject cockpit;
    CinemachineVirtualCamera _currentCam;
    CinemachineBlendListCamera _blend;
    float timer = 0;
    public void Start()
    {
         timer = Time.time + 5;
        _blend = vCamList[2].GetComponent<CinemachineBlendListCamera>();
        _currentCam = vCamList[0].GetComponent<CinemachineVirtualCamera>();
        ChangeCameraPriority(_currentCam, 10);
    }
    private void Update()
    {
        CinematicScene();   
    }


    private void CockpitToThirdPerson() 
    {
      
            if (_currentCam == vCamList[0].GetComponent<CinemachineVirtualCamera>())
            {
             ship.SetActive(false);
             cockpit.SetActive(true);
            _blend.Priority = 8; 
            ChangeCameraPriority(_currentCam, 9);
            _currentCam = vCamList[1].GetComponent<CinemachineVirtualCamera>();
            _currentCam.Priority = 10;
            
            }
            else if (_currentCam == vCamList[1].GetComponent<CinemachineVirtualCamera>())
            {
                  ship.SetActive(true);
                  cockpit.SetActive(false);
                 _blend.Priority = 8;
                 ChangeCameraPriority(_currentCam, 9);
                 _currentCam = vCamList[0].GetComponent<CinemachineVirtualCamera>();
                 ChangeCameraPriority(_currentCam, 10);
            }

    }
    private void ChangeCameraPriority(CinemachineVirtualCamera cam, int priority) 
    {
        cam.Priority = priority;
    }


    private void CinematicScene() 
    {

        if (Input.anyKey || HasMouseMoved()) 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                timer = Time.time + 5;
                CockpitToThirdPerson();
            }

            _blend.Priority = 8;
            if(_currentCam == vCamList[0].GetComponent<CinemachineVirtualCamera>()) 
            {
                cockpit.SetActive(false);
                ship.SetActive(true);
            }
            else { cockpit.SetActive(true); ship.SetActive(false); }
            ChangeCameraPriority(_currentCam, 10);
            timer  = Time.time + 5;
            Debug.Log($"Time: {Time.time} TIMER: {timer}");       
        }
        
        if(Time.time > timer) 
        { 
            ship.SetActive(true);
            cockpit.SetActive(false);
            ChangeCameraPriority(_currentCam, 9);
            _blend.Priority = 10;
        }
        

    }
   private bool HasMouseMoved()
    {
        //I feel dirty even doing this 
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

}
