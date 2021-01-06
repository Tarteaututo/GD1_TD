using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    // byte == octet == 8 bits
    // bit : 0 ou 1
    // 1 << 0 1000 0100
    public enum State
    {
        Idle = 0,
        Patrol = 1,
    }

    [SerializeField]
    private Transform[] _destination = null;
    //[SerializeField] private Transform _destination = null;

    [SerializeField]
    private float _speed = 1.5f;

    [SerializeField]
    private float _destinationThreshold = 0.1f;

    //[System.NonSerialized] // inverse of SerializeField
    private int _currentDestinationIndex = 0;

    // Temporary
    [SerializeField]
    private State _state = State.Idle;

    // Balancing value
    [SerializeField]
    private float _idleDuration = 1f;

    // Valeur de "fonctionnement du système", cachée pour le designer
    private float _currentIdleDuration = 1f;

    //#region tuto collection
    //[SerializeField]
    //private int[] _myIntArray = null;

    //[SerializeField]
    //private List<int> _myIntList = null;
    //#endregion tuto collection



    //private void UselessMethod()
    //{
    //    // ces trois formulations sont strictement égales
    //    // i++ // existe en i--
    //    // i += 1; // existe en -=
    //    // i = i + 1; // existe en i = i - 1;
    //    //

    //    // j'accède au premier élément de mon tableau
    //    //_myIntArray[0];

    //    //_myIntArray.Length;
    //    //_myIntList.Count;
    //    int sum = 0;
    //    for (int i = 0; i < _myIntArray.Length; i++)
    //    {
    //        // On ajoute chaque élément d'un tableau dans une variable
    //        sum += _myIntArray[i];
    //    }
    //    // Sum == element 0 + element 1 + element 2 + ... + element n
    //}

    void Update()
    {
        switch (_state)
        {
            case State.Idle:
                {
                    _currentIdleDuration += Time.deltaTime;

                    if (_currentIdleDuration >= _idleDuration)
                    {
                        _currentIdleDuration = 0;
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
            default:
                break;
        }
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
    }
}
