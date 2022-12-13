using BulwarkStudios.Stanford.Menu.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace IXION.PauseGameOption;

public class Main : MonoBehaviour
{
    private bool bInitialized;
    private BulwarkStudios.Stanford.Menu.UI.UIWindowSettings _UIWindowSettings;

    public Main(IntPtr handle) : base(handle)
    {
    }

    private void Update()
    {
        if (bInitialized) return;
        _UIWindowSettings = FindObjectOfType<BulwarkStudios.Stanford.Menu.UI.UIWindowSettings>();
        if (_UIWindowSettings == null) return;
        InitializeOption();
    }

    private void InitializeOption()
    {
    }
}