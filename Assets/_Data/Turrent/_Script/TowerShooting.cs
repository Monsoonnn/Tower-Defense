using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{

    [SerializeField] protected EnemyCtrl target;

    [SerializeField] float rotationSpeed = 2.0f;

    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected float targetLoadSpeed = 0.5f;

    [SerializeField] protected int currentFirePoint = 0;

    [SerializeField] protected int killCount = 0;

    [SerializeField] protected EffectSpawner effectSpawner;

    public int killTotal = 0;
    public int KillCount => this.killCount;

    protected override void Start() {
        base.Start();
        Invoke(nameof(this.TargetLoading), targetLoadSpeed);
        Invoke(nameof(this.Shooting), shootSpeed);
    }

    protected void FixedUpdate() {
        this.LookAtTarget();
        this.IsTargetDead();
        /*this.ShootAtTarget()*/
        /*this.TargetLoading();*/
    }
    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadEffectSpawnerCtrl();
    }

    protected virtual void LoadEffectSpawnerCtrl() { 
        if (this.effectSpawner != null) return;
        this.effectSpawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        Debug.Log(transform.name + ": LoadEffectSpawnerCtrl ", gameObject);
    }

    protected virtual void LookAtTarget() {
        if (this.target == null) return;

        Vector3 direction = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;

        Vector3 newDirection = Vector3.RotateTowards(
                this.towerCtrl.Rotator.forward,
                direction,
                rotationSpeed * Time.fixedDeltaTime,
                0.0f
            );

        // Xoay tháp pháo, giữ nguyên -90 độ để trục X hướng về mục tiêu
        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -90, 0);
    }

    protected virtual void TargetLoading() {

        Invoke(nameof(this.TargetLoading), targetLoadSpeed);

        this.target = this.towerCtrl.TowerTargeting.NearestEnemy;

    }

    protected virtual void Shooting() {
        Invoke(nameof(this.Shooting), shootSpeed);

        if (target == null) return;

        FirePoint firePoint = this.GetFirePoint();
 
        Vector3 rotation = this.towerCtrl.Rotator.transform.right;

        this.SpawnBullet(firePoint.transform.position, rotation);
        this.SpawnMuzzle(firePoint.transform.position, rotation);

    }

    protected virtual void SpawnBullet( Vector3 spawnPoint, Vector3 rotation ) {

        EffectCtrl effect = this.effectSpawner.PoolPrefabs.GetByName("ProjectTile1");
        EffectCtrl newEffect = this.effectSpawner.Spawn(effect, spawnPoint);
        newEffect.transform.forward = rotation;

        EffectFlyAbstract effectFly = (EffectFlyAbstract)newEffect;
        effectFly.FlyToTarget.SetTarget(this.target.TowerTargetable.transform);
            
        newEffect.gameObject.SetActive(true);
    }

    /*protected virtual void SpawnBullet(Vector3 spawnPoint, Vector3 rotation) {

        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, spawnPoint);

        newBullet.transform.forward = rotation;

        newBullet.gameObject.SetActive(true);
    }*/

    protected virtual void SpawnMuzzle( Vector3 spawnPoint, Vector3 rotation ) {

        EffectCtrl effect = this.effectSpawner.PoolPrefabs.GetByName("TurretShot1");
        EffectCtrl newEffect = this.effectSpawner.Spawn(effect, spawnPoint);

        newEffect.transform.forward = rotation;

        newEffect.gameObject.SetActive(true);



    }


    protected virtual FirePoint GetFirePoint() {

        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];

        this.currentFirePoint++;

        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) { 
            this.currentFirePoint = 0;
        }

        return firePoint;
    }

    protected virtual bool IsTargetDead() { 
       if(this.target == null) return true;
       if(!this.target.DamageReceiver.IsDead()) return false;
       this.killCount++;
       this.killTotal++;
       this.target = null;
       return true;
    }

    public virtual bool DeductKillCount(int count) { 
        if(this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }

}
