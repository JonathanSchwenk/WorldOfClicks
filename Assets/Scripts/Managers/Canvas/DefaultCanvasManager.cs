using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dorkbots.ServiceLocatorTools;

public class DefaultCanvasManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI populationValueText;
    [SerializeField] private TextMeshProUGUI maxPopulationValueText;
    [SerializeField] private GameObject shopPanel;

    private IPopulationManager populationManager;

    // Start is called before the first frame update
    void Start() {
        populationManager = ServiceLocator.Resolve<IPopulationManager>();

        // Init shop to off
        shopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        populationValueText.text = populationManager.totPopulation.ToString();
        maxPopulationValueText.text = populationManager.maxPopulation.ToString();
    }

    public void ToggleShop() {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
}
