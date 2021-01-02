using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1)]
public class PickUpData : ScriptableObject {
    public enum BodyPart {
        Head,
        Arm,
        Leg,
    }

    public BodyPart bodyPart;

    public PlayerController.HeadAbility headAbility;
    public PlayerController.ArmAbility armAbility;
    public PlayerController.LegAbility legAbility;
}
