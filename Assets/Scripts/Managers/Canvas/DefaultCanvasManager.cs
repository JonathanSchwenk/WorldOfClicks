using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dorkbots.ServiceLocatorTools;

public class DefaultCanvasManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI populationValueText;

    private IPopulationManager populationManager;

    // Start is called before the first frame update
    void Start() {
        populationManager = ServiceLocator.Resolve<IPopulationManager>();
    }

    // Update is called once per frame
    void Update() {
        populationValueText.text = populationManager.totPopulation.ToString();
    }
}
