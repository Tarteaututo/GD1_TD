using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public enum State
    {
        Idle = 0,
        Patrol = 1,
        Firing = 2,
    }

    [SerializeField]
    private WeaponController _weaponController = null;

    [SerializeField]
    private Transform[] _destination = null;

    [SerializeField]
    private float _speed = 1.5f;

    [SerializeField]
    private float _destinationThreshold = 0.1f;

    //[System.NonSerialized] // inverse of SerializeField
    private int _currentDestinationIndex = 0;

    // Temporary
    [SerializeField]
    private State _state = State.Idle;

    [SerializeField]
    private float _idleDuration = 1f;

    [SerializeField]
    private float _preFiringDuration = 1f;

    private Timer _timer = null;

    private void Awake()
    {
        _timer = new Timer(_idleDuration);
    }

    void Update()
    {
        switch (_state)
        {
            case State.Idle:
                {
                    if (_timer.Update() == true)
                    {
                        ChangeState(State.Patrol);
                    }
                }
                break;
            case State.Patrol:
                {
                    if (DoPatrol() == false)
                    {
                        ChangeState(State.Idle);

                    }
                }
                break;
            case State.Firing:
                {
                    if (_timer.Update() == true)
                    {
                        DoFire();
                        ChangeState(State.Idle);
                    }
                }
                break;
            default:
                break;
        }
    }

    private void DoFire()
    {
        _weaponController.Fire();
    }

    private bool DoPatrol()
    {
        bool hasReachedThreshold = Vector3.Distance(transform.position, _destination[_currentDestinationIndex].position) < _destinationThreshold;

        // Est ce que ma position est plus proche que le seuil de destination
        if (hasReachedThreshold == true)
        {
            // Do select the next destination
            _currentDestinationIndex += 1;

            if (_currentDestinationIndex > _destination.Length - 1)
            {
                _currentDestinationIndex = 0;
            }
            return false;
        }
        else
        {
            // Do Move
            Move();
            return true;
        }
    }

    private void Move()
    {
        // On se déplace de 1m en direction du forward du monde
        //transform.position = transform.position + (new Vector3(0, 0, 1) * _speed * Time.deltaTime);

        // On se déplace de 1m en direction du forward de l'actor
        //transform.position = transform.position + (transform.forward * _speed * Time.deltaTime);

        Vector3 direction = _destination[_currentDestinationIndex].position - transform.position;
        direction = direction.normalized;
        // strictement égale à au dessus
        //Vector3 direction = (_destination.position - transform.position).normalized;

        transform.position = transform.position + (_speed * direction * Time.deltaTime);
    }

    private void ChangeState(State newState)
    {
        _state = newState;

        if (_state == State.Idle)
        {
            _timer.Start();
        }
        else if (_state == State.Firing)
        {
            _timer.Start(_preFiringDuration);
        }
        else if (_state == State.Patrol)
        {
            // Quick and dirty
            RotateToTarget(_destination[_currentDestinationIndex].position);
        }
    }
    
    private void RotateToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponentInParent<Damageable>();
        if (damageable != null)
        {
            ChangeState(State.Firing);
            RotateToTarget(damageable.transform.position);
        }
    }
}
