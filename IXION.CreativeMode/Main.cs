using BulwarkStudios.GameSystems.Ui;
using BulwarkStudios.Stanford;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Menu;
using System;
using UnityEngine;

namespace IXION.CreativeMode
{
    public class Main : MonoBehaviour
    {
        // constructor that takes in a handle and calls the base class constructor
        public Main(IntPtr handle) : base(handle)
        {
        }

        // a flag to track if the class has been initialized
        private bool bInitialized;

        // a GameplayData object that will be used to configure the game
        private GameplayData gameplayData;

        // Update method is called once per frame
        private void Update()
        {
            // if the class has already been initialized, destroy this game object and return
            if (bInitialized)
            {
                Destroy(gameObject);
                return;
            }

            // try to find the MainMenu object in the scene
            var mainMenu = FindObjectOfType<MainMenu>();

            // if MainMenu is not found or the newGame field is not set, return
            if (mainMenu == null || mainMenu.newGame == null) return;

            // if MainMenu is found and the newGame field is set, initialize this class
            Initialize();
        }

        // method to start the game in creative mode
        private void StartGameInCreativeMode()
        {
            // use the GameSetup class to play the game with the configured gameplayData object
            GameSetup.Play(gameplayData);
        }

        #region Initializations

        // method to initialize this class
        private void Initialize()
        {
            // log a message to the console
            Debug.Log("Initializing IXION.CreativeMod");

            // get the gameplay data for the stress test scenario with 4 sectors and 6k citizens
            gameplayData = Helper.GetGameplayData(Helper.GameplayDataIndex.StressTest4Sector6kCitizen);

            // initialize the button
            ConfigureCustomButton();

            // initialize the gameplay data object
            InitializeGameplayData();
        }

        // method to initialize the gameplay data object
        private void InitializeGameplayData()
        {
            InitializeGameDataInfo();
            ConfigurePlayerData();
            ConfigureTorus();
            
            bInitialized = true;
        }

        // method to set the description and title for the game
        private void InitializeGameDataInfo()
        {
            gameplayData.info.description = "Creative Mode";
            gameplayData.info.title = "Creative Mode";
        }

        // Set various properties of the gameplayData.player object to enable or disable certain features or behaviors
        private void ConfigurePlayerData()
        {
            gameplayData.player.allTechnologiesAreUnlockable = true;
            gameplayData.player.buildBuildingsInstantly = true;
            gameplayData.player.buildShipsInstantly = true;
            gameplayData.player.canAddResourcesInStockpile = true;
            gameplayData.player.canBuildDebris = true;
            gameplayData.player.disableHomelessSystem = false;
            gameplayData.player.disableInjurySystem = true;
            gameplayData.player.disableShipAutonomy = false;
            gameplayData.player.disableStarvationSystem = true;
            gameplayData.player.displayDecreesButton = true;
            gameplayData.player.displayEngineButton = true;
            gameplayData.player.displayFleetButton = true;
            gameplayData.player.displayPopulationButton = true;
            gameplayData.player.displayResourcesButton = true;
            gameplayData.player.displayScienceButton = true;
            gameplayData.player.displaySolarPanelButton = false;
            gameplayData.player.displaySolarSystemButton = true;
            gameplayData.player.eventOptionsCompleteInstantly = false;
            gameplayData.player.freezeHullIntegrity = true;
            gameplayData.player.freezeTrust = true;
            gameplayData.player.shipsTravelInstantly = true;
            gameplayData.player.unlockAllBuildings = true;
            gameplayData.player.unlockAllBuildObjects = true;
            gameplayData.player.unlockAllTechnologies = true;
        }

        // method to configure the torus data
        private void ConfigureTorus()
        {
            gameplayData.torus.buildingLoadList = new Il2CppSystem.Collections.Generic.List<BulwarkStudios.Stanford.Torus.Buildings.BuildingStatePreload>();
            gameplayData.torus.ecsSegmentList = gameplayData.torus.ecsSegmentList;
            gameplayData.torus.eddenOnline = true;
            gameplayData.torus.electricityCapacity = 6000;
            gameplayData.torus.evaModules = gameplayData.torus.evaModules;
            gameplayData.torus.hullAmount = 6000;
            gameplayData.torus.lockdoors = gameplayData.torus.lockdoors;
            gameplayData.torus.reached1PercentTrust = gameplayData.torus.reached1PercentTrust;
            gameplayData.torus.reached1PercentTrustGameTime = gameplayData.torus.reached1PercentTrustGameTime;
            gameplayData.torus.roadList = new Il2CppSystem.Collections.Generic.List<BulwarkStudios.Stanford.Torus.Roads.RoadStatePreload>();
            gameplayData.torus.sector1Activated = true;
            gameplayData.torus.sector2Activated = true;
            gameplayData.torus.sector3Activated = true;
            gameplayData.torus.sector4Activated = true;
            gameplayData.torus.sector5Activated = true;
            gameplayData.torus.sector6Activated = true;
            gameplayData.torus.trustAmount = 100;
            gameplayData.torus.useNewGameSettings = false;
            gameplayData.torus.workersSector1 = gameplayData.torus.workersSector1;
            gameplayData.torus.workersSector2 = gameplayData.torus.workersSector2;
            gameplayData.torus.workersSector3 = gameplayData.torus.workersSector3;
            gameplayData.torus.workersSector4 = gameplayData.torus.workersSector4;
            gameplayData.torus.workersSector5 = gameplayData.torus.workersSector5;
            gameplayData.torus.workersSector6 = gameplayData.torus.workersSector6;
        }

        private void ConfigureCustomButton()
        {
            // Find all UiButton objects in the scene
            var buttons = FindObjectsOfType<UiButton>();

            // Initialize variables to store the settings button and main menu transform
            GameObject settingsButton = null;
            Transform mainMenu = null;

            // Iterate through all buttons
            foreach (var button in buttons)
            {
                // Skip the current button if it is not the settings button
                if (button.name != "Button_Settings") continue;

                // Store the settings button and main menu transform
                settingsButton = button.gameObject;
                mainMenu = button.transform.parent;
            }

            // Create a new button based on the settings button
            var _button = Instantiate(settingsButton);
            _button.name = "Button_CreativeMode";

            // Remove the UiButtonTriggerUnityEvent component from the new button
            Destroy(_button.GetComponent("UiButtonTriggerUnityEvent"));

            // Find the text component and update the text to "Creative Mode"
            var text = _button.transform.Find("Text (TMP)");
            text.GetComponent<TMPro.TextMeshProUGUI>().text = "Creative Mode";

            // Set the new button's parent to the main menu and set its scale and sibling index
            _button.gameObject.transform.SetParent(mainMenu.transform);
            _button.transform.localScale = new Vector3(1, 1, 1);
            _button.transform.SetSiblingIndex(2);

            // Get the UiButton component and add an action to the OnTriggered event
            var buttonAction = _button.GetComponent<UiButton>();
            var action = new Action(StartGameInCreativeMode);
            buttonAction.OnTriggered += action;
        }

        #endregion Initializations
    }
}