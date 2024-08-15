using System;
using System.Collections;
using System.Collections.Generic;
using Dorkbots.ServiceLocatorTools;
using UnityEngine;

public class PopulationManager : MonoBehaviour, IPopulationManager {
    public long totPopulation { get; set; }
    public long maxPopulation { get; set; }
    public long autoClick { get; set; }
    public int timeAway { get; set; } // Might change this to a DateTime
    public long clickPower { get; set; }

    private int waitBeforeAutoClick = 1;
    private double multiplier = 1;

    private ISaveManager saveManager;

    public void UserClick() {
        // TODO: For now add one but will later get more complex
        totPopulation += clickPower;
    }

    // void Awake() {
    //     totPopulation = 0; // TODO: Load this from a file
    //     populationThreshold = 10;
    // }

    // Start is called before the first frame update
    void Start() {
        saveManager = ServiceLocator.Resolve<ISaveManager>();

        totPopulation = saveManager.saveData.totPopulation;
        maxPopulation = saveManager.saveData.maxPopulation;
        autoClick = saveManager.saveData.autoClick;
        timeAway = saveManager.saveData.timeAway;
        clickPower = saveManager.saveData.clickPower;

        // Start auto click coroutine
        StartCoroutine(WaitAndAutoClick());

        // Adds the population earned while away from the app
        GetPopFromTimeAway();
    }

    // Update is called once per frame
    void Update() {
        HandleUserInput();
    }

    private void HandleUserInput() {
        // TODO: This will get more complex when I try to avoid UI elements and panning and zooming 
        if (Input.GetMouseButtonDown(0)) {
            UserClick();
        }
    }

    private void GetPopFromTimeAway() {
        int numMinAway = (int) (DateTime.Now - saveManager.saveData.timeOfExit).TotalMinutes;
        if (numMinAway > timeAway) {
            numMinAway = timeAway;
        }
        totPopulation += (long)(numMinAway * autoClick * multiplier);
    }

    private void OnApplicationQuit() {
        saveManager.saveData.timeOfExit = DateTime.Now;
        saveManager.saveData.totPopulation = totPopulation;
        saveManager.saveData.maxPopulation = maxPopulation;
        saveManager.saveData.autoClick = autoClick;
        saveManager.saveData.timeAway = timeAway;
        saveManager.saveData.clickPower = clickPower;

        saveManager.Save();
    }

    private IEnumerator WaitAndAutoClick() {
        while (true) {
            yield return new WaitForSeconds(waitBeforeAutoClick);
            totPopulation += autoClick;
        }
    }

}
