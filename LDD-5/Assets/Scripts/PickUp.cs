using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable {
    private PlayerController player;

    private PlayerController.HeadAbility oldHeadAbility;
    private PlayerController.ArmAbility oldArmAbility;
    private PlayerController.LegAbility oldLegAbility;

    public PickUpData pickUpData;

    private PlayerController.HeadAbility pickUpHeadAbility;
    private PlayerController.ArmAbility pickUpArmAbility;
    private PlayerController.LegAbility pickUpLegAbility;

    public void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        pickUpHeadAbility = pickUpData.headAbility;
        pickUpArmAbility = pickUpData.armAbility;
        pickUpLegAbility = pickUpData.legAbility;

        this.gameObject.GetComponent<SpriteRenderer>().color = BodyPartColorManager();
    }

    public override void Interact() {
        switch (pickUpData.bodyPart) {
            default:
                break;
            case PickUpData.BodyPart.Head:
                oldHeadAbility = player.currentHeadAbility;
                this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.HeadAbilityColorPicker(oldHeadAbility);
                player.currentHeadAbility = pickUpHeadAbility;
                pickUpHeadAbility = oldHeadAbility;
                break;
            case PickUpData.BodyPart.Arm:
                oldArmAbility = player.currentArmAbility;
                this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.ArmAbilityColorPicker(oldArmAbility);
                player.currentArmAbility = pickUpArmAbility;
                pickUpArmAbility = oldArmAbility;
                break;
            case PickUpData.BodyPart.Leg:
                oldLegAbility = player.currentLegAbility;
                this.gameObject.GetComponent<SpriteRenderer>().color = ColorPicker.LegAbilityColorPicker(oldLegAbility);
                player.currentLegAbility = pickUpLegAbility;
                pickUpLegAbility = oldLegAbility;
                break;
        }
    }

    private Color BodyPartColorManager() {
        return pickUpData.bodyPart switch {
            PickUpData.BodyPart.Head => ColorPicker.HeadAbilityColorPicker(pickUpHeadAbility),
            PickUpData.BodyPart.Arm => ColorPicker.ArmAbilityColorPicker(pickUpArmAbility),
            PickUpData.BodyPart.Leg => ColorPicker.LegAbilityColorPicker(pickUpLegAbility)
        };
    }
}
