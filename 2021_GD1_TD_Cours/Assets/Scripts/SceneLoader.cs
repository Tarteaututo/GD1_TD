using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneName = null;

    [SerializeField]
    private LoadSceneMode _loadSceneMode = LoadSceneMode.Single;

    private void OnEnable()
    {
        SceneManager.LoadSceneAsync(_sceneName, _loadSceneMode);
    }
}
