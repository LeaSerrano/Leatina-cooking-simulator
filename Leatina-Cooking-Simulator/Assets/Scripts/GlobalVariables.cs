using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool heatOn = false;
    public static bool hotPan = false;
    public static bool validRecipe = false;
    public static string[] orderListRecipe1 = { "Tomato", "Meat"};
    public static string[] firstIngredientOrderListRecipe2 = { "Meat", "Tomato", "Onion", "Mushroom" };
    public static string[][] secondIngredientOrderListRecipe2 = {
        new string[] { "Tomato", "Onion", "Mushroom" },
        new string[] { "Onion", "Mushroom" },
        new string[] { "Meat", "Tomato" },
        new string[] { "Meat", "Tomato" }
    }; 
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
