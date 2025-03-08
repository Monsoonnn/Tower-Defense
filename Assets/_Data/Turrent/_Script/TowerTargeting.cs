using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : NewMonobehavior {
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EnemyCtrl nearestEnemy;
    [SerializeField] protected LayerMask obstacleLayerMask;
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    
    public EnemyCtrl NearestEnemy => nearestEnemy;


    private void FixedUpdate() {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }


    private void OnTriggerEnter( Collider collider ) {

        this.AddEnemy(collider);

    }

    private void OnTriggerExit( Collider collider ) {
        this.RemoveEnemy(collider);
    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadRigid();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider() {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider ", gameObject);

    }

    protected virtual void LoadRigid() {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
        Debug.Log(transform.name + ": LoadRigid ", gameObject);

    }


    protected void AddEnemy( Collider collider ) {

        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();
        if (enemyCtrl.DamageReceiver.IsDead()) return;
        this.enemies.Add(enemyCtrl);
        /* Debug.Log("Add Enemy: " + collider.name);*/

    }

    protected void RemoveEnemy( Collider collider ) {

        foreach (EnemyCtrl enemyCtrl in this.enemies) {
            if (collider.transform.parent == enemyCtrl.transform) {
                if (enemyCtrl == this.nearestEnemy) this.nearestEnemy = null;

                this.enemies.Remove(enemyCtrl);
                return;
            }
        }

    }

    protected virtual void FindNearest() {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;

        foreach (EnemyCtrl enemyCtrl in this.enemies) {

            if (!this.CanSeeTarget(enemyCtrl)) continue;

            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance) {
                nearestDistance = enemyDistance;
                this.nearestEnemy = enemyCtrl;
            }
        }

    }

    protected virtual bool CanSeeTarget(EnemyCtrl target) {
        //Raycast to target

        Vector3 directionToTarget = target.transform.position - transform.position;

        float distanceToTarget = directionToTarget.magnitude;

        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask)) {

            Vector3 directionToCollider= hitInfo.point - transform.position;
            float distanceToCollider = directionToCollider.magnitude;

            Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollider, Color.red);

            return false;
        }

        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);

        return true;
    }

    protected virtual void RemoveDeadEnemy() {
        foreach (EnemyCtrl enemyCtrl in this.enemies) {
            if (enemyCtrl.DamageReceiver.IsDead()) { 
                if(enemyCtrl == this.nearestEnemy) this.nearestEnemy = null;
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }

}


