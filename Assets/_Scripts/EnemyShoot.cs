using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Quaternion aimDir;
    // Start is called before the first frame update
    private void Awake()
    {
        Aim();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Aim(){
        aimDir= Quaternion.LookRotation(Player.Instance.transform.position - transform.position).normalized;

    }
    public void Shoot(){
        Instantiate(bulletPrefab, transform.position, aimDir).transform.rotation = aimDir;
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform.rotation.SetLookRotation(toPlayer);

    }
}
