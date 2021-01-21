using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _camera = null;

    private void Awake()
    {
        _camera = LevelReferences.Instance.Camera;
    }

    public void LateUpdate()
    {
        if (_camera == null) return;
        Vector3 direction = _camera.transform.position - transform.position;
        direction *= -1;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
