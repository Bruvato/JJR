using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance {get;private set ;}
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (Instance != null)
        {
            Debug.LogError("more than one instance bruh");
        }

        Instance = this;
    }
    
    private void SearchSpawnVector(){
        Vector3 origin = Player.Instance.transform.position;
        Vector3 playerScale = Player.Instance.PlayerScale;
        origin += new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
