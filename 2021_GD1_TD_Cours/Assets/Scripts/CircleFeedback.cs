using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFeedback : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField]
    private float _radius = 1f;

    [SerializeField]
    private Transform _scaler = null;

    public void SetRadius(float radius)
    {
        _radius = radius;
        _scaler.transform.localScale = Vector3.one * _radius;
    }

    private void OnValidate()
    {
        SetRadius(_radius);
    }
}
