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

    private List<GameObject> sandwichItems = new List<GameObject>();

    private void Start()
    {
        if (GlobalVariables.actualOrder == 0 || GlobalVariables.actualOrder == 1)
        {
            ingredientsRequired = 3;
            secondItemTag = GlobalVariables.orderList[GlobalVariables.actualOrder];
        }

        bread1 = null;
        bread2 = null;
        secondItem = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (ingredientsPresent < ingredientsRequired)
        {
            if (other.CompareTag("Bread"))
            {
                if (bread1 == null)
                {
                    bread1 = other.gameObject;
                    Debug.Log("position bread1 : " + other.gameObject.transform.position);
                    ingredientsPresent++;
                }
                else if (bread2 == null && other.gameObject != bread1)
                {
                    bread2 = other.gameObject;
                    Debug.Log("position bread2 : " + other.gameObject.transform.position);
                    ingredientsPresent++;
                }
            }
            else if (other.CompareTag(secondItemTag) && secondItem == null)
            {
                secondItem = other.gameObject;
                Debug.Log("position " + secondItemTag + " : " + other.gameObject.transform.position);
                ingredientsPresent++;
            }
        }

        if (ingredientsPresent == ingredientsRequired && IsRecipeComplete())
        {
            GlobalVariables.validRecipe = true;
            Debug.Log(GlobalVariables.validRecipe);
        }*/
        if (sandwichItems.Count < ingredientsRequired)
        {
            if (other.CompareTag("Bread") && !sandwichItems.Contains(other.gameObject))
            {
                sandwichItems.Add(other.gameObject);
                //Debug.Log("position bread : " + other.gameObject.transform.position);
                //ingredientsPresent++;
            }
            else if (other.CompareTag(secondItemTag) && !sandwichItems.Contains(other.gameObject))
            {
                sandwichItems.Add(other.gameObject);
                //Debug.Log("position " + secondItemTag + " : " + other.gameObject.transform.position);
                //ingredientsPresent++;
            }

            /*for (int i = 0; i < sandwichItems.Count; i++) {
                Debug.Log(sandwichItems[i] + " " + sandwichItems[i].tag);
            }*/
            //Debug.Log(sandwichItems.Count + " " + ingredientsRequired);
            //Debug.Log("-------------------");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.CompareTag("Bread") && bread1 != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            bread1 = null;
            //Debug.Log("Exit: bread1");
        }
        else if (other.CompareTag(secondItemTag) && secondItem != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            secondItem = null;
            //Debug.Log("Exit: " + secondItemTag);
        }
        else if (other.CompareTag("Bread") && bread2 != null && ingredientsPresent > 0)
        {
            ingredientsPresent--;
            bread2 = null;
            //Debug.Log("Exit: bread2");
        }*/

        if ((other.CompareTag("Bread") || other.CompareTag(secondItemTag)) && sandwichItems.Contains(other.gameObject) && sandwichItems.Count > 0)
        {
            sandwichItems.Remove(other.gameObject);
        }
    }

    private bool IsRecipeComplete()
    {
        float errorMargin = 0.5f;

        /*if (Mathf.Abs(bread1.transform.position.y - secondItem.transform.position.y) < errorMargin &&
            Mathf.Abs(secondItem.transform.position.y - bread2.transform.position.y) < errorMargin)
        {
            return true;
        }

        if (Mathf.Abs(bread2.transform.position.y - secondItem.transform.position.y) < errorMargin &&
            Mathf.Abs(secondItem.transform.position.y - bread1.transform.position.y) < errorMargin)
        {
            return true;
        }*/

        /*for (int i = 0; i < ingredientsRequired; i++)
        {
            string expectedTag = (i < 2) ? "Bread" : secondItemTag;
            
            if (!sandwichItems[i].CompareTag(expectedTag))
            {
                return false;

                Debug.Log(i + " " + expectedTag + " " + sandwichItems[i].tag);
            }
        }*/

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
            Debug.Log(GlobalVariables.validRecipe);
        }
        
        if (GlobalVariables.shouldDespawnIngredients) 
        {
            foreach (GameObject item in sandwichItems)
            {
                Debug.Log("destroy item : " + item.transform.position);
                Destroy(item);
            }

            sandwichItems.Clear();
            ingredientsPresent = 0;

            GlobalVariables.shouldDespawnIngredients = false;
   
             /*Debug.Log("destroy bread1 : " + bread1.transform.position);


             if (bread1 != null)
            {
                Destroy(bread1);
                bread1 = null;
            }

             Debug.Log("destroy bread2 : " + bread2.transform.position);

            if (bread2 != null)
            {
                Destroy(bread2);
                bread2 = null;
            }

             Debug.Log("destroy tomate : " + secondItem.transform.position);

            if (secondItem != null)
            {
                Destroy(secondItem);
                secondItem = null;
            }

            ingredientsPresent = 0;

            GlobalVariables.shouldDespawnIngredients = false;*/
        }
    }
}
