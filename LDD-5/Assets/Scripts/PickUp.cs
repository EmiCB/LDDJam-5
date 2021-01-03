using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {
    private PlayerController player;
    private SpritePicker spritePicker;
    private Timer timer;

    private PlayerController.HeadAbility oldHeadAbility;
    private PlayerController.ArmAbility oldArmAbility;
    private PlayerController.LegAbility oldLegAbility;

    public PickUpData pickUpData;

    private PlayerController.HeadAbility pickUpHeadAbility;
    private PlayerController.ArmAbility pickUpArmAbility;
    private PlayerController.LegAbility pickUpLegAbility;

    public float timeReduction = 3.0f;

    public void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spritePicker = GameObject.FindObjectOfType<SpritePicker>();
        timer = GameObject.FindObjectOfType<Timer>();

        pickUpHeadAbility = pickUpData.headAbility;
        pickUpArmAbility = pickUpData.armAbility;
        pickUpLegAbility = pickUpData.legAbility;

        //this.gameObject.GetComponent<SpriteRenderer>().color = BodyPartColorManager();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = BodyPartSpriteManager();
    }

    public override void Interact() {
        switch (pickUpData.bodyPart) {
            default:
                break;
            case PickUpData.BodyPart.Head:
                oldHeadAbility = player.currentHeadAbility;
                //this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.HeadAbilityColorPicker(oldHeadAbility);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spritePicker.HeadAbilitySpritePicker(oldHeadAbility);
                player.currentHeadAbility = pickUpHeadAbility;
                pickUpHeadAbility = oldHeadAbility;
                break;
            case PickUpData.BodyPart.Arm:
                oldArmAbility = player.currentArmAbility;
                //this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.ArmAbilityColorPicker(oldArmAbility);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spritePicker.ArmAbilitySpritePicker(oldArmAbility);
                player.currentArmAbility = pickUpArmAbility;
                pickUpArmAbility = oldArmAbility;
                break;
            case PickUpData.BodyPart.Leg:
                oldLegAbility = player.currentLegAbility;
                //this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.LegAbilityColorPicker(oldLegAbility);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spritePicker.LegAbilitySpritePicker(oldLegAbility);
                player.currentLegAbility = pickUpLegAbility;
                pickUpLegAbility = oldLegAbility;
                break;
        }

        timer.timeRemaining -= timeReduction;
    }

    /*
    private Color BodyPartColorManager() {
        return pickUpData.bodyPart switch {
            PickUpData.BodyPart.Head => ColorPicker.HeadAbilityColorPicker(pickUpHeadAbility),
            PickUpData.BodyPart.Arm => ColorPicker.ArmAbilityColorPicker(pickUpArmAbility),
            PickUpData.BodyPart.Leg => ColorPicker.LegAbilityColorPicker(pickUpLegAbility)
        };
    }
    */

    private Sprite BodyPartSpriteManager() {
        return pickUpData.bodyPart switch {
            PickUpData.BodyPart.Head => spritePicker.HeadAbilitySpritePicker(pickUpHeadAbility),
            PickUpData.BodyPart.Arm => spritePicker.ArmAbilitySpritePicker(pickUpArmAbility),
            PickUpData.BodyPart.Leg => spritePicker.LegAbilitySpritePicker(pickUpLegAbility)
        };
    }
}
