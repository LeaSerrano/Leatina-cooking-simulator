using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool heatOn = false;
    public static bool hotPan = false;
    public static bool validRecipe = false;
    public static string[] orderList = { "Tomato", "Meat"/*, "full" */};
    public static int actualOrder;
}


// public static class GameVariables{
//     public static int allowedTime = 90;
//     public static int currentTime = GameVariables.allowedTime;
//     public static int nbCatBots = 3; 
//     public static int catBotsTouches = 0; 
// }
