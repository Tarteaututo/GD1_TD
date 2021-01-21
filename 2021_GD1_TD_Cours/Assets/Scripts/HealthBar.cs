using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform _foreground = null;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float perc = currentHealth / maxHealth;

        // Je récupère la scale précédente
        Vector3 scale = _foreground.localScale;
        // Je modifie ce qui m'intéresse dans la scale précédente
        //HACK
        scale.x = Mathf.Clamp01(perc);

        // je donne à foreground.localscale la nouvelle scale modifiée
        _foreground.localScale = scale;


    }
}
