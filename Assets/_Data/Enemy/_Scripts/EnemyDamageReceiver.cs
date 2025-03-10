using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceivier : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected CapsuleCollider capsuleCollider;

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadCapsuleCollider() {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.radius = 0.2f;
        this.capsuleCollider.height = 1.5f;
        this.capsuleCollider.center = new Vector3(0f, 0.75f, 0f);
        this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCapsuleCollider ", gameObject);

    }

    protected virtual void LoadEnemyCtrl() {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl ", gameObject);
    }


    protected override void onDead() {
        base.onDead();
        this.enemyCtrl.Animator.SetBool("isDead", isDead);
        this.capsuleCollider.enabled = false;
        this.RewarOnDead();
        Invoke(nameof(this.Disappear), 4f);
    }

    protected override void onHit() {
        base.onHit();
        this.enemyCtrl.Animator.SetTrigger("isHit");
    }

    protected virtual void Disappear() {
        this.enemyCtrl.Despawn.DoDespawn();
    }

    protected override void OnReborn() {
        base.OnReborn();
        this.capsuleCollider.enabled = true;
    }

    protected virtual void RewarOnDead() {

        ItemIventory item = new ItemIventory();
       
        item.itemProfile = InventoryManager.Instance.GetProfileByName(ItemCode.Gold);
       
        item.itemCount = 1;

        InventoryManager.Instance.Monies().AddItem(item);
    }
}
