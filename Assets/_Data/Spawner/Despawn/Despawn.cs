using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : SpawnableObj
{
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected T parent;
    [SerializeField] protected bool isDespawnByTime = true;
    [SerializeField] protected float timeLife = 7f;
    [SerializeField] protected float currentTime = 7f;

    protected virtual void FixedUpdate() {

        this.DespawnChecking();

    }
    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadParent();
        this.LoadSpawner();
    }



    protected virtual void DespawnChecking() {

        if(!this.isDespawnByTime) return;

        this.currentTime -= Time.fixedDeltaTime;

        if (this.currentTime > 0) return;

        this.DoDespawn();

        this.currentTime = this.timeLife;
    }
    public override void DoDespawn() { 
        this.spawner.Despawn(parent);
    }
    protected virtual void LoadParent() {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
       
        /*Debug.Log(transform.name + ": LoadParent ", gameObject);*/

    }

    private void LoadSpawner() {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<Spawner<T>>();
        Debug.Log(transform.name + ": LoadSpawner ", gameObject);

    }
}
