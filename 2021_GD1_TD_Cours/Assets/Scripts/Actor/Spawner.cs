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
    private Transform[] _destinations = null;

    public void SpawnActor(Actor actor)
    {
        // On retient le dernier index de la liste de spawn
        // On l'incrémente et spawn le transform correspondant à l'index
        // Si on dépasse la taille de la liste -> index à 0

        Actor instance = Instantiate(actor);
        instance.transform.position = transform.position;
        instance.SetDestination(_destinations);
    }
}
