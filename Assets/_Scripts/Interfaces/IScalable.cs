using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScalable
{
    public Vector3 GetScale();
    public void SetScale(Vector3 scale);

    public event EventHandler<OnScaleChangedEventArgs> OnScaleChanged;
    public class OnScaleChangedEventArgs : EventArgs
    {
        public Vector3 scale;
    }
}
