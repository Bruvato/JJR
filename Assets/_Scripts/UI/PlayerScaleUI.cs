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
        Player.Instance.OnPlayerScaleChanged += Instance_OnPlayerScaleChanged;
    }

    private void Instance_OnPlayerScaleChanged(object sender, Player.OnPlayerScaleChangedEventArgs e)
    {
        UpdateScaleText(e.playerScale);
    }

    public void UpdateScaleText(Vector3 scale)
    {
        xScaleText.text = "X: " + scale.x;
        yScaleText.text = "Y: " + scale.y;
        zScaleText.text = "Z: " + scale.z;

    }
}
