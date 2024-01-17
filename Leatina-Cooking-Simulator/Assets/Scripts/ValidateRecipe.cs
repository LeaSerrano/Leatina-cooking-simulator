using UnityEngine;
using System.Collections.Generic;


public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequired;

    private string secondItemTag;
    private string thirdItemTag;

    private List<GameObject> sandwichItems = new List<GameObject>();

    public CookMeat CookMeatZone;

    private void Start()
    {
        if (GlobalVariables.actualOrder == 0)
        {
            ingredientsRequired = 3;
            secondItemTag = GlobalVariables.firstIngredientOrderListRecipe[GlobalVariables.ingredient1];
            thirdItemTag = null;

            Debug.Log(secondItemTag);
        }
        else
        {
            ingredientsRequired = 4;
            secondItemTag = GlobalVariables.firstIngredientOrderListRecipe[GlobalVariables.ingredient1];
            thirdItemTag = GlobalVariables.secondIngredientOrderListRecipe[GlobalVariables.ingredient1][GlobalVariables.ingredient2];

            Debug.Log(secondItemTag);
            Debug.Log(thirdItemTag);
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
                if (other.CompareTag("Meat"))
                {
                    if (CookMeatZone != null && CookMeatZone.EstSteakCuit(other.gameObject))
                        {
                            sandwichItems.Add(other.gameObject);
                        }
                    }
                else
                {
                    sandwichItems.Add(other.gameObject);
                }
            }
            else if (thirdItemTag != null && other.CompareTag(thirdItemTag) && !sandwichItems.Contains(other.gameObject))
                {
                    sandwichItems.Add(other.gameObject);
        }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (thirdItemTag != null) {
            if ((other.CompareTag("Bread") || other.CompareTag(secondItemTag) || other.CompareTag(thirdItemTag)) && sandwichItems.Contains(other.gameObject) && sandwichItems.Count > 0)
            {
                sandwichItems.Remove(other.gameObject);
            }
        }
        else {
            if ((other.CompareTag("Bread") || other.CompareTag(secondItemTag)) && sandwichItems.Contains(other.gameObject) && sandwichItems.Count > 0)
            {
                sandwichItems.Remove(other.gameObject);
            }
        }
    }

    private bool IsRecipeComplete()
    {
        float errorMargin = 0.5f;

        if (GlobalVariables.actualOrder == 0)
         {
            if (sandwichItems[0].CompareTag("Bread"))
            {
                if (sandwichItems[1].CompareTag(secondItemTag)) {
                    return CheckSandwichConfiguration(sandwichItems, 0, 1, 2, errorMargin);
                }
                else if (sandwichItems[1].CompareTag("Bread")) {
                    return CheckSandwichConfiguration(sandwichItems, 0, 2, 1, errorMargin);
                }
            }
            else if (sandwichItems[0].CompareTag(secondItemTag))
            {
                return CheckSandwichConfiguration(sandwichItems, 1, 0, 2, errorMargin) ||
                CheckSandwichConfiguration(sandwichItems, 2, 0, 1, errorMargin);
            }
        }
        else {
            if (sandwichItems[0].CompareTag("Bread"))
            {
                if (sandwichItems[1].CompareTag(secondItemTag)) {
                    if (sandwichItems[2].CompareTag(thirdItemTag)) {
                        return CheckSandwichConfiguration(sandwichItems, 0, 1, 2, errorMargin) && CheckSandwichConfiguration(sandwichItems, 1, 2, 3, errorMargin);
                    }
                    else {
                        return CheckSandwichConfiguration(sandwichItems, 0, 1, 3, errorMargin) && CheckSandwichConfiguration(sandwichItems, 1, 3, 2, errorMargin);
                    }
                }
                else if (sandwichItems[1].CompareTag(thirdItemTag)) {
                    if (sandwichItems[2].CompareTag(secondItemTag)) {
                        return CheckSandwichConfiguration(sandwichItems, 0, 2, 1, errorMargin) && CheckSandwichConfiguration(sandwichItems, 2, 1, 3, errorMargin);
                    }
                    else {
                        return CheckSandwichConfiguration(sandwichItems, 0, 3, 1, errorMargin) && CheckSandwichConfiguration(sandwichItems, 3, 1, 2, errorMargin);
                    }
                }
                else {
                    if (sandwichItems[2].CompareTag(secondItemTag)) {
                        return CheckSandwichConfiguration(sandwichItems, 0, 2, 3, errorMargin) && CheckSandwichConfiguration(sandwichItems, 2, 3, 1, errorMargin);
                    }
                    else {
                        return CheckSandwichConfiguration(sandwichItems, 0, 3, 2, errorMargin) && CheckSandwichConfiguration(sandwichItems, 3, 2, 1, errorMargin);
                    }
                }
            }
            else if (sandwichItems[0].CompareTag(secondItemTag))
            {
                if (sandwichItems[1].CompareTag("Bread")) {
                    if (sandwichItems[2].CompareTag(thirdItemTag)) {
                        return CheckSandwichConfiguration(sandwichItems, 1, 0, 2, errorMargin) && CheckSandwichConfiguration(sandwichItems, 0, 2, 3, errorMargin);
                    }
                    else {
                        return CheckSandwichConfiguration(sandwichItems, 1, 0, 3, errorMargin) && CheckSandwichConfiguration(sandwichItems, 0, 3, 2, errorMargin);
                    }
                }
                else if (sandwichItems[1].CompareTag(thirdItemTag)) {
                    return CheckSandwichConfiguration(sandwichItems, 2, 0, 1, errorMargin) && CheckSandwichConfiguration(sandwichItems, 0, 1, 3, errorMargin);
                }
            }
            else if (sandwichItems[0].CompareTag(thirdItemTag))
            {
                if (sandwichItems[1].CompareTag("Bread")) {
                    if (sandwichItems[2].CompareTag(secondItemTag)) {
                        return CheckSandwichConfiguration(sandwichItems, 1, 0, 2, errorMargin) && CheckSandwichConfiguration(sandwichItems, 0, 2, 3, errorMargin);
                    }
                    else {
                        return CheckSandwichConfiguration(sandwichItems, 1, 0, 3, errorMargin) && CheckSandwichConfiguration(sandwichItems, 0, 3, 2, errorMargin);
                    }
                }
                else if (sandwichItems[1].CompareTag(secondItemTag)) {
                    return CheckSandwichConfiguration(sandwichItems, 2, 1, 0, errorMargin) && CheckSandwichConfiguration(sandwichItems, 1, 0, 3, errorMargin);
                }
            }
        }

        return false;
    }

    bool CheckSandwichConfiguration(List<GameObject> sandwichItems, int index0, int index1, int index2, float errorMargin)
{
    return Mathf.Abs(sandwichItems[index0].transform.position.y - sandwichItems[index1].transform.position.y) < errorMargin &&
           Mathf.Abs(sandwichItems[index1].transform.position.y - sandwichItems[index2].transform.position.y) < errorMargin;
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
