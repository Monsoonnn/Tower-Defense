using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableObj : NewMonobehavior
{

    [SerializeField] protected DespawnBase despawn;
    
    public DespawnBase Despawn => despawn;
   

    public abstract string GetName();

   protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn() {
        if (despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + ": LoadDespawn ", gameObject);

    }


}
