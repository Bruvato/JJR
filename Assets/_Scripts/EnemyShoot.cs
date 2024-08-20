using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Quaternion aimDir;
    [SerializeField] private int cooldown;
    private int count;

    [SerializeField] private Collider enemyCollider;

    // Update is called once per frame
    void Awake()
    {
        TurnManager.Instance.OnTurnCountChanged += Instance_OnTurnCountChanged;
    }
    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {
        count++;
    }
    
    void Update()
    {

    }
    public void Aim()
    {
        aimDir = Quaternion.LookRotation(Player.Instance.transform.position - transform.position).normalized;

    }
    public void Shoot()
    {
        if(count>=cooldown){
            count = 0;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, aimDir);
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform.rotation.SetLookRotation(toPlayer);

        bullet.transform.rotation = aimDir;

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), enemyCollider);
        }

    }
}
