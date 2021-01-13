using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UtilityTest : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mr;
    private void OnEnable()
    {
        var m = mr.sharedMaterial;
        m.SetColor("_Color", Color.white);
        mr.sharedMaterial = m;
    }
}
