using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Spawner<T> : NewMonobehavior where T : SpawnableObj {

    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObj;
    [SerializeField] protected PoolHolder poolHolder;

    //Object Pooling
    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadPoolHolder();
    }

    protected virtual void LoadPoolHolder() {
        if (this.poolHolder != null) return;
        this.poolHolder = transform.GetComponentInChildren<PoolHolder>();
        Debug.Log(transform.name + ": LoadPoolHolder ", gameObject);

    }

    public virtual T Spawn( T prefab ) {

        T newObj = this.GetObjFromPool(prefab);

        if (newObj == null) {

            newObj = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObj.transform);
        }

        if(this.poolHolder != null) newObj.transform.parent = this.poolHolder.transform;

         return newObj;
    }

    public virtual T Spawn( T prefab, Vector3 positon ) {

        T newBullet = this.Spawn(prefab);
        newBullet.transform.position = positon;
        return newBullet;
    }

    protected virtual T GetObjFromPool(T prefab) {

        foreach( T inPoolObj in this.inPoolObj) {
            if (inPoolObj.GetName() == prefab.GetName()) {
                this.RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
        
    }


    public virtual void Despawn( Transform obj ) {
        Destroy(obj.gameObject);

    }

    public virtual void Despawn( T obj ) {
        
        if(obj is MonoBehaviour monoBehaviour){ 
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
       /* prefab.gameObject.SetActive(false);*/
    }

    protected virtual void AddObjectToPool( T obj ) { 
        this.inPoolObj.Add(obj);
    }

    protected virtual void RemoveObjFromPool( T obj ) {
        this.inPoolObj.Remove(obj);
    }

    protected void UpdateName( Transform prefab, Transform newObject ) {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }

}
