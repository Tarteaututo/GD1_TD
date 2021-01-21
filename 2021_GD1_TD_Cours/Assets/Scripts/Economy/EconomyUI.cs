using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text = null;

    public void SetAmount(int amount)
    {
        _text.text = amount.ToString();
    }
}
