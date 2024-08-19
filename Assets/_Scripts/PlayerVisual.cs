using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Transform playerVisualTransform;
    [SerializeField] private float scaleDuration;

    private void Awake()
    {
        
    }


    private void Start()
    {
        Player.Instance.OnScaleChanged += Instance_OnScaleChanged;
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        playerVisualTransform.DOScale(e.scale, scaleDuration).SetEase(Ease.InOutBounce);
    }

}
