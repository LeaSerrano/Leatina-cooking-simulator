using UnityEngine;
using System.Collections.Generic;


public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequired;

    private GameObject bread1;
    private GameObject secondItem;
    private string secondItemTag;
    private GameObject bread2;

    private List<string> ingredientList;

    private void Start()
    {
        if (GlobalVariables.actualOrder == 0 || GlobalVariables.actualOrder == 1)
        {
            ingredientsRequired = 3;
            secondItemTag = GlobalVariables.orderList[GlobalVariables.actualOrder];

            Debug.Log(secondItemTag);
            ingredientList = new List<string>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Bread") && bread1 == null)
        {
            bread1 = other.gameObject;
            ingredientsPresent++;

             Debug.Log("enter : bread1");
        }
        else if (other.CompareTag(secondItemTag) && secondItem == null)
        {
            secondItem = other.gameObject;
            ingredientsPresent++;

             Debug.Log("enter : tomato");
        }
        else if (other.CompareTag("Bread") && bread2 == null)
        {
            bread2 = other.gameObject;
            ingredientsPresent++;

             Debug.Log("enter : bread2");
        }*/

        /*if (other.CompareTag("Bread") || other.CompareTag(secondItemTag)) {
            ingredientList.Add(other.tag);
            Debug.Log(other.tag);
        }
       

        if (ingredientList.Count == ingredientsRequired && IsRecipeComplete())
        {
            GlobalVariables.validRecipe = true;
            Debug.Log(GlobalVariables.validRecipe);
        }*/

        if (ingredientList.Count < ingredientsRequired)
    {
        if (other.CompareTag("Bread"))
        {
            if (bread1 == null)
            {
                bread1 = other.gameObject;
                ingredientList.Add(other.tag);
                Debug.Log("Entered: bread1");
            }
            else if (bread2 == null)
            {
                bread2 = other.gameObject;
                ingredientList.Add(other.tag);
                Debug.Log("Entered: bread2");
            }
        }
        else if (other.CompareTag(secondItemTag) && secondItem == null)
        {
            secondItem = other.gameObject;
            ingredientList.Add(other.tag);
            Debug.Log("Entered: " + secondItemTag);
        }
    }

    if (ingredientList.Count == ingredientsRequired && IsRecipeComplete())
    {
        GlobalVariables.validRecipe = true;
        Debug.Log(GlobalVariables.validRecipe);
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
        //if ((bread1.transform.position.y < secondItem.transform.position.y && secondItem.transform.position.y < bread2.transform.position.y) ||
        //    (bread2.transform.position.y < secondItem.transform.position.y && secondItem.transform.position.y < bread1.transform.position.y))
        if (string.Equals(ingredientList[0], "Bread") && string.Equals(ingredientList[1], secondItemTag) && string.Equals(ingredientList[2], "Bread"))
        {
            return true;
        }
        return false;
    }
}
