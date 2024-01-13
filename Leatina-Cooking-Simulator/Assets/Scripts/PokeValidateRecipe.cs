using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PokeValidateRecipe : MonoBehaviour
{
private bool boutonPresse = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(BoutonPresse);
    }

    private void BoutonPresse()
    {
        boutonPresse = !boutonPresse;
        if (boutonPresse)
        {
            Debug.Log("Bouton enfoncé. Affichage dans le terminal.");
        }
    }
}
