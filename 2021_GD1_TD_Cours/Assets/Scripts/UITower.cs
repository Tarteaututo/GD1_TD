using UnityEngine;
using UnityEngine.UI;

public class UITower : MonoBehaviour
{
    [SerializeField]
    private Button _buttons = null;

    [SerializeField]
    private Button _hideButtons = null;

    private Tower _prefab = null;

    [System.NonSerialized]
    private Tower _towerInstance = null;

    [System.NonSerialized]
    private Vector3 _instanceOffset;

    public delegate void UITowerEvent(UITower sender, Tower towerInstance);
    public event UITowerEvent ButtonClicked = null;


    public void Initialize(Tower prefab, Vector3 instanceOffset)
    {
        _prefab = prefab;
        _instanceOffset = instanceOffset;

        _buttons.onClick.AddListener(CreateTower);
        _hideButtons.onClick.AddListener(HideMenu);
    }

    public void CleanUp()
    {
        _buttons.onClick.RemoveListener(CreateTower);
        _hideButtons.onClick.RemoveListener(HideMenu);
        _towerInstance = null;
    }

    private void CreateTower()
    {
        _towerInstance = GameObject.Instantiate(_prefab);
        _towerInstance.transform.position = _instanceOffset;
        ButtonClicked?.Invoke(this, _towerInstance);
    }

    private void HideMenu()
    {
        ButtonClicked?.Invoke(this, null);
    }
}
