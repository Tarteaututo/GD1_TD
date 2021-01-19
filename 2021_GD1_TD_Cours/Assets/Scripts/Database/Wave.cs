using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "GameSup/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField]
    private List<Actor> _actors = null;

    [SerializeField]
    private float _spawnDelay = 1f;

    [System.NonSerialized]
    private int _currentSpawnIndex = 0;

    private Timer _timer = null;


    public bool IsWaveEnded()
    {
        return _currentSpawnIndex >= _actors.Count;
    }

    public Actor GetNextActor()
    {
        if (_currentSpawnIndex >= _actors.Count)
        {
            return null;
        }
        Actor selectedActor = _actors[_currentSpawnIndex];
        _currentSpawnIndex += 1;
        return selectedActor;
    }

    public void StartTimer()
    {
        if (_timer == null)
        {
            _timer = new Timer(_spawnDelay);
        }
        _timer.Start();
    }

    public bool UpdateTimer()
    {
        return _timer.Update();
    }


}
