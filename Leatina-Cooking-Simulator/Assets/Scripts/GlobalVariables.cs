using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool heatOn = false;
    public static bool hotPan = false;
    public static bool validRecipe = false;

    public static string[] firstIngredientOrderListRecipe = { "Meat", "Tomato"};
    public static string[][] secondIngredientOrderListRecipe = {
        new string[] { "Tomato", "Onion", "Mushroom" },
        new string[] { "Onion", "Mushroom" }
    };

    public static int ingredient1;
    public static int ingredient2;

    public static int actualOrder;
    public static bool shouldChangeRecipe = false;
    public static bool shouldDespawnIngredients = false;

}


// public static class GameVariables{
//     public static int allowedTime = 90;
//     public static int currentTime = GameVariables.allowedTime;
//     public static int nbCatBots = 3; 
//     public static int catBotsTouches = 0; 
// }
