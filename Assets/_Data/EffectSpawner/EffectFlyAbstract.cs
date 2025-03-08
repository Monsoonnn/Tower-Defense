using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectFlyAbstract : EffectCtrl
{
    [SerializeField] protected MoveToTarget flyToTarget;

    public MoveToTarget FlyToTarget => flyToTarget;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadFlyToTarget();
    }

    protected virtual void LoadFlyToTarget() {
        if (this.flyToTarget != null) return;
        this.flyToTarget = GetComponentInChildren<MoveToTarget>();
        Debug.Log(transform.name + ": LoadFlyToTarget ", gameObject);
    }
}
