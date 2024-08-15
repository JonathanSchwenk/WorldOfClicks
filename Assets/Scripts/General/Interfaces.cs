using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IGameManager {
    GameState State { get; set; }
    void UpdateGameState(GameState state);
    String worldName {get; set;}
}

public interface IObjectPooler {
    List<Pool> Pools { get; set; }
    Dictionary<string, Queue<GameObject>> poolDictionary { get; set; }

    GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation);
}

public interface ISaveManager {
    SaveData saveData { get; set; }
    Action<int> OnSave { get; set; }

    void Save();
    void Load();
    void DeleteSavedData();
}

public interface IAudioManager {
    void PlaySFX(string name);
    void StopSFX(string name);
    void PlayMusic(string name);
    void StopMusic(string name);
}


public interface IAdManager {
    void LoadRewardedAd();
}

public interface IPopulationManager {
    long totPopulation { get; set; }
    long maxPopulation { get; set; }
    long autoClick { get; set; }
    int timeAway { get; set; }
    long clickPower { get; set; }
    void UserClick();
}

public interface IBuildingManager {
    List<ObjectsToAppear> objectsToAppear_Global { get; set; }
    int nextObjectIndex { get; set; }
    public void AddItemToList();
}

public interface IShopManager {
    long cost_WorldUpgrade { get; set; }
    long cost_AutoClickUpgrade { get; set; }
    long cost_TimeAwayUpgrade { get; set; }
    long cost_ClickPowerUpgrade { get; set; }

    long increaseValue_WorldUpgrade { get; set; }
    long increaseValue_AutoClickUpgrade { get; set; }
    int increaseValue_TimeAwayUpgrade { get; set; }
    long increaseValue_ClickPowerUpgrade { get; set; }
    
}