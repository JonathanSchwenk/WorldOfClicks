using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class ServiceManager : MonoBehaviour
{
    
    public SaveManager saveManager;
    public AudioManager audioManager;
    public GameManager gameManager;
    public PopulationManager populationManager;
    public BuildingManager buildingManager;
    public ShopManager shopManager;
    


    private void Awake() {
        // If there is no SaveManager service registered, create one, else, do nothing
        if (ServiceLocator.IsRegistered<ISaveManager>()) {
            //Debug.Log("A SaveManager already exists");
            // Loading save here because this script gets executed early which is where I need to load so Im trying here.
            saveManager.Load();
        } else {
            //Debug.Log("SaveManager not found, creating one");
            ServiceLocator.Register<ISaveManager>(saveManager);

            // Loading save here because this script gets executed early which is where I need to load so Im trying here.
            saveManager.Load();
        }

        // If there is no AudioManager service registered, create one, else, do nothing
        if (ServiceLocator.IsRegistered<IAudioManager>()) {
            //Debug.Log("An AudioManager already exists");
        } else {
            //Debug.Log("AudioManager not found, creating one");
            ServiceLocator.Register<IAudioManager>(audioManager);
        }

        if (!ServiceLocator.IsRegistered<IPopulationManager>()) {
            ServiceLocator.Register<IPopulationManager>(populationManager);
        }
        if (!ServiceLocator.IsRegistered<IGameManager>()) {
            ServiceLocator.Register<IGameManager>(gameManager);
        }
        if (!ServiceLocator.IsRegistered<IBuildingManager>()) {
            ServiceLocator.Register<IBuildingManager>(buildingManager);
        }
        if (!ServiceLocator.IsRegistered<IShopManager>()) {
            ServiceLocator.Register<IShopManager>(shopManager);
        }

    }


    private void OnDestroy() {

    }

    private void OnApplicationQuit() {
        if (ServiceLocator.IsRegistered<ISaveManager>()) {
            ServiceLocator.Unregister<ISaveManager>();
        }
        if (ServiceLocator.IsRegistered<IAudioManager>()) {
            ServiceLocator.Unregister<IAudioManager>();
        }
        if (ServiceLocator.IsRegistered<IPopulationManager>()) {
            ServiceLocator.Unregister<IPopulationManager>();
        }
        if (ServiceLocator.IsRegistered<IGameManager>()) {
            ServiceLocator.Unregister<IGameManager>();
        }
        if (ServiceLocator.IsRegistered<IBuildingManager>()) {
            ServiceLocator.Unregister<IBuildingManager>();
        }
        if (ServiceLocator.IsRegistered<IShopManager>()) {
            ServiceLocator.Unregister<IShopManager>();
        }
    }
    

}

