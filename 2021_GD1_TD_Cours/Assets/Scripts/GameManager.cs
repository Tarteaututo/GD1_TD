using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void DoEndGame(bool isVictory)
    {
        var levelReferences = LevelReferences.Instance;
        levelReferences.EndGameMenu.ShowMenu(isVictory);
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
