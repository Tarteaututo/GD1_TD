using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private WaveDatabase _waveDatabase = null;

    [SerializeField]
    private Spawner _spawner = null;

    // On prends la prochaine wave disponible
    // On demande au spawner de créer les éléments de la wave (dans le temps)
    // Quand la wave est terminé, on demande la prochaine wave

    private Wave _currentWave = null;
  
    private void Update()
    {
        if (_currentWave == null && _waveDatabase.IsAllWavesEnded() == false)
        {
            // une seule frame quand le current wave n'existe pas
            _currentWave = _waveDatabase.GetNextWave();
            _currentWave.StartTimer();
        }

        if (_currentWave != null && _currentWave.UpdateTimer() == true)
        {
            // Quand la current wave est terminée, on la set à null
            if (_currentWave.IsWaveEnded() == true)
            {
                _currentWave = null;
            }
            // Sinon on demande le prochaine actor, on l'instancie, et on redémarre le timer
            else
            {
                Actor actor = _currentWave.GetNextActor();
                _spawner.SpawnActor(actor);
                _currentWave.StartTimer();
            }
        }
    }
}
