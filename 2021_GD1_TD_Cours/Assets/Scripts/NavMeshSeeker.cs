using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSeeker : MonoBehaviour
{
    public enum State
    {
        Idle,
        Seeking,
        Destroying
    }

    [SerializeField]
    private NavMeshAgent _agent = null;

    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private State _state = State.Idle;

    [SerializeField]
    private float _explosionAtTargetDistance = 3f;

    [SerializeField]
    private float _explosionDelay = 1f;

    [SerializeField]
    private float _explosionRadius = 5f;

    [SerializeField]
    private ParticleSystem _destroyParticle = null;

    [SerializeField]
    private LayerMask _playerLayerMask = 0;

    [SerializeField]
    private int _explosionDamage = 0;

    [SerializeField]
    private MeshRenderer _meshRenderer = null;

    [SerializeField]
    private Color _seekingColor = Color.yellow;

    [SerializeField]
    private Color _destroyingColor = Color.red;

    [System.NonSerialized]
    private Timer _timer = null;

    private void OnEnable()
    {

        // temp : will be done by a radius around the player
        Activate();
    }

    public void Activate()
    {
        ChangeState(State.Seeking);
        _timer = new Timer(_explosionDelay);
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                break;
            case State.Seeking:
                {
                    Vector3 targetPosition = _target.transform.position;
                    _agent.SetDestination(_target.transform.position);
                    if (Vector3.Distance(targetPosition, transform.position) < _explosionAtTargetDistance)
                    {
                        ChangeState(State.Destroying);
                    }
                }
                break;
            case State.Destroying:
                {
                    if (_timer.Update() == true)
                    {
                        DoDestroy();
                    }
                }
                break;
            default:
                break;
        }
    }

    private void ChangeState(State newState)
    {
        _state = newState;

        switch (newState)
        {
            case State.Seeking:
                {
                    SetColor(_seekingColor);
                }
                break;
            case State.Destroying:
                {
                    _timer.Start();
                    SetColor(_destroyingColor);
                }
                break;
            case State.Idle:
            default:
                break;
        }
    }

    private void DoDestroy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _playerLayerMask.value);
        for (int i = 0; i < colliders.Length; i++)
        {
            Damageable damageable = colliders[i].GetComponentInParent<Damageable>();
            if (damageable != null)
            {
                damageable.DoDamage(_explosionDamage);
                break;
            }
        }

        var instance = Instantiate<ParticleSystem>(_destroyParticle);
        instance.transform.position = transform.position;

        Destroy(this.gameObject);
    }


    // Quick and dirty
    private void SetColor(Color color)
    {
        Material material = _meshRenderer.material;
        material.SetColor("_Color", color);
        _meshRenderer.material = material;
    }

}
