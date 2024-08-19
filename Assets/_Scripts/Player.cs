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
        if (Input.GetMouseButtonDown(0))
        {
            int x = UnityEngine.Random.Range(1, 50);
            int y = UnityEngine.Random.Range(1, 50);
            int z = UnityEngine.Random.Range(1, 50);

            int o = UnityEngine.Random.Range(1, 4);
            Vector3 newScale = FunctionApplier.ApplyFunctionOnVecComponents(FunctionApplier.Function.Add, GetScale(), 1, o==1, o==2, o==3);
            
            SetScale(newScale);
        }
    }

    
}
