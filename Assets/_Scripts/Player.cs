using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float xScale = 1f;
    [SerializeField] private float yScale = 1f;
    [SerializeField] private float zScale = 1f;

    [SerializeField] private GameObject playerVisual;

    public void UpdateScale(Vector3 scale)
    {
        playerVisual.transform.localScale = scale;

        xScale = scale.x;
        yScale = scale.y;
        zScale = scale.z;
    }

    private void Update()
    {
        
    }


}
