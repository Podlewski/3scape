using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariable
{
    public static bool isMageInMiddle = true;
    public static bool isKnightInMiddle = true;
    public static float swapCooldown = 0;
    public const string keysFilepath = "./keys.sav";
    public const string uiFilepath = "./ui.sav";
    public const string soundFilepath = "./sound.sav";
    public static bool direction = false; //right
}
