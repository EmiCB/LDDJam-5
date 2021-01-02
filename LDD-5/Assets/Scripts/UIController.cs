using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private PlayerController player;

    public Image headAbilitySlot;
    public Image armAbilitySlot;
    public Image legAbilitySlot;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update() {
        headAbilitySlot.color = headAbilityColorPicker();
        armAbilitySlot.color = armAbilityColorPicker();
        legAbilitySlot.color = legAbilityColorPicker();
    }

    private Color headAbilityColorPicker() {
        return player.currentHeadAbility switch {
            PlayerController.HeadAbility.None => Color.gray,
            PlayerController.HeadAbility.MovementSpeedUp => Color.yellow
        };
    }

    private Color armAbilityColorPicker() {
        return player.currentArmAbility switch {
            PlayerController.ArmAbility.None => Color.gray,
            PlayerController.ArmAbility.WallCling => Color.yellow
        };
    }

    private Color legAbilityColorPicker() {
        return player.currentLegAbility switch {
            PlayerController.LegAbility.None => Color.gray,
            PlayerController.LegAbility.DoubleJump => Color.yellow
        };
    }
}
