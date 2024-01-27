using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    [SerializeField] private GameObject _obj;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _fromCam;
    [SerializeField] private Transform _toCam;
    [SerializeField] private Transform _menu;
    [SerializeField] private float _horizontalMoveSpeed = 2f;
    [SerializeField] private float _verticalMoveSpeed = 1.5f;
    private float delayTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log(_hit.collider.gameObject.name);
                _obj = _hit.collider.gameObject;
                if (_obj.name == "Table" || _obj.name == "Menu")
                {
                    Debug.Log("Hit" + _obj.name);
                }
            }
        }
        _fromCam.transform.position = Vector3.Lerp(_fromCam.position, _toCam.position, _horizontalMoveSpeed * Time.deltaTime);

        delayTime += Time.deltaTime;
        if (delayTime >= 0.5f)
        {
            _cam.transform.rotation = Quaternion.Slerp(_cam.transform.rotation, _toCam.rotation, _verticalMoveSpeed * Time.deltaTime);
            _cam.fieldOfView = 35;
        }
    }
}
