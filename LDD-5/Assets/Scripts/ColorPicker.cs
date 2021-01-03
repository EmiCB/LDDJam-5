using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker {
    public static Color HeadAbilityColorPicker(PlayerController.HeadAbility headAbility) {
        return headAbility switch {
            PlayerController.HeadAbility.None => new Color(155.0f / 255.0f, 173.0f / 255.0f, 183.0f / 255.0f, 1.0f),
            PlayerController.HeadAbility.MovementSpeedUp => new Color(95.0f / 255.0f, 205.0f / 255.0f, 228.0f / 255.0f, 1.0f),
        };
    }

    public static Color ArmAbilityColorPicker(PlayerController.ArmAbility armAbility) {
        return armAbility switch {
            PlayerController.ArmAbility.None => new Color(155.0f / 255.0f, 173.0f / 255.0f, 183.0f / 255.0f, 1.0f),
            PlayerController.ArmAbility.WallCling => new Color(143.0f / 255.0f, 86.0f / 255.0f, 59.0f / 255.0f, 1.0f),
        };
    }

    public static Color LegAbilityColorPicker(PlayerController.LegAbility legAbility) {
        return legAbility switch {
            PlayerController.LegAbility.None => new Color(155.0f / 255.0f, 173.0f / 255.0f, 183.0f / 255.0f, 1.0f),
            PlayerController.LegAbility.DoubleJump => new Color(153.0f / 255.0f, 229.0f / 255.0f, 80.0f / 255.0f, 1.0f),
            PlayerController.LegAbility.FastDrop => new Color(217.0f / 255.0f, 87.0f / 255.0f, 99.0f / 255.0f, 1.0f),
        };
    }
}
