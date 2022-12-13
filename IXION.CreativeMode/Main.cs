using BulwarkStudios.GameSystems.Ui;
using BulwarkStudios.Stanford;
using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Menu;
using System;
using UnityEngine;

namespace IXION.CreativeMode;

public class Main : MonoBehaviour
{
    public Main(IntPtr handle) : base(handle)
    {
    }

    private bool bInitialized;
    private GameplayData gameplayData;

    private void Update()
    {
        if (bInitialized) return;
        var mainMenu = FindObjectOfType<MainMenu>();
        if (mainMenu == null || mainMenu.newGame == null) return;
        Initialize();
    }

    private void StartGameInCreativeMode()
    {
        GameSetup.Play(gameplayData);
    }

    #region Initializations

    private void Initialize()
    {
        gameplayData = Helper.GetGameplayData(Helper.GameplayDataIndex.StressTest4Sector6kCitizen);
        InitializeButton();
        InitializeGameplayData();
    }

    private void InitializeGameplayData()
    {
        InitializeGameDataInfo();
        InitializePlayerData();
        InitializeTorus();
        bInitialized = true;
    }

    private void InitializeGameDataInfo()
    {
        gameplayData.info.description = "Creative Mode";
        gameplayData.info.title = "Creative Mode";
    }

    private void InitializePlayerData()
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

    private void InitializeTorus()
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

    private void InitializeButton()
    {
        // TLDR: find buttons in the mainmenu, get the settings button and clone it then change it's button action

        var buttons = FindObjectsOfType<UiButton>();
        GameObject settingsButton = null;
        Transform mainMenu = null;
        foreach (var button in buttons)
        {
            if (button.name == "Button_Settings")
            {
                settingsButton = button.gameObject;
                mainMenu = button.transform.parent;
            }
        }
        var _button = Instantiate(settingsButton);
        _button.name = "Button_CreativeMode";
        Destroy(_button.GetComponent("UiButtonTriggerUnityEvent"));
        var text = _button.transform.Find("Text (TMP)");
        text.GetComponent<TMPro.TextMeshProUGUI>().text = "Creative Mode";
        _button.gameObject.transform.SetParent(mainMenu.transform);
        _button.transform.localScale = new Vector3(1, 1, 1);
        _button.transform.SetSiblingIndex(2);
        var buttonAction = _button.GetComponent<BulwarkStudios.GameSystems.Ui.UiButton>();
        var action = new Action(StartGameInCreativeMode);
        buttonAction.OnTriggered += action;
    }

    #endregion Initializations
}