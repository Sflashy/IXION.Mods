using Stanford.Settings;
using Stanford.Settings.General;
using System;
using System.Collections.Generic;
using System.Text;
using UnhollowerBaseLib;

namespace IXION.PauseGameOption;

public class PauseGameOption : GameSettingState<PauseGameOption, bool, GameBoolSettingData>
{
    public override void OnApplyValue()
    {
    }

    public PauseGameOption() : base()
    {
    }
}