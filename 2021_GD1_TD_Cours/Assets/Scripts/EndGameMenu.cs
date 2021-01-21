using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField]
    private RectTransform _victoryMenu = null;

    [SerializeField]
    private RectTransform _defeatMenu = null;

    [SerializeField]
    private string _retryGameSceneName = "Game";

    private void Awake()
    {
        gameObject.SetActive(false);
        _victoryMenu.gameObject.SetActive(false);
        _defeatMenu.gameObject.SetActive(false);
    }

    public void ShowMenu(bool isVictory)
    {
        gameObject.SetActive(true);
        if (isVictory == true)
        {
            _victoryMenu.gameObject.SetActive(true);
        }
        else
        {
            _defeatMenu.gameObject.SetActive(true);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadSceneAsync(_retryGameSceneName);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
