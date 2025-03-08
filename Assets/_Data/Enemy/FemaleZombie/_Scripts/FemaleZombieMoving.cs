using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleZombieMoving : EnemyMoving
{
    protected override void ResetValue() {
        base.ResetValue();
        this.pathIndex = 0;
    }
}
