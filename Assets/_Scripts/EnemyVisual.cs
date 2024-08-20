using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform enemyVisualTransform;
    [SerializeField] private float scaleDuration;

    private void Awake()
    {
        enemy.OnScaleChanged += Enemy_OnScaleChanged;
    }
    private void Start()
    {
        
    }

    private void Enemy_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        if (enemyVisualTransform == null)
        {
            return;
        }

        Debug.Log("do scale");

        enemyVisualTransform.DOScale(e.scale, scaleDuration).SetEase(Ease.InOutBounce).SetAutoKill(true);
        enemyVisualTransform.transform.DOKill();

    }

    private void OnDestroy()
    {
        enemy.OnScaleChanged -= Enemy_OnScaleChanged;
    }

}
