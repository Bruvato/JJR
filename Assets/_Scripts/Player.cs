using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IScalable
{
    public static Player Instance {  get; private set; }

    public event EventHandler<IScalable.OnScaleChangedEventArgs> OnScaleChanged;

    private Vector3 _playerScale;
    public Vector3 GetScale()
    {
        return _playerScale;
    }
    public void SetScale(Vector3 scale)
    {
        _playerScale = scale;

        OnScaleChanged?.Invoke(this, new IScalable.OnScaleChangedEventArgs
        {
            scale = scale,
        });
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetScale(Vector3.one);
    }



    private void Update()
    {
        
    }

    
}
