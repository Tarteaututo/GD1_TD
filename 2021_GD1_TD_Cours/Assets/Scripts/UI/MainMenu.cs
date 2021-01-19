using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Les class editor n'existent pas en build
// Donc tout ce qui a trait à l'éditor doit être entouré de #if UNITY_EDITOR [...] #endif
#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

public class MainMenu : MonoBehaviour
{
    // Deuxième méthode : add listener
    [SerializeField]
    private Button _quitButton = null;

    // Première méthode : binding dans l'editor avec le Button.OnClick
    public void StartGame()
    {
        // Lancer la scene de game
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    private void OnEnable()
    {
        _quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnDisable()
    {
        _quitButton.onClick.RemoveListener(OnQuitClicked);
    }

    private void OnQuitClicked()
    {
#if UNITY_EDITOR // si je suis en editor
        // play à false
        UnityEditor.EditorApplication.isPlaying = false;
#else // sinon je suis en build
        // quitter la build
        Application.Quit();
#endif
    }
}
