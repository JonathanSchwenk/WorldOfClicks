using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour, IClickManager {
    public long totClicks { get; set; }

    public void AddClick() {
        // TODO: For now add one but will later get more complex
        totClicks++;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        HandleUserInput();
    }

    private void HandleUserInput() {
        // TODO: This will get more complex when I try to avoid UI elements and panning and zooming 
        if (Input.GetMouseButtonDown(0)) {
            AddClick();
        }
    }

}
