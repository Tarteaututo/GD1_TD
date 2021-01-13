using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _ps = null;

    [SerializeField]
    private bool _destroyIfNotPlaying = true;

    private void Update()
    {
        if (_destroyIfNotPlaying == true && 
            _ps.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
