using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{

    [SerializeField] private Transform enemyVisualTransform;
    
    [SerializeField] private float scaleDuration;


    public void enemyVisualResize(Vector3 vector)
    
    {
    enemyVisualTransform.DOScale(vector, scaleDuration).SetEase(Ease.InOutBounce);

    }
    
}
