using UnityEngine;
using System.Collections.Generic;


public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequired;

    private string secondItemTag;
    private string thirdItemTag;

    private List<GameObject> sandwichItems = new List<GameObject>();

    private void Start()
    {
        if (GlobalVariables.actualOrder == 0)
        {
            ingredientsRequired = 3;
            secondItemTag = GlobalVariables.orderListRecipe1[GlobalVariables.actualOrder];
            thirdItemTag = null;
        }
        else
        {
            ingredientsRequired = 4;
            secondItemTag = GlobalVariables.firstIngredientOrderListRecipe2[GlobalVariables.actualOrder];
            thirdItemTag = GlobalVariables.secondIngredientOrderListRecipe2[GlobalVariables.ingredient1][GlobalVariables.ingredient2];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (sandwichItems.Count < ingredientsRequired)
        {
            if (other.CompareTag("Bread") && !sandwichItems.Contains(other.gameObject))
            {
                sandwichItems.Add(other.gameObject);
            }
            else if (other.CompareTag(secondItemTag) && !sandwichItems.Contains(other.gameObject))
            {
                if (secondItemTag == "Meat")
                {
                    SteakBehaviour steakComponent = other.gameObject.GetComponent<SteakBehaviour>();

                    if (steakComponent != null && steakComponent.EstCuit())
                    {
                        sandwichItems.Add(other.gameObject);
                    }
                }
                else
                {
                    sandwichItems.Add(other.gameObject);
                }
            }
            else if (other.CompareTag(thirdItemTag) && !sandwichItems.Contains(other.gameObject) && thirdItemTag != null)
            {
                sandwichItems.Add(other.gameObject);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if ((other.CompareTag("Bread") || other.CompareTag(secondItemTag) || other.CompareTag(thirdItemTag)) && sandwichItems.Contains(other.gameObject) && sandwichItems.Count > 0)
        {
            sandwichItems.Remove(other.gameObject);
        }
    }

    private bool IsRecipeComplete()
    {
        float errorMargin = 0.5f;

        /* if (GlobalVariables.actualOrder == 0)
         {
             if (sandwichItems[0].CompareTag("Bread"))
             {
                 if (sandwichItems[1].CompareTag(secondItemTag) && sandwichItems[2].CompareTag("Bread"))
                 {
                     if (Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                     else if (Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                 }
                 else if (sandwichItems[1].CompareTag("Bread") && sandwichItems[2].CompareTag(secondItemTag))
                 {
                     if (Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                         Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                     else if (Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                       Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                 }
             }
             else if (sandwichItems[0].CompareTag(secondItemTag))
             {
                 if (Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin &&
                         Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin)
                 {
                     return true;
                 }

                 else if (Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin &&
                     Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin)
                 {
                     return true;
                 }
             }
         }
         else
         {
             if (sandwichItems[0].CompareTag("Bread"))
             {
                 if (sandwichItems[1].CompareTag(secondItemTag) && sandwichItems[2].CompareTag(thirdItemTag) && sandwichItems[3].CompareTag("Bread"))
                 {
                     if (Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[3].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                     else if (Mathf.Abs(sandwichItems[3].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin &&
                        Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                 }
                 else if (sandwichItems[1].CompareTag("Bread") && sandwichItems[2].CompareTag(secondItemTag))
                 {
                     if (Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                         Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                     else if (Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin &&
                       Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin)
                     {
                         return true;
                     }
                 }
             }
             else if (sandwichItems[0].CompareTag(secondItemTag))
             {
                 if (Mathf.Abs(sandwichItems[1].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin &&
                         Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[2].transform.position.y) < errorMargin)
                 {
                     return true;
                 }

                 else if (Mathf.Abs(sandwichItems[2].transform.position.y - sandwichItems[0].transform.position.y) < errorMargin &&
                     Mathf.Abs(sandwichItems[0].transform.position.y - sandwichItems[1].transform.position.y) < errorMargin)
                 {
                     return true;
                 }
             }
             else if (sandwichItems[0].CompareTag(thirdItemTag))
             {
             }*/

        sandwichItems.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));

        if (GlobalVariables.actualOrder == 0)
        {
            if (sandwichItems[0].CompareTag("Bread") && sandwichItems[1].CompareTag(secondItemTag) && sandwichItems[2].CompareTag("Bread"))
            {
                return true;
            }
        }
        else
        {
            if (sandwichItems[0].CompareTag("Bread") && sandwichItems[1].CompareTag(secondItemTag) && sandwichItems[1].CompareTag(thirdItemTag) && sandwichItems[3].CompareTag("Bread"))
            {
                return true;
            }
        }

        return false;
    }

    void Update() {

        if (sandwichItems.Count == ingredientsRequired && IsRecipeComplete())
        {
            GlobalVariables.validRecipe = true;
        }
        
        if (GlobalVariables.shouldDespawnIngredients) 
        {
            foreach (GameObject item in sandwichItems)
            {
                Destroy(item);
            }

            sandwichItems.Clear();
            ingredientsPresent = 0;

            GlobalVariables.shouldDespawnIngredients = false;
        }
    }
}
