using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    [SerializeField]
    private Transform[] _destination = null;
    //[SerializeField] private Transform _destination = null;

    [SerializeField]
    private float _speed = 1.5f;

    [SerializeField]
    private float _destinationThreshold = 0.1f;

    //[System.NonSerialized] // inverse of SerializeField
    private int _currentDestinationIndex = 0;

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
        }
        else
        {
            // Do Move
            Move();
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
}
