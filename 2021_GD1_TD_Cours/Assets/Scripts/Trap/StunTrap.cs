using UnityEngine;
using System.Collections;

public class StunTrap : ATrap
{
    [SerializeField]
    private float _stunDuration = 3f;

    protected override void OnActorTrapped(Actor actor)
    {
        actor.ChangeEffectState(Actor.EffectState.Stun, _stunDuration);
    }
}