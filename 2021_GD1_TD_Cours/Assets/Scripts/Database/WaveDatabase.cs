using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDatabase", menuName = "GameSup/WaveDatabase")]
public class WaveDatabase : ScriptableObject
{
    [SerializeField]
    private List<Wave> _wave = null;

    [SerializeField]
    private Timer _waveDelay = null;


}
