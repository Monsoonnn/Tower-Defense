using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : SpawnableObj {
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Transform model;
    [SerializeField] protected Animator animator;
    [SerializeField] protected TowerTargetable towerTargetable;
    [SerializeField] protected DamageReceiver damageReceiver;
    public NavMeshAgent Agent => agent;
    public Animator Animator => animator;

    public TowerTargetable TowerTargetable => towerTargetable;

    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadAnimatior();
        this.LoadTowerTargetable();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadModel() {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0f, 0f, 0f);
        Debug.Log(transform.name + ": LoadModel ", gameObject);

    }

    protected virtual void LoadNavMeshAgent() {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 0.8f; //0.8
        this.agent.angularSpeed = 200f;
        this.agent.acceleration = 150f;
        Debug.Log(transform.name + ": LoadNavMesAgent ", gameObject);

    }
    protected virtual void LoadAnimatior() {
        if (this.animator != null) return;
        this.animator = this.model.GetComponent<Animator>();

        Debug.Log(transform.name + ": LoadAnimatior ", gameObject);
    }

    protected virtual void LoadTowerTargetable() {
        if (this.towerTargetable != null) return;
        this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();
        this.TowerTargetable.transform.localPosition = new Vector3(0f, 1f, 0f);
        Debug.Log(transform.name + ": LoadTowerTargetable ", gameObject);
    }

    protected virtual void LoadDamageReceiver() { 
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver ", gameObject);
    }

}
