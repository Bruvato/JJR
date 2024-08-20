using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private Collider playerCollider;

    private LineRenderer lineRenderer;
    [SerializeField] private float maxAimRange = 50f;

    private bool lockedIn;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        // SoundManager.Instance.Play("PShoot");
        
        if (Input.GetButtonDown("Fire1"))
        {
            lockedIn = true;
        }

        RaycastHit hit;
        Vector3 endPoint;

        if (Physics.Raycast(firePoint.position + firePoint.forward * Player.Instance.GetMaxScaleComponent(), firePoint.forward, out hit, maxAimRange))
        {
            lineRenderer.enabled = true;
            endPoint = hit.point;
        }
        

        endPoint = firePoint.position + firePoint.forward * maxAimRange;


        lineRenderer.SetPosition(1, endPoint);

        
    }
    void Shoot()
    {
        lockedIn = false;

        GameObject bullet = Instantiate(projectilePrefab, Player.Instance.transform.position, firePoint.rotation);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), playerCollider);
    }
}
