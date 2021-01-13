using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    [SerializeField]
    private Grid _grid = null;

    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private KeyCode _showPreviewKey = KeyCode.P;

    // reference vers un objet de preview
    [SerializeField]
    private GameObject _preview = null;

    [SerializeField]
    private LayerMask _layerMask = 0;

    private void Update()
    {
        if (Input.GetKeyDown(_showPreviewKey) == true)
        {
            TogglePreviewVisibility();
        }

        if (_preview.gameObject.activeSelf == true)
        {
            SnapPreview();
        }
    }

    private void TogglePreviewVisibility()
    {
        //bool isActive = true;
        //isActive = isActive == false;
        //isActive = true == false; // false
        //isActive = false == false; // true
        //isActive = !isActive;
        // On inverse l'état d'activation (vrai devient faux, faux devient vrai)
        _preview.SetActive(_preview.activeSelf == false);
    }

    private void SnapPreview()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, _layerMask.value) == true)
        {
            //_preview.transform.position = hit.point;
            _preview.transform.position = _grid.Snap(hit.point);
        }
    }
}