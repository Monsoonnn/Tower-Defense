using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : NewMonobehavior
{
    protected override void ResetValue() {
        base.ResetValue();
        transform.localPosition = new Vector3(0.555f, -0.35f, -0.251f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
}
