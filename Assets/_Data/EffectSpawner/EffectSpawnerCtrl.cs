using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrl : SingletonCtrl<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner spawner;

    public EffectSpawner Spawner => spawner;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner() {
        if (this.spawner != null) return;
        this.spawner = transform.GetComponent<EffectSpawner>();
        Debug.Log(transform.name + ": LoadSpawner ", gameObject);
    }
}
