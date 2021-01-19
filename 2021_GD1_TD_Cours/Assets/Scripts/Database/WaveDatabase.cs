using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// + un wave manager qui prends une wave database + un spawner

[CreateAssetMenu(fileName = "WaveDatabase", menuName = "GameSup/WaveDatabase")]
public class WaveDatabase : ScriptableObject
{
    [SerializeField]
    private List<Wave> _wave = null;

    [SerializeField]
    private Timer _waveDelay = null;

    [System.NonSerialized]
    private int _currentWaveIndex = 0;

    // Current wave index
    // get next wave

    public bool IsAllWavesEnded()
    {
        return _currentWaveIndex >= _wave.Count;
    }

    public Wave GetNextWave()
    {
        if (_currentWaveIndex >= _wave.Count)
        {
            return null;
        }
        Wave selectedWave = _wave[_currentWaveIndex];
        _currentWaveIndex += 1;
        return selectedWave;
    }
}
