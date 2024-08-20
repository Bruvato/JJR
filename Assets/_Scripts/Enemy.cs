using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IScalable
{
    public event EventHandler<IScalable.OnScaleChangedEventArgs> OnScaleChanged;
    
    private Vector3 _enemyScale;
    public Vector3 GetScale()
    {
        return _enemyScale;
    }

    public void SetScale(Vector3 scale)
    {
        _enemyScale = scale;

        OnScaleChanged?.Invoke(this, new IScalable.OnScaleChangedEventArgs
        {
            scale = scale,
        });

        if (scale.x * scale.y * scale.z <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        EnemyManager.Instance.GetEnemies().Remove(this);

        SoundManager.Instance.Play("Kill");

    }




}
