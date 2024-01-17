using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public GameObject UI_ingredient1;
    public GameObject UI_Tomato_ingredient1;
    public GameObject UI_Meat_ingredient1;

    public GameObject UI_ingredient2;
    public GameObject UI_Meat_ingredient2;
    public GameObject UI_Tomato_Top_ingredient2;
    public GameObject UI_Tomato_Bottom_ingredient2;
    public GameObject UI_Onion_ingredient2;
    public GameObject UI_Mushroom_ingredient2;
    

    private int orderListSize;
    void Start()
    {
        GenerateRandomRecipe();
        UpdateUI();
    }

    void Update()
    {
        if (GlobalVariables.shouldChangeRecipe && !GlobalVariables.shouldDespawnIngredients)
        {
            GenerateRandomRecipe();
            UpdateUI();

           GlobalVariables.shouldChangeRecipe = false;
        }
    }

    void GenerateRandomRecipe()
    {
        GlobalVariables.actualOrder = Random.Range(0, 2);

        if (GlobalVariables.actualOrder == 0)
        {
            GlobalVariables.ingredient1 = Random.Range(0, GlobalVariables.orderListRecipe1.Length);
        }
        else if (GlobalVariables.actualOrder == 1)
        {
            GlobalVariables.ingredient1 = Random.Range(0, GlobalVariables.firstIngredientOrderListRecipe2.Length);
            GlobalVariables.ingredient2 = Random.Range(0, GlobalVariables.secondIngredientOrderListRecipe2[GlobalVariables.ingredient1].Length);
        }
    }
    void UpdateUI()
    {
        UpdateIngredientUI(UI_ingredient1, GlobalVariables.actualOrder == 0);
        UpdateIngredientUI(UI_ingredient2, GlobalVariables.actualOrder == 1);

        if (GlobalVariables.actualOrder == 0)
        {
            UpdateIngredientUI(UI_Tomato_ingredient1, GlobalVariables.ingredient1 == 0);
            UpdateIngredientUI(UI_Meat_ingredient1, GlobalVariables.ingredient1 == 1);
        }
        else
        {
            UpdateIngredientUI(UI_Meat_ingredient2, GlobalVariables.ingredient1 == 0);
            UpdateIngredientUI(UI_Tomato_Bottom_ingredient2, GlobalVariables.ingredient1 == 0);

            if (GlobalVariables.ingredient1 == 0)
            {
                UpdateIngredientUI(UI_Tomato_Top_ingredient2, GlobalVariables.ingredient2 == 0);
                UpdateIngredientUI(UI_Onion_ingredient2, GlobalVariables.ingredient2 == 1);
                UpdateIngredientUI(UI_Mushroom_ingredient2, GlobalVariables.ingredient2 == 2);
            }
            else if (GlobalVariables.ingredient1 == 1)
            {
                UpdateIngredientUI(UI_Onion_ingredient2, GlobalVariables.ingredient2 == 0);
                UpdateIngredientUI(UI_Mushroom_ingredient2, GlobalVariables.ingredient2 == 1);
            }
        }
    }

    void UpdateIngredientUI(GameObject ingredientUI, bool condition)
    {
        if (ingredientUI != null)
        {
            ingredientUI.SetActive(condition);
        }
    }

}
