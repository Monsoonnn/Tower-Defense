using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : NewMonobehavior {
    [SerializeField] protected Bullet bullet;

    public Bullet Bullet => bullet;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadBullet();
    }


    private void LoadBullet() { 
        if (this.bullet != null) return;
        this.bullet = FindAnyObjectByType<Bullet>();
        Debug.Log(transform.name + ": LoadBullet ", gameObject);        
    } 

 
}
