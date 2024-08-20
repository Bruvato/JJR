using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnRadiusModifier, maxEnemies;
    private List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> GetEnemies(){
        return enemies;
    }
    public void EnemyPreMove(){
        foreach (Enemy e in enemies)
        {
            e.GetComponent<EnemyMove>().PreMove();
        }
    }
    public void EnemyMove(){
        foreach (Enemy e in enemies)
        {
            e.GetComponent<EnemyMove>().Move();
        }
    }
    public void EnemyShoot(){
        foreach (Enemy e in enemies)
        {
            e.GetComponent<EnemyShoot>().Shoot();
        }
    }
    public void EnemyAim(){
        foreach (Enemy e in enemies)
        {
            e.GetComponent<EnemyShoot>().Aim();
        }
    }
    void Update()
    {

    }

    public void Spawn()
    {
        if(enemies.Count<maxEnemies){
        Vector3 enemyScale = new Vector3(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10));
        
        Enemy newEnemy = Instantiate(enemyPrefab, SearchSpawnVector(), Quaternion.identity).GetComponent<Enemy>();

        newEnemy.SetScale(enemyScale);
        enemies.Add(newEnemy);
        }
    }
    private Vector3 SearchSpawnVector()
    {
        int range = (int)(Player.Instance.GetMaxScaleComponent() / 2 + spawnRadiusModifier);
        Vector3 location = Player.Instance.transform.position + UnityEngine.Random.insideUnitSphere.normalized * range;


        return FTI(location);
    }


    //rounds vector3 to int
    private Vector3 FTI(Vector3 vector)
    {
        vector.x = Mathf.RoundToInt(vector.x);
        vector.y = Mathf.RoundToInt(vector.y);
        vector.z = Mathf.RoundToInt(vector.z);

        return vector;
    }

    
}
