using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// _timer pour savoir le delay d'instantiation
// reference vers l'objet spawn
// quantité
// position de spawn + destinations à atteindre
// ordre de spawn
// Un genre de base de donnée pour savoir qui spawn quoi comment quand
// FIFO (first in first out) / FILO First in last out 

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Actor> _spawnList = null;

    [SerializeField]
    private float _spawnDelay = 1f;

    [SerializeField]
    private Transform[] _destinations = null;

    private Timer _timer = null;
    private int _currentSpawnIndex = 0;

    private void Awake()
    {
        _timer = new Timer(_spawnDelay);
        _timer.Start();
    }

    private void Update()
    {
        if (_timer.Update() == true)
        {
            _timer.Start();
            SpawnActor();
        }
    }

    private void SpawnActor()
    {
        // On retient le dernier index de la liste de spawn
        // On l'incrémente et spawn le transform correspondant à l'index
        // Si on dépasse la taille de la liste -> index à 0

        Actor instance = Instantiate(_spawnList[_currentSpawnIndex]);
        instance.transform.position = transform.position;

        instance.SetDestination(_destinations);

        _currentSpawnIndex += 1;
        if (_currentSpawnIndex > _spawnList.Count - 1)
        {
            _currentSpawnIndex = 0;
        }
    }
}
