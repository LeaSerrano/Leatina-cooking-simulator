using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PokeValidateRecipe : MonoBehaviour
{
    private bool boutonPresse = false;

    public GameObject validRecipeMessage;
    public GameObject invalidRecipeMessage;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonPress);
    }

    private void ButtonPress()
    {
        boutonPresse = !boutonPresse;
        if (boutonPresse)
        {
            Debug.Log("Bouton enfoncé. Affichage dans le terminal.");

            if (GlobalVariables.validRecipe) 
            {
                StartCoroutine(AfficherMessage(validRecipeMessage));
            }
            else 
            {
                StartCoroutine(AfficherMessage(invalidRecipeMessage));
            }
        }
    }

     IEnumerator AfficherMessage(GameObject message)
    {
        message.SetActive(true);
        yield return new WaitForSeconds(10f);
        message.SetActive(false);
    }
}
