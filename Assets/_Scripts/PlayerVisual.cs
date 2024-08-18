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
        Player.Instance.OnPlayerScaleChanged += Instance_OnPlayerScaleChanged;
    }

    private void Instance_OnPlayerScaleChanged(object sender, Player.OnPlayerScaleChangedEventArgs e)
    {
        playerVisualTransform.DOScale(e.playerScale, scaleDuration).SetEase(Ease.InOutBounce);
    }
}
