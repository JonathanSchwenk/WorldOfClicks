using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dorkbots.ServiceLocatorTools;

public class BuildingManager : MonoBehaviour, IBuildingManager {

    [SerializeField] private List<ObjectsToAppear> objectsToAppear_Total;
    public List<ObjectsToAppear> objectsToAppear_Global { get; set; }

    /*
        Want a total list of objects to appear that I reference in the inspector that I use to turn the objects on and off, 
        and also use it to add to the global list that I save to a file.

        Then as the game progresses I will add to the global list and save it to a file.

        Also, as I add to the global list, I will enable the same object in the total list.

        When I load the game, I will load the global list and enable the objects in the total list that are in the global list.
    */

    public int nextObjectIndex { get; set; } // TODO: Save this so I know where to continue from when I load the game

    private IPopulationManager populationManager;
    private IGameManager gameManager;
    private IShopManager shopManager;

    private void Awake() {
        objectsToAppear_Global = new List<ObjectsToAppear>();
        InitGlobalList();
    }

    // Start is called before the first frame update
    void Start() {
        populationManager = ServiceLocator.Resolve<IPopulationManager>();
        gameManager = ServiceLocator.Resolve<IGameManager>();
        shopManager = ServiceLocator.Resolve<IShopManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void InitGlobalList() {
        // TODO: Would load the list here 

        for (int i = 0; i < objectsToAppear_Total.Count; i++) {
            ObjectsToAppear newObjectToAdd = new ObjectsToAppear {
                worldName = objectsToAppear_Total[i].worldName,
                list = new List<GameObject>()
            };
            objectsToAppear_Global.Add(newObjectToAdd);
        }
    }

    // TODO: Read int global list as well as the next object index

    // TODO: Set total list to enable the correct objects based on the global list

    // This adds an item to the list of game objects that will appear in the world I.e. objectsToAppear_Global.list
    public void AddItemToList() {
        for (int i = 0; i < objectsToAppear_Total.Count; i++) {
            if (objectsToAppear_Total[i].worldName == gameManager.worldName) {
                // print("i: " + i + " worldName: " + objectsToAppear_Total[i].worldName);
                // print("nextObjectIndex: " + nextObjectIndex + " objectsToAppear_Total[i].list[nextObjectIndex]: " + objectsToAppear_Total[i].list[nextObjectIndex].name);
                // print("objectsToAppear_Global.worldName: " + objectsToAppear_Global[i].worldName);

                // Add to global list 
                objectsToAppear_Global[i].list.Add(objectsToAppear_Total[i].list[nextObjectIndex]);

                // Enable the object in the total list
                objectsToAppear_Total[i].list[nextObjectIndex].SetActive(true);

                // Increment the next object index
                nextObjectIndex++;

                // TODO: Save the global list

                break;
            }
        }
    }
}
