using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{

    [SerializeField] protected EnemyCtrl target;

    [SerializeField] float rotationSpeed = 2.0f;

    [SerializeField] protected Bullet bullet;

    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected float targetLoadSpeed = 1f;

    [SerializeField] protected int currentFirePoint = 0;

    protected override void Start() {
        base.Start();
        Invoke(nameof(this.TargetLoading), targetLoadSpeed);
        Invoke(nameof(this.Shooting), shootSpeed);
    }

    protected void FixedUpdate() {
        this.LookAtTarget();
        /*this.ShootAtTarget()*/
        /*this.TargetLoading();*/
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
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);

        newBullet.transform.forward = this.towerCtrl.Rotator.transform.right;

        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint() {

        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];

        this.currentFirePoint++;

        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) { 
            this.currentFirePoint = 0;
        }

        return firePoint;
    }

}
