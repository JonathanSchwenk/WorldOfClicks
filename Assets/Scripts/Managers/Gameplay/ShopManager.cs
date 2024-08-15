using System.Collections;
using System.Collections.Generic;
using Dorkbots.ServiceLocatorTools;
using UnityEngine;

public class ShopManager : MonoBehaviour, IShopManager
{

    public long cost_WorldUpgrade { get; set; }
    public long cost_AutoClickUpgrade { get; set; }
    public long cost_TimeAwayUpgrade { get; set; }
    public long cost_ClickPowerUpgrade { get; set; }

    public long increaseValue_WorldUpgrade { get; set; }
    public long increaseValue_AutoClickUpgrade { get; set; }
    public int increaseValue_TimeAwayUpgrade { get; set; }
    public long increaseValue_ClickPowerUpgrade { get; set; }

    private IPopulationManager populationManager;
    private ISaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        populationManager = ServiceLocator.Resolve<IPopulationManager>();
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        InitShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitShop() {
        cost_WorldUpgrade = saveManager.saveData.cost_WorldUpgrade;
        cost_AutoClickUpgrade = saveManager.saveData.cost_AutoClickUpgrade;
        cost_TimeAwayUpgrade = saveManager.saveData.cost_TimeAwayUpgrade;
        cost_ClickPowerUpgrade = saveManager.saveData.cost_ClickPowerUpgrade;

        increaseValue_WorldUpgrade = saveManager.saveData.increaseValue_WorldUpgrade;
        increaseValue_AutoClickUpgrade = saveManager.saveData.increaseValue_AutoClickUpgrade;
        increaseValue_TimeAwayUpgrade = saveManager.saveData.increaseValue_TimeAwayUpgrade;
        increaseValue_ClickPowerUpgrade = saveManager.saveData.increaseValue_ClickPowerUpgrade;
    }
}
