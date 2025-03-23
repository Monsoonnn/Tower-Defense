using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : NewMonobehavior
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;

    protected virtual void Update() {
        this.Cooldown();
        this.Attacking();
    }

    protected abstract void Attacking();
    protected abstract void Cooldown();

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
    }

    void LoadPlayerCtrl() { 

        if (playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl ", gameObject);

    }

    void LoadEffectSpawner() {
        if (effectSpawner != null) return;
        this.effectSpawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        this.effectPrefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadEffectSpawner ", gameObject);
    }

    public virtual AttackPoint GetAttackPoint() {
        return this.playerCtrl.WeaponsCtrl.GetCurrentWeapon().AttackPoint;
    }

    


}
