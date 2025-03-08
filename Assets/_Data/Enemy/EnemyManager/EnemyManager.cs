using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : NewMonobehavior
{
    [SerializeField] protected EnemyPrefabs enemyPrefabs;
    [SerializeField] protected EnemySpawner spawner;
    
    public EnemyPrefabs EnemyPrefabs => this.enemyPrefabs;
    public EnemySpawner Spawner => this.spawner;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadEnemyPrefabs();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner() { 
        if( this.spawner != null ) return;
        this.spawner = transform.GetComponentInChildren<EnemySpawner>(); 
        Debug.Log(transform.name + ": LoadSpawner ", gameObject);
    }

    protected virtual void LoadEnemyPrefabs() { 
        if( this.enemyPrefabs != null ) return;
        this.enemyPrefabs = transform.GetComponentInChildren<EnemyPrefabs>(); 
        Debug.Log(transform.name + ": LoadEnemyPrefabs ", gameObject);
    }

}
