using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private Collider playerCollider;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.Instance.Play("PShoot");

            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, Player.Instance.transform.position, firePoint.rotation);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), playerCollider);
    }
}
