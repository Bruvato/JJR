using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
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
        Instantiate(enemyPrefab, SearchSpawnVector(), new Quaternion(0,0,0,0));

    }
    private Vector3 SearchSpawnVector()
    {
        int range = (int)(Mathf.Max(Mathf.Max(Player.Instance.PlayerScale.x, Player.Instance.PlayerScale.y), Player.Instance.PlayerScale.z) / 2 +5);
        Vector3 location = Player.Instance.transform.position + UnityEngine.Random.insideUnitSphere.normalized * range;
        location.x = Mathf.RoundToInt(location.x);
        location.y = Mathf.RoundToInt(location.y);
        location.z = Mathf.RoundToInt(location.z);

        return location;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
