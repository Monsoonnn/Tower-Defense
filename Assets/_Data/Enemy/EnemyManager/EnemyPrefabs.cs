using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabs : EnemyManagerAbstract
{
    [SerializeField] protected List<EnemyCtrl> enemyPrefabs = new();

    protected override void Awake() {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadEnemyPrefabs();
    }

    protected virtual void LoadEnemyPrefabs() { 

        if( this.enemyPrefabs.Count > 0 )  return;

        foreach (Transform child in transform) { 
            EnemyCtrl enemyCtrl = child.GetComponent<EnemyCtrl>();
            if( enemyCtrl != null ) { this.enemyPrefabs.Add(enemyCtrl); }

        }
        Debug.Log(transform.name + ": LoadEnemyPrefabs ", gameObject);  
    }

    protected virtual void HidePrefabs() { 
        foreach (EnemyCtrl enemyCtrl in this.enemyPrefabs) { 
            enemyCtrl.gameObject.SetActive(false);
        }
    }

    public virtual EnemyCtrl GetRandom() { 
        int rnd = Random.Range(0, this.enemyPrefabs.Count);
        return this.enemyPrefabs[rnd];

    }

}
