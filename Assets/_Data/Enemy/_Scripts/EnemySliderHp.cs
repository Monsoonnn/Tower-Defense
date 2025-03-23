using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySliderHp : SliderHp
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl() {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl> ();
        Debug.Log(transform.name + ": LoadEnemyCtrl()");
    }

    protected override float GetValue() {
       return (float) this.enemyCtrl.DamageReceiver.currentHP / (float) this.enemyCtrl.DamageReceiver.maxHP;
    }


}
