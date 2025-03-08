using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAbstract : NewMonobehavior
{
   [SerializeField] protected TowerCtrl towerCtrl;


    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }


    protected virtual void LoadTowerCtrl() {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.parent.GetComponent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl ", gameObject);

    }



}
