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

            if (GlobalVariables.validRecipe) 
            {
                invalidRecipeMessage.SetActive(false);
                GlobalVariables.shouldDespawnIngredients = true;
                GlobalVariables.shouldChangeRecipe = true;
                GlobalVariables.validRecipe = false;
                StartCoroutine(AfficherMessage(validRecipeMessage));
            }
            else 
            {
                validRecipeMessage.SetActive(false);
                StartCoroutine(AfficherMessage(invalidRecipeMessage));
            }
        }
    }

     IEnumerator AfficherMessage(GameObject message)
    {
        message.SetActive(true);
        yield return new WaitForSeconds(5f);
        message.SetActive(false);
    }
}
