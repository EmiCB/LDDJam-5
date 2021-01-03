using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePicker : MonoBehaviour {
    public List<Sprite> sprites = new List<Sprite>();

    public Sprite HeadAbilitySpritePicker(PlayerController.HeadAbility headAbility) {
        return headAbility switch {
            PlayerController.HeadAbility.None => sprites[0],
            PlayerController.HeadAbility.MovementSpeedUp => sprites[1]
        };
    }

    public Sprite ArmAbilitySpritePicker(PlayerController.ArmAbility armAbility) {
        return armAbility switch {
            PlayerController.ArmAbility.None => sprites[0],
            PlayerController.ArmAbility.WallCling => sprites[4]
        };
    }

    public Sprite LegAbilitySpritePicker(PlayerController.LegAbility legAbility) {
        return legAbility switch {
            PlayerController.LegAbility.None => sprites[0],
            PlayerController.LegAbility.DoubleJump => sprites[2],
            PlayerController.LegAbility.FastDrop => sprites[3]
        };
    }
}
