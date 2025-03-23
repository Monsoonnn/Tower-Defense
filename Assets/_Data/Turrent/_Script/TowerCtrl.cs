using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TowerCtrl : NewMonobehavior
{
    [SerializeField] protected string bulletName = "Bullet";
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    [SerializeField] protected TowerTargeting towerTargeting;
    [SerializeField] protected BulletSpawner bulletSpawner;

    [SerializeField] protected Bullet bullet;

    [SerializeField] protected BulletPrefabs bulletPrefabs;

    [SerializeField] protected TowerShooting towerShooting;

    [SerializeField] protected LevelAbstact level;

    public LevelAbstact Level => level;

    public TowerShooting TowerShooting => towerShooting;    

    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    public TowerTargeting TowerTargeting => towerTargeting;

    public BulletSpawner BulletSpawner => bulletSpawner;

    public Transform Rotator => rotator;

    public Bullet Bullet => bullet;

    [SerializeField] protected List<FirePoint> firePoints;

    public List<FirePoint> FirePoints => firePoints;

    protected override void Awake() {
        base.Awake();
        this.HidePrefab();
    }


    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
        this.LoadFirePoints();
        this.LoadTowerShoting();
        this.LoadLevel();
    }

    protected virtual void LoadLevel() {    
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstact>();
        Debug.Log(transform.name + ": LoadLevel ", gameObject);
    }



    protected virtual void LoadTowerShoting() { 
        if (this.towerShooting != null) return;
        this.towerShooting = transform.GetComponentInChildren<TowerShooting>();
        Debug.Log(transform.name + ": LoadTowerShoting ", gameObject);
    }

    private void LoadBullet() {
        if (this.bullet != null) return;
        this.bullet = this.bulletPrefabs.GetByName(this.bulletName);
        Debug.Log(transform.name + ": LoadBullet ", gameObject);

    }

    private void LoadBulletPrefabs() { 
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": LoadBulletPrefabs ", gameObject);
        this.LoadBullet();
    }

    protected virtual void LoadModel() {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        this.model.localPosition = new Vector3(0f, 0f, 0f);
        Debug.Log(transform.name + ": LoadModel ", gameObject);

    }

    protected virtual void LoadTowerTargeting() {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        this.towerTargeting.transform.localPosition = new Vector3(0f, 1f, 0f);
        Debug.Log(transform.name + ": LoadTowerTargeting ", gameObject);

    }

    private void LoadBulletSpawner() {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = FindAnyObjectByType<BulletSpawner>();
        Debug.Log(transform.name + ": LoadBulletSpawner ", gameObject);
    }

    private void LoadFirePoints() {
        if (this.firePoints.Count > 0 ) return;

        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();

        this.firePoints = new List<FirePoint>(points);

    }

    protected virtual void HidePrefab() { 
        this.bullet.gameObject.SetActive(false);
    }


}
