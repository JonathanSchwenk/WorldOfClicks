using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dorkbots.ServiceLocatorTools;
using NUnit.Framework;

public class ShopCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject worldDefaultView;
    [SerializeField] private GameObject worldInfoView;
    [SerializeField] private GameObject autoClickDefaultView;
    [SerializeField] private GameObject autoClickInfoView;
    [SerializeField] private GameObject awayTimerDefaultView;
    [SerializeField] private GameObject awayTimerInfoView;
    [SerializeField] private GameObject clickPowerDefaultView;
    [SerializeField] private GameObject clickPowerInfoView;

    

    // WorldUpgrade
    [SerializeField] private TextMeshProUGUI cost_WorldUpgradeText;
    [SerializeField] private TextMeshProUGUI currentValue_WorldUpgradeText;
    [SerializeField] private TextMeshProUGUI increaseValue_WorldUpgradeText;

    // AutoClickUpgrade
    [SerializeField] private TextMeshProUGUI cost_AutoClickUpgradeText;
    [SerializeField] private TextMeshProUGUI currentValue_AutoClickUpgradeText;
    [SerializeField] private TextMeshProUGUI increaseValue_AutoClickUpgradeText;

    // TimeAwayUpgrade
    [SerializeField] private TextMeshProUGUI cost_TimeAwayUpgradeText;
    [SerializeField] private TextMeshProUGUI currentValue_TimeAwayUpgradeText;
    [SerializeField] private TextMeshProUGUI increaseValue_TimeAwayUpgradeText;

    // ClickPowerUpgrade
    [SerializeField] private TextMeshProUGUI cost_ClickPowerUpgradeText;
    [SerializeField] private TextMeshProUGUI currentValue_ClickPowerUpgradeText;
    [SerializeField] private TextMeshProUGUI increaseValue_ClickPowerUpgradeText;


    private IShopManager shopManager;
    private IPopulationManager populationManager;
    private IBuildingManager buildingManager;
    private ISaveManager saveManager;


    // Start is called before the first frame update
    void Start()
    {
        shopManager = ServiceLocator.Resolve<IShopManager>();
        populationManager = ServiceLocator.Resolve<IPopulationManager>();
        buildingManager = ServiceLocator.Resolve<IBuildingManager>();
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        // InitInfoButtons();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayShopTextValues();
    }

    #region shop buttons

    private void DisplayShopTextValues() {
        // WorldUpgrade
        cost_WorldUpgradeText.text = shopManager.cost_WorldUpgrade.ToString();
        currentValue_WorldUpgradeText.text = populationManager.maxPopulation.ToString();
        increaseValue_WorldUpgradeText.text = shopManager.increaseValue_WorldUpgrade.ToString();

        // AutoClickUpgrade
        cost_AutoClickUpgradeText.text = shopManager.cost_AutoClickUpgrade.ToString();
        currentValue_AutoClickUpgradeText.text = populationManager.autoClick.ToString();
        increaseValue_AutoClickUpgradeText.text = shopManager.increaseValue_AutoClickUpgrade.ToString();

        // ClickPowerUpgrade
        cost_ClickPowerUpgradeText.text = shopManager.cost_ClickPowerUpgrade.ToString();
        currentValue_ClickPowerUpgradeText.text = populationManager.clickPower.ToString();
        increaseValue_ClickPowerUpgradeText.text = shopManager.increaseValue_ClickPowerUpgrade.ToString();

        // TimeAwayUpgrade
        cost_TimeAwayUpgradeText.text = shopManager.cost_TimeAwayUpgrade.ToString();
        currentValue_TimeAwayUpgradeText.text = populationManager.timeAway.ToString();
        increaseValue_TimeAwayUpgradeText.text = shopManager.increaseValue_TimeAwayUpgrade.ToString();
    }

    public void WorldUpgrade() {
        if (populationManager.totPopulation >= shopManager.cost_WorldUpgrade) {
            buildingManager.AddItemToList();

            // Subtract the population threshold from the total population
            populationManager.totPopulation -= shopManager.cost_WorldUpgrade;

            // Increase the max population
            populationManager.maxPopulation += shopManager.increaseValue_WorldUpgrade;

            // Increase increaseValue
            shopManager.increaseValue_WorldUpgrade += shopManager.increaseValue_WorldUpgrade; //TODO: Make this more dynamic

            // Increase the cost of the world upgrade
            shopManager.cost_WorldUpgrade += 50; //TODO: Make this more dynamic

            // Save stats
            saveManager.saveData.maxPopulation = populationManager.maxPopulation;
            saveManager.saveData.cost_WorldUpgrade = shopManager.cost_WorldUpgrade;
            saveManager.saveData.increaseValue_WorldUpgrade = shopManager.increaseValue_WorldUpgrade;
            saveManager.Save();
        }
    }

    public void ClickPowerUpgrade() {
        if (populationManager.totPopulation >= shopManager.cost_ClickPowerUpgrade) {
            // Subtract the population threshold from the total population
            populationManager.totPopulation -= shopManager.cost_ClickPowerUpgrade;

            // Increase the max population
            populationManager.clickPower += shopManager.increaseValue_ClickPowerUpgrade;

            // Increase increaseValue
            shopManager.increaseValue_ClickPowerUpgrade += shopManager.increaseValue_ClickPowerUpgrade; //TODO: Make this more dynamic

            // Increase the cost of the world upgrade
            shopManager.cost_ClickPowerUpgrade += 50; //TODO: Make this more dynamic

            // Save stats
            saveManager.saveData.clickPower = populationManager.clickPower;
            saveManager.saveData.cost_ClickPowerUpgrade = shopManager.cost_ClickPowerUpgrade;
            saveManager.saveData.increaseValue_ClickPowerUpgrade = shopManager.increaseValue_ClickPowerUpgrade;
            saveManager.Save();
        }
    }

    public void AutoClickUpgrade() {
        if (populationManager.totPopulation >= shopManager.cost_AutoClickUpgrade) {
            // Subtract the population threshold from the total population
            populationManager.totPopulation -= shopManager.cost_AutoClickUpgrade;

            // Increase the max population
            populationManager.autoClick += shopManager.increaseValue_AutoClickUpgrade;

            // Increase increaseValue
            shopManager.increaseValue_AutoClickUpgrade += shopManager.increaseValue_AutoClickUpgrade; //TODO: Make this more dynamic

            // Increase the cost of the world upgrade
            shopManager.cost_AutoClickUpgrade += 50; //TODO: Make this more dynamic

            // Save stats
            saveManager.saveData.autoClick = populationManager.autoClick;
            saveManager.saveData.cost_AutoClickUpgrade = shopManager.cost_AutoClickUpgrade;
            saveManager.saveData.increaseValue_AutoClickUpgrade = shopManager.increaseValue_AutoClickUpgrade;
            saveManager.Save();
        }
    }

    public void TimeAwayUpgrade() {
        if (populationManager.totPopulation >= shopManager.cost_TimeAwayUpgrade) {
            // Subtract the population threshold from the total population
            populationManager.totPopulation -= shopManager.cost_TimeAwayUpgrade;

            // Increase the max population
            populationManager.timeAway += shopManager.increaseValue_TimeAwayUpgrade;

            // Increase increaseValue
            shopManager.increaseValue_TimeAwayUpgrade += shopManager.increaseValue_TimeAwayUpgrade; //TODO: Make this more dynamic

            // Increase the cost of the world upgrade
            shopManager.cost_TimeAwayUpgrade += 50; //TODO: Make this more dynamic

            // Save stats
            saveManager.saveData.timeAway = populationManager.timeAway;
            saveManager.saveData.cost_TimeAwayUpgrade = shopManager.cost_TimeAwayUpgrade;
            saveManager.saveData.increaseValue_TimeAwayUpgrade = shopManager.increaseValue_TimeAwayUpgrade;
            saveManager.Save();
        }
    }

    #endregion

    #region info buttons

    public void WorldInfoView() {
        worldDefaultView.SetActive(!worldDefaultView.activeSelf);
        worldInfoView.SetActive(!worldInfoView.activeSelf);
    }

    public void AutoClickInfoView() {
        autoClickDefaultView.SetActive(!autoClickDefaultView.activeSelf);
        autoClickInfoView.SetActive(!autoClickInfoView.activeSelf);
    }

    public void TimeAwayInfoView() {
        awayTimerDefaultView.SetActive(!awayTimerDefaultView.activeSelf);
        awayTimerInfoView.SetActive(!awayTimerInfoView.activeSelf);
    }

    public void ClickPowerInfoView() {
        clickPowerDefaultView.SetActive(!clickPowerDefaultView.activeSelf);
        clickPowerInfoView.SetActive(!clickPowerInfoView.activeSelf);
    }

    #endregion
}
