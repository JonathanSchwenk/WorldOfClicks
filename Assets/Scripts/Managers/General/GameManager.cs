using UnityEngine;
using System;
using Dorkbots.ServiceLocatorTools;
using System.Collections.Generic;

public class GameManager : MonoBehaviour, IGameManager
{
    public GameState State {get; set;}
    public Action<GameState> OnGameStateChanged {get; set;}
    public String worldName {get; set;} // TODO: Save this to a file so I know where to continue from when I load the game


    private ISaveManager saveManager;
    private IAudioManager audioManager;





    void OnDestroy() {
        OnGameStateChanged = null;
    }

    // Sets the state to ready when the game starts 
    void Start() {
        saveManager = ServiceLocator.Resolve<ISaveManager>();
        audioManager = ServiceLocator.Resolve<IAudioManager>();

        InitGame();

        saveManager.Load();
    }

    // For next game, control more with this game managers state machine to keep everything in one spot
    // Update game state function
    public void UpdateGameState(GameState newState) {
        State = newState;

        // Swtich statement that deals with each possible state 
        switch(newState) {
            case GameState.Tutorial:

                break;
            case GameState.Idle:
                
                break;
            case GameState.Playing:
                
                break;
            case GameState.GameOver:

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        
        // Null checker then calls the action for anthing subscribed to it
        OnGameStateChanged?.Invoke(newState);
    } 

    private void InitGame() {
        // TODO: Sets the world name if its not set yet. For now it will be set to the first world which is WildWest
        worldName = "WildWest";
    }


}




// GameState enum (basically a definition)
public enum GameState {
    Tutorial,
    Idle,
    Playing,
    GameOver
}


