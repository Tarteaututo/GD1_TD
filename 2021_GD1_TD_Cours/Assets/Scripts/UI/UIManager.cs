using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance = null;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Vérifier s'il existe un UIManager
                UIManager[] instances = FindObjectsOfType<UIManager>();
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
    private TextMeshProUGUI _towerCountText = null;

    private int _currentTowerCount = 0;

    public void AddTowerCount()
    {
        _currentTowerCount += 1; //_currentTowerCount++;
        _towerCountText.text = _currentTowerCount.ToString();
    }
}
