using Unity.VisualScripting;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    //Ray _ray;
    //RaycastHit _hit;
    //[SerializeField] private GameObject _obj;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _fromCam;
    [SerializeField] private Transform _toCam;
    [SerializeField] private GameObject _title;
    [SerializeField] private float _hMoveTime = 2f;
    [SerializeField] private float _vMoveTime = 1f;
    private float _delayTime = 0f;

    void Start()
    {
        //Vector3 _cam = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
        
        }
        _delayTime += Time.deltaTime;
        if (_delayTime >= 3f)
        {
            _fromCam.transform.position = Vector3.Lerp(_fromCam.position, _toCam.position, _hMoveTime * Time.deltaTime);
            //_cam.fieldOfView = 80;

            if (_delayTime >= 4f)
            {
                _fromCam.transform.rotation = Quaternion.Slerp(_fromCam.transform.rotation, _toCam.rotation, _vMoveTime * Time.deltaTime);

                if (_delayTime >= 4.5f)
                {
                    _title.SetActive(false);
                }
            }
        }
    }
}