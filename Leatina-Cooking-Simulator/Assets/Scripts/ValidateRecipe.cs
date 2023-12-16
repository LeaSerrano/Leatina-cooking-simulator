using UnityEngine;

public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequis = 2;
    private bool recetteValide = false;

    private GameObject bread1;
    private GameObject tomato;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bread") && bread1 == null)
        {
            bread1 = other.gameObject;
            ingredientsPresent++;

            Debug.Log("bread enter");
        }
        else if (other.CompareTag("Tomato") && tomato == null)
        {
            tomato = other.gameObject;
            ingredientsPresent++;

            Debug.Log("tomato enter");
        }

        Debug.Log("ingrédients présents : " + ingredientsPresent);

        if (ingredientsPresent == ingredientsRequis && EstRecetteComplete())
        {
            recetteValide = true;

            Debug.Log("recette valide : " + recetteValide);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bread") && bread1 != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            bread1 = null;
            Debug.Log("bread exit");
        }
        else if (other.CompareTag("Tomato") && tomato != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            tomato = null;
            Debug.Log("tomato exit");
        }
    }

    private bool EstRecetteComplete()
    {
        Debug.Log("bread1 y : " + bread1.transform.position.y);
        Debug.Log("tomato y : " + tomato.transform.position.y);

        return (bread1.transform.position.y < tomato.transform.position.y);
    }
}
