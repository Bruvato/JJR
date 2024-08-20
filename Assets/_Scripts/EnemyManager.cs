using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
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
    [SerializeField] private int spawnRadiusModifier;
    private List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> getEnemies(){
        return enemies;
    }

    void Update()
    {

    }

    public void Spawn()
    {
        Vector3 enemyScale = new Vector3(UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10));
        
        Enemy newEnemy = Instantiate(enemyPrefab, SearchSpawnVector(), Quaternion.identity).GetComponent<Enemy>();

        newEnemy.SetScale(enemyScale);
        enemies.Add(newEnemy);
    }
    private Vector3 SearchSpawnVector()
    {
        Vector3 playerScale = Player.Instance.GetScale();
        int range = (int)(Mathf.Max(Mathf.Max(playerScale.x, playerScale.y), playerScale.z) / 2 + spawnRadiusModifier);
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
