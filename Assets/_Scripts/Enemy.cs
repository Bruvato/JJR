using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyVisual enemyVisual;
    [SerializeField] EnemyVisual enemyMove;

    private Vector3 size;
    // Start is called before the first frame update
    private void Awake()
    {
        

    }
    public void setSize(Vector3 vector)
    {
        size = vector;
        enemyVisual.enemyVisualResize(size);
        return;
    }
    
    

    // Update is called once per frame

}
