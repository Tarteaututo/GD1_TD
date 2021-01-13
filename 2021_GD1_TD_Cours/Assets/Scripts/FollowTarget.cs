using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private float _speed = 1f;

    private void Update()
    {
        Vector3 destination = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        destination = Vector3.Lerp(transform.position, destination, Time.deltaTime * _speed);
        transform.position = destination;
    }
}
