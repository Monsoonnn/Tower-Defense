using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : NewMonobehavior
{
    protected override void ResetValue() {
        base.ResetValue();
        transform.localPosition = new Vector3(0.496f, -0.159f, 0.274f);
        transform.localRotation = Quaternion.Euler(136.269f, 147.008f, 83.038f);

    }

}
