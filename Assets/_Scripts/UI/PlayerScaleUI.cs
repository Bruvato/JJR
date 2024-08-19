using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScaleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xScaleText;
    [SerializeField] private TextMeshProUGUI yScaleText;
    [SerializeField] private TextMeshProUGUI zScaleText;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Player.Instance.OnScaleChanged += Instance_OnScaleChanged;

        UpdateScaleText(Vector3.zero);
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        UpdateScaleText(e.scale);
    }

    public void UpdateScaleText(Vector3 scale)
    {
        xScaleText.text = "X: " + scale.x;
        yScaleText.text = "Y: " + scale.y;
        zScaleText.text = "Z: " + scale.z;

    }
}
