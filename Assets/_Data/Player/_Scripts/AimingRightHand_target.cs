using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : NewMonobehavior
{
    protected override void ResetValue() {
        base.ResetValue();
        transform.localPosition = new Vector3(0.5440502f, 0.2240022f, 0.1210037f);
        transform.localRotation = Quaternion.Euler(23.893f, 7.145f, -3.897f);

    }

}
