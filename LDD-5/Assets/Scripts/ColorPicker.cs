using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker {
    public static Color HeadAbilityColorPicker(PlayerController.HeadAbility headAbility) {
        return headAbility switch {
            PlayerController.HeadAbility.None => Color.gray,
            PlayerController.HeadAbility.MovementSpeedUp => Color.yellow
        };
    }

    public static Color ArmAbilityColorPicker(PlayerController.ArmAbility armAbility) {
        return armAbility switch {
            PlayerController.ArmAbility.None => Color.gray,
            PlayerController.ArmAbility.WallCling => Color.red
        };
    }

    public static Color LegAbilityColorPicker(PlayerController.LegAbility legAbility) {
        return legAbility switch {
            PlayerController.LegAbility.None => Color.gray,
            PlayerController.LegAbility.DoubleJump => Color.green,
            PlayerController.LegAbility.FastDrop => Color.cyan
        };
    }
}
