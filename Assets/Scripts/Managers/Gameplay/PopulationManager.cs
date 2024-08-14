using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour, IPopulationManager {
    public long totPopulation { get; set; }
    public long populationThreshold { get; set; }

    public void UserClick() {
        // TODO: For now add one but will later get more complex
        totPopulation++;
    }

    // void Awake() {
    //     totPopulation = 0; // TODO: Load this from a file
    //     populationThreshold = 10;
    // }

    // Start is called before the first frame update
    void Start() {
        totPopulation = 0; // TODO: Load this from a file
        populationThreshold = 10;
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

}
