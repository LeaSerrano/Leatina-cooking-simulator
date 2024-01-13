using UnityEngine;

public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequired;

    private GameObject bread1;
    private GameObject secondItem;
    private string secondItemTag;
    private GameObject bread2;

    private void Start()
    {
        if (GlobalVariables.actualOrder == 0 || GlobalVariables.actualOrder == 1)
        {
            ingredientsRequired = 3;
            secondItemTag = GlobalVariables.orderList[GlobalVariables.actualOrder];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bread") && bread1 == null)
        {
            bread1 = other.gameObject;
            ingredientsPresent++;
        }
        else if (other.CompareTag(secondItemTag) && secondItem == null)
        {
            secondItem = other.gameObject;
            ingredientsPresent++;
        }
        else if (other.CompareTag("Bread") && bread2 == null)
        {
            bread2 = other.gameObject;
            ingredientsPresent++;
        }

        if (ingredientsPresent == ingredientsRequired && IsRecipeComplete())
        {
            GlobalVariables.validRecipe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bread") && bread1 != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            bread1 = null;
        }
        else if (other.CompareTag(secondItemTag) && secondItem != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            secondItem = null;
        }
        else if (other.CompareTag("Bread") && bread2 != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            bread2 = null;
        }
    }

    private bool IsRecipeComplete()
    {
        if ((bread1.transform.position.y < secondItem.transform.position.y && secondItem.transform.position.y < bread2.transform.position.y) ||
            (bread2.transform.position.y < secondItem.transform.position.y && secondItem.transform.position.y < bread1.transform.position.y))
        {
            return true;
        }
        return false;
    }
}
