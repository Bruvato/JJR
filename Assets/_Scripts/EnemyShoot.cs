using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Quaternion aimDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(){
        Vector3 toPlayer = Vector3.Normalize(Player.Instance.transform.position - transform.position);
        aimDir= Quaternion.LookRotation(Player.Instance.transform.position - transform.position).normalized;
        Instantiate(bulletPrefab, transform.position, aimDir).transform.rotation = Quaternion.LookRotation((Player.Instance.transform.position - transform.position).normalized);
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform.rotation.SetLookRotation(toPlayer);

    }
}
