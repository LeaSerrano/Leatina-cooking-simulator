using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakBehaviour : MonoBehaviour
{
    private bool estCuit = false;

    private CookMeat cookMeatScript;

    private void Start()
    {
        cookMeatScript = GetComponent<CookMeat>();
    }

    public void CuireSteak()
    {
        if (cookMeatScript != null)
        {
            StartCoroutine(cookMeatScript.CookAndDarkenMeat(gameObject));
        }

        estCuit = true;
    }

    public bool EstCuit()
    {
        return estCuit;
    }
}
