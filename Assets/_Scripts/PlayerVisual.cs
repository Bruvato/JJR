using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Transform playerVisualTransform;

    private void Awake()
    {
        
    }


    private void Start()
    {
        Player.Instance.OnPlayerScaleChanged += Instance_OnPlayerScaleChanged;
    }

    private void Instance_OnPlayerScaleChanged(object sender, Player.OnPlayerScaleChangedEventArgs e)
    {
        playerVisualTransform.localScale = e.playerScale;
    }
}
