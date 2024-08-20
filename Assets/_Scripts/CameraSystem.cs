using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private float minCamDist = 3f;
    [SerializeField] private float maxCamDist = 5f;



    private void Awake()
    {
        LockCursor(true);

        SetCamDist(minCamDist);
    }
    private void Start()
    {
        Player.Instance.OnScaleChanged += Instance_OnScaleChanged; ;
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        Vector3 playerScale = e.scale;
        float maxScaleComponent = Mathf.Max(Mathf.Max(playerScale.x, playerScale.y), playerScale.z);
        minCamDist = 3 * maxScaleComponent;
        maxCamDist = 5 * maxScaleComponent;

        HandleCameraZoom();

    }

    private void Update()
    {
        HandleCameraZoom();
    }

    private void HandleCameraZoom()
    {
        float camDist = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;

        if (Input.mouseScrollDelta.y > 0)
        {
            camDist++;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            camDist--;
        }

        SetCamDist(camDist);

    }

    private void SetCamDist(float camDist)
    {
        camDist = Mathf.Clamp(camDist, minCamDist, maxCamDist);

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = camDist;

    }

    public static void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

}
