using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnRadiusModifier;
    public static EnemyManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError("more than one instance bruh");
        }
        Instance = this;
    }

    public void Spawn()
    {
        Vector3 size = new Vector3(UnityEngine.Random.Range(1,10), UnityEngine.Random.Range(1,10), UnityEngine.Random.Range(1,10));
        GameObject newEnemy = Instantiate(enemyPrefab, SearchSpawnVector(), new Quaternion(0,0,0,0));
        
        newEnemy.GetComponent<Enemy>().setSize(size);
    }
    private Vector3 SearchSpawnVector()
    {
        int range = (int)(Mathf.Max(Mathf.Max(Player.Instance.PlayerScale.x, Player.Instance.PlayerScale.y), Player.Instance.PlayerScale.z) / 2 + spawnRadiusModifier);
        Vector3 location = Player.Instance.transform.position + UnityEngine.Random.insideUnitSphere.normalized * range;
        

        return FTI(location);
    }


    //rounds vector3 to int
    private Vector3 FTI(Vector3 vector){
        vector.x = Mathf.RoundToInt(vector.x);
        vector.y = Mathf.RoundToInt(vector.y);
        vector.z = Mathf.RoundToInt(vector.z);

        return vector;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
