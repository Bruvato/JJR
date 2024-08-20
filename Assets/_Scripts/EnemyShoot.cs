using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Quaternion aimDir;
    [SerializeField] private int Cooldown;

    [SerializeField] private Collider enemyCollider;

    // Update is called once per frame
    void Update()
    {

    }
    public void Aim()
    {
        aimDir = Quaternion.LookRotation(Player.Instance.transform.position - transform.position).normalized;

    }
    public void Shoot()
    {
        Vector3 toPlayer = Vector3.Normalize(Player.Instance.transform.position - transform.position);
        aimDir = Quaternion.LookRotation(Player.Instance.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, aimDir);
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform.rotation.SetLookRotation(toPlayer);

        bullet.transform.rotation = Quaternion.LookRotation((Player.Instance.transform.position - transform.position).normalized);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), enemyCollider);

    }
}
