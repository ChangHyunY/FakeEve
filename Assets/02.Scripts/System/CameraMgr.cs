using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr instance = null;

    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 100.0f;

    [SerializeField]
    private Transform target;
    
    private Camera mainCamera;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void ChangeCamera()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

        // 최대 줌인
        if (mainCamera.fieldOfView <= 20.0f && distance < 0)
        {
            mainCamera.fieldOfView = 20.0f;
        }

        // 최대 줌 아웃
        else if (mainCamera.fieldOfView >= 120.0f && distance > 0)
        {
            mainCamera.fieldOfView = 120.0f;
        }

        // 줌 인,아웃 하기.
        else
        {
            mainCamera.fieldOfView += distance;
        }
    }

    public void Rotate()
    {
        mainCamera.transform.RotateAround(target.position, mainCamera.transform.up, -Input.GetAxis("Mouse X") * rotateSpeed);

        mainCamera.transform.RotateAround(target.position, mainCamera.transform.right, -Input.GetAxis("Mouse Y") * rotateSpeed);
    }

    public void LockTarget(Transform _target)
    {
        transform.LookAt(_target);
    }
}
