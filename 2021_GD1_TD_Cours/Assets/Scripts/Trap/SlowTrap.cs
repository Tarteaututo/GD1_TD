using UnityEngine;
using System.Collections;

public class SlowTrap : ATrap
{
    [SerializeField]
    private float _slowDuration = 3f;

    protected override void OnActorTrapped(Actor actor)
    {
        actor.ChangeEffectState(Actor.EffectState.Slow, _slowDuration);
    }
}
