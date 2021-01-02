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
        headAbilitySlot.color = ColorPicker.HeadAbilityColorPicker(player.currentHeadAbility);
        armAbilitySlot.color = ColorPicker.ArmAbilityColorPicker(player.currentArmAbility);
        legAbilitySlot.color = ColorPicker.LegAbilityColorPicker(player.currentLegAbility);
    }

    
}
