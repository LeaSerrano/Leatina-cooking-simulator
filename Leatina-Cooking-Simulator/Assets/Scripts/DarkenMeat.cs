using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenMeat : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        DarkenObjectColor();
    }

    void DarkenObjectColor()
    {
        if (rend != null)
        {
            Color currentColor = rend.material.color;

            float darkenFactor = 0.9f;
            Color darkenedColor = new Color(currentColor.r * darkenFactor, currentColor.g * darkenFactor, currentColor.b * darkenFactor, currentColor.a);

            rend.material.color = darkenedColor;
        }
        else
        {
            Debug.LogError("Renderer non trouvé sur cet objet.");
        }
    }
}
