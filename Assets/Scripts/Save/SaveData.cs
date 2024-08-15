using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData 
{
    public bool SFXOn = true;
    public bool musicOn = true;

    public String worldName = "WildWest";

    // Going to have problems with this because it has a list of GameObjects in it which are not serializable
    // public List<ObjectsToAppear> objectsToAppear_Global = new List<ObjectsToAppear>();

    public long totPopulation = 0;
    public long maxPopulation = 1000;
    public long autoClick = 0;
    public int timeAway = 1;
    public long clickPower = 1;

    public long cost_WorldUpgrade = 40;
    public long cost_AutoClickUpgrade = 50;
    public long cost_TimeAwayUpgrade = 100;
    public long cost_ClickPowerUpgrade = 25;
    
    public long increaseValue_WorldUpgrade = 500;
    public long increaseValue_AutoClickUpgrade = 25;
    public int increaseValue_TimeAwayUpgrade = 1;
    public long increaseValue_ClickPowerUpgrade = 10;

    public DateTime timeOfExit;
}

