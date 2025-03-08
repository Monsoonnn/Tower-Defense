using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainZombieMoving : EnemyMoving
{
    protected override void ResetValue() {
        base.ResetValue();
        this.pathIndex = 0;
    }
}
