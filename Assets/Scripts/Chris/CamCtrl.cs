using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamCtrl : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    [SerializeField] private GameObject _obj;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _fromCam;
    [SerializeField] private Transform _toCam1;
    [SerializeField] private Transform _toCam2;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private float _rotationAxisSpeed_x = 0.1f;
    [SerializeField] private float _timeCount = 0f;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("LeftMouseButtonDown");
            _ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log(_hit.collider.gameObject.name);
                _obj = _hit.collider.gameObject;
                if (_obj.name == "Table" || _obj.name == "Menu")
                {
                    Debug.Log("Hit" + _obj.name);
                    _cam.fieldOfView = 10;
                    //var step = _rotationAxisSpeed_x * Time.deltaTime;
                    //_cam.transform.rotation = Quaternion.RotateTowards(transform.rotation, _toCam1.rotation, step);
                    //_cam.transform.position = Vector3.Lerp(_fromCam.position, _toCam1.position, 0.1f);
                    //_cam.transform.rotation = Quaternion.Slerp(_fromCam.rotation, _toCam1.rotation, 1f);
                }
            }
        }
        
    }
}
