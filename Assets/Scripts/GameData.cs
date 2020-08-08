using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]


public class GameData
{

    /* Song INFO
     * Song 1 : API - Paradise on E Remix
     * Song 2 : Dimrain47 - Forsaken Neon
     * Song 3 : Devin Martin - Killbot (Speed Up version)
     * Song 4 : Holder - The Quick Brown Fox - The Big Black Remix
     * Song 5 : MegaSphere - Inferno
     */
    public int[,] hscore = new int[6, 3] { {0,0,0}, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] maxcombo = new int[6, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

}