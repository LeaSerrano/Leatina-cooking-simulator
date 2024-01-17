using UnityEngine;
using System.Collections.Generic;


public class ValidateRecipe : MonoBehaviour
{
    private int ingredientsPresent = 0;
    private int ingredientsRequired;

    private string secondItemTag;

    private List<GameObject> sandwichItems = new List<GameObject>();

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
        if (sandwichItems.Count < ingredientsRequired)
        {
            if (other.CompareTag("Bread") && !sandwichItems.Contains(other.gameObject))
            {
                sandwichItems.Add(other.gameObject);
            }
            else if (other.CompareTag(secondItemTag) && !sandwichItems.Contains(other.gameObject))
            {
                if (secondItemTag == "Tomato")
                {
                    sandwichItems.Add(other.gameObject);
                }
                else if (secondItemTag == "Meat")
                {
                    SteakBehaviour steakComponent = other.gameObject.GetComponent<SteakBehaviour>();

                    if (steakComponent != null && steakComponent.EstCuit())
                    {
                        sandwichItems.Add(other.gameObject);
                    }
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if ((other.CompareTag("Bread") || other.CompareTag(secondItemTag)) && sandwichItems.Contains(other.gameObject) && sandwichItems.Count > 0)
        {
            sandwichItems.Remove(other.gameObject);
        }
    }

    private bool IsRecipeComplete()
    {
        float errorMargin = 0.5f;

        if (sandwichItems[0].CompareTag("Bread")) {
            if (sandwichItems[1].CompareTag(secondItemTag) && sandwichItems[2].CompareTag("Bread")) {
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
            else if (sandwichItems[1].CompareTag("Bread") && sandwichItems[2].CompareTag(secondItemTag)) {
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
        else if (sandwichItems[0].CompareTag(secondItemTag)) {
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
