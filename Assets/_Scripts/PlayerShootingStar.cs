using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingStar : MonoBehaviour {
    public GameObject projectilePrefab;
     public Transform firePoint;
     

    void Update() {
        if (Input.GetButtonDown("Fire1"))  {
            ShootTheHoop();
        }
    }
    void ShootTheHoop() {
        Instantiate(projectilePrefab, Player.Instance.transform.position, firePoint.rotation);
    }
}
