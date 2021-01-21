using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReferences : MonoBehaviour
{
    #region Singleton
    private static LevelReferences _instance = null;

    public static bool HasInstance
    {
        get
        {
            return _instance != null;
        }
    }

    public static LevelReferences Instance
    {
        get
        {
            if (_instance == null)
            {
                // Vérifier s'il existe un UIManager
                LevelReferences[] instances = FindObjectsOfType<LevelReferences>();
                if (instances == null || instances.Length == 0)
                {
                    // debug message d'erreur
                    Debug.LogError("UIManager error : there is no singleton found in opened scenes.");
                    return null;
                }
                if (instances.Length > 1)
                {
                    // debug message d'erreur
                    Debug.LogError("UIManager error : there is more than one singleton in opened scenes.");
                    return null;
                }
                _instance = instances[0];
            }
            return _instance;
        }
    }
    #endregion Singleton

    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private EndGameMenu _endGameMenu = null;

    [SerializeField]
    private GameManager _gameManager = null;

    [SerializeField]
    private EconomyManager _economyManager = null;

    public EndGameMenu EndGameMenu => _endGameMenu;
    public GameManager GameManager => _gameManager;
    public Camera Camera => _camera;
    public EconomyManager EconomyManager => _economyManager;

    //public Camera Camera
    //{
    //    get
    //    {
    //        return _camera;
    //    }
    //}

}
