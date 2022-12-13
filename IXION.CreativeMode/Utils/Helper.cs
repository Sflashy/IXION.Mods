using BulwarkStudios.Stanford.Core.GameStates;
using BulwarkStudios.Stanford.Menu;
using BulwarkStudios.Stanford.Menu.UI;
using UnityEngine;

namespace IXION.CreativeMode;

public static class Helper
{
    public enum GameplayDataIndex
    {
        NewGame,
        Chapter0SkipIntro,
        Chapter0EndPrologue,
        Chapter1,
        Chapter1Completed,
        Chapter0AllDlsEvents,
        Chapter1AllDlsEvents,
        Chapter2AllDlsEvents,
        StressTest4Sector6kCitizen,
        BalancingLateGame,
        BalancingMidGame,
        Chapter2,
        Chapter3,
        Chapter3AllDlsEvents,
        Chapter4,
        Chapter4AllDlsEvents,
        Chapter5,
        Chapter5AllDlsEvents,
        Chapter5EndingAhstangite,
        Chapter5EndingCrewMembers,
        Tutorials
    }

    public static GameplayData GetGameplayData(GameplayDataIndex dataIndex)
    {
        var mainmenu = Object.FindObjectOfType<MainMenu>();
        var uiwindow = mainmenu.windowManagerMiddle.GetWindow<UIWindowNewGame>();
        return uiwindow.allGameplayData.list[(int)dataIndex];
    }
}