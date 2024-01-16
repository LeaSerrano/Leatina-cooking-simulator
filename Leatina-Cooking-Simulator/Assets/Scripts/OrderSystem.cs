using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public GameObject UI_Tomato;
    public GameObject UI_Meat;

    private int orderListSize;
    void Start()
    {
        orderListSize = GlobalVariables.orderList.Length;
        GlobalVariables.actualOrder = Random.Range(0, orderListSize);
        UpdateUI();
    }

    void Update()
    {
        if (GlobalVariables.shouldChangeRecipe && !GlobalVariables.shouldDespawnIngredients)
        {
            if(GlobalVariables.actualOrder == 0) {
                GlobalVariables.actualOrder = 1;
            }
            else {
                GlobalVariables.actualOrder = 0;
            }

            UpdateUI();

           GlobalVariables.shouldChangeRecipe = false;
        }
    }

    void UpdateUI()
    {
        if (UI_Tomato != null)
        {
            UI_Tomato.SetActive(GlobalVariables.actualOrder == 0);
        }
        if (UI_Meat != null)
        {
            UI_Meat.SetActive(GlobalVariables.actualOrder == 1);
        }
    }
}
