using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private float minCamDist = 3f;
    [SerializeField] private float maxCamDist = 100f;



    private void Awake()
    {

    }
    private void Start()
    {
        Player.Instance.OnPlayerScaleChanged += Instance_OnPlayerScaleChanged;
    }

    private void Instance_OnPlayerScaleChanged(object sender, Player.OnPlayerScaleChangedEventArgs e)
    {
        
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

        camDist = Mathf.Clamp(camDist, minCamDist, maxCamDist);

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = camDist;
    }

}
