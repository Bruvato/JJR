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

        //SetVisualScale(Vector3.one);
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        SetVisualScale(e.scale);
    }

    private void SetVisualScale(Vector3 scale)
    {
        playerVisualTransform.DOScale(scale, scaleDuration).SetEase(Ease.InOutBounce).SetAutoKill();

        if (scale.x * scale.y * scale.z <= 0)
        {
            playerVisualTransform.transform.DOKill();
        }
    }

    private void OnDestroy()
    {
        Player.Instance.OnScaleChanged -= Instance_OnScaleChanged;
    }

}
