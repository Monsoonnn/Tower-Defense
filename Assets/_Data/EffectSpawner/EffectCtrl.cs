using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCtrl : SpawnableObj
{
    [SerializeField] protected DespawnEffect despawnEffect;

    public DespawnEffect DespawnEffect => despawnEffect;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadDespawnEffect();
    }

    protected virtual void LoadDespawnEffect() {
        if (despawnEffect != null) return;
        this.despawnEffect = transform.GetComponentInChildren<DespawnEffect>();
        Debug.Log(transform.name + ": LoadDespawnEffect ", gameObject);
    }
}
