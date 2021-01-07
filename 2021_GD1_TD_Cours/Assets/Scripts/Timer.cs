using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Faire une class Timer qui prends une durée, 
///  peut être update dans le temps (== on compte les secondes) 
///  et qui indique quand la durée a été atteinte
///  
/// // Start()
/// // Stop()
/// 
/// // Update()
/// 
/// Bonus
/// // Pause()
/// </summary>
public class Timer
{
    private float _duration = -1;
    private float _currentDuration = 0f;

    private bool _isRunning = false;

    // Constructor
    public Timer(float duration)
    {
        _duration = duration;
    }

    //// == more or less useless in unity context
    //// Destructor
    //~Timer()
    //{
    //}

    public void Start()
    {
        _currentDuration = _duration;
        _isRunning = true;
    }

    public void Start(float duration)
    {
        _duration = duration;
        _currentDuration = _duration;
        _isRunning = true;
    }

    public void Stop()
    {
        _currentDuration = 0;
        _isRunning = false;
    }

    public bool Update()
    {
        if (_isRunning == false)
        {
            return false;
        }

        _currentDuration -= Time.deltaTime;

        if (_currentDuration <= 0)
        {
            Stop();
            return true;
        }
        return false;
    }
}
