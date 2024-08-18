using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("more than one player instance bruh");
        }

        Instance = this;
    }

    [SerializeField] private Vector3 playerScale;

    public event EventHandler<OnPlayerScaleChangedEventArgs> OnPlayerScaleChanged;
    public class OnPlayerScaleChangedEventArgs : EventArgs
    {
        public Vector3 playerScale;
    }



    public void UpdateScale(Vector3 scale)
    {
        playerScale = scale;

        OnPlayerScaleChanged?.Invoke(this, new OnPlayerScaleChangedEventArgs
        {
            playerScale = scale
        });
    }   
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = UnityEngine.Random.Range(1, 10);
            int y = UnityEngine.Random.Range(1, 10);
            int z = UnityEngine.Random.Range(1, 10);
            UpdateScale(new Vector3(x, y, z));
        }
    }


}
