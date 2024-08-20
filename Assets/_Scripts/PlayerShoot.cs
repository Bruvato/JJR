using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform camTransform;

    [SerializeField] private Collider playerCollider;
    [SerializeField] private LayerMask playerLayerMask;

    private LineRenderer lineRenderer;
    private float maxAimRange;


    private bool aimed;
    private Vector2 aimPos;
    private Vector3 aimDir;

    public static event EventHandler OnPlayerShoot;



    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }
    private void Start()
    {
        Player.Instance.OnScaleChanged += Instance_OnScaleChanged;
        TurnManager.Instance.OnTurnCountChanged += Instance_OnTurnCountChanged;
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        maxAimRange = Player.Instance.GetMaxScaleComponent() + 20;

    }

    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {
        if (TurnManager.Instance.GetState() != GameState.Cycle)
        {
            return;
        }

        if (!aimed)
        {
            return;
        }

        Shoot();
    }

    void Update()
    {
        if (TurnManager.Instance.GetState() != GameState.PlayerTurn)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 playerPos = Player.Instance.transform.position;

            aimed = true;
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, playerPos);

            RaycastHit hit;
            Vector3 endPoint;


            if (Physics.Raycast(playerPos, camTransform.forward, out hit, maxAimRange, playerLayerMask))
            {
                endPoint = hit.point;
            }
            else
            {
                endPoint = playerPos + camTransform.forward * maxAimRange;
            }

            aimPos = playerPos;
            aimDir = camTransform.forward;

            lineRenderer.SetPosition(1, endPoint);
        }

    }

    void Shoot()
    {
        aimed = false;
        lineRenderer.enabled = false;

        GameObject bullet = Instantiate(projectilePrefab, aimPos, Quaternion.LookRotation(aimDir));

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), playerCollider);

        OnPlayerShoot?.Invoke(this, EventArgs.Empty);

        SoundManager.Instance.Play("PShoot");

    }
}
