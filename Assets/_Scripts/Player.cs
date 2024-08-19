using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

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
    

    [SerializeField] private Vector3 _playerScale;
    public Vector3 PlayerScale
    {
        get
        {
            return _playerScale;
        }
        set
        {
            _playerScale = value;

            OnPlayerScaleChanged?.Invoke(this, new OnPlayerScaleChangedEventArgs
            {
                playerScale = value
            });

        }
    }

    public event EventHandler<OnPlayerScaleChangedEventArgs> OnPlayerScaleChanged;
    public class OnPlayerScaleChangedEventArgs : EventArgs
    {
        public Vector3 playerScale;
    }

    private void Start()
    {
        PlayerScale = Vector3.one;
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = UnityEngine.Random.Range(1, 10);
            int y = UnityEngine.Random.Range(1, 10);
            int z = UnityEngine.Random.Range(1, 10);

            PlayerScale += new Vector3(x,y,z);
        }
    }


}
