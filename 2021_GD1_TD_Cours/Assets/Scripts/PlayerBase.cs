using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private Damageable _damageable = null;

    private void OnTriggerEnter(Collider other)
    {
        Actor actor = other.GetComponentInParent<Actor>();
        if (actor != null)
        {
            // TODO AL : set an actor damage to base
            Destroy(actor.gameObject);
            int actorDamage = 1;
            _damageable.DoDamage(actorDamage);

            if (_damageable.IsAlive == false)
            {
                LevelReferences.Instance.GameManager.DoEndGame(false);
            }
        }
    }
}
