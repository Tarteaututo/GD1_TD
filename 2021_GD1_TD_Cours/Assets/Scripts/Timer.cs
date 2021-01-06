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
/// Bonus
/// // Pause()
/// </summary>
public class Timer
{
    private float _duration = -1;

    // Constructor
    public Timer(float duration)
    {
        _duration = duration;
    }

    // == more or less useless in unity context
    // Destructor
    ~Timer()
    {
    }
}

// NE NOTEZ PAS ÇA
public class Sometest
{
    Timer _timer = null;

    private void SomeMethod()
    {
        _timer = new Timer(3);

        _timer.ToString();
    }
}
