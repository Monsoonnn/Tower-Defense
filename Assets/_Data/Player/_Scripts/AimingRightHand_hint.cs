using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : NewMonobehavior
{
    protected override void ResetValue() {
        base.ResetValue();
        transform.localPosition = new Vector3(0.512f, 0.007f, -0.188f);
        transform.localRotation = Quaternion.Euler(-0.934f, -3.467f, 0.851f);

    }
}
