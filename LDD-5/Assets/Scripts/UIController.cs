using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private PlayerController player;
    private SpritePicker spritePicker;

    public Image headAbilitySlot;
    public Image armAbilitySlot;
    public Image legAbilitySlot;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spritePicker = GameObject.FindObjectOfType<SpritePicker>();
    }

    void Update() {
        /*
        headAbilitySlot.color = ColorPicker.HeadAbilityColorPicker(player.currentHeadAbility);
        armAbilitySlot.color = ColorPicker.ArmAbilityColorPicker(player.currentArmAbility);
        legAbilitySlot.color = ColorPicker.LegAbilityColorPicker(player.currentLegAbility);
        */

        headAbilitySlot.sprite = spritePicker.HeadAbilitySpritePicker(player.currentHeadAbility);
        armAbilitySlot.sprite = spritePicker.ArmAbilitySpritePicker(player.currentArmAbility);
        legAbilitySlot.sprite = spritePicker.LegAbilitySpritePicker(player.currentLegAbility);
    }

    
}
