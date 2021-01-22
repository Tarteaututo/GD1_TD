using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATrap : MonoBehaviour
{
    [SerializeField]
    private int _price = 1;

    [SerializeField]
    private float _lifeTime = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Actor actor = other.GetComponentInParent<Actor>();
        if (actor != null)
        {
            OnActorTrapped(actor);
        }
    }

    protected abstract void OnActorTrapped(Actor actor);
}
