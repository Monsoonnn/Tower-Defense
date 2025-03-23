using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class DamageSender : NewMonobehavior
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter( Collider other ) {
       
        DamageReceiver damageReceiver = other.gameObject.GetComponent<DamageReceiver>();


        if (damageReceiver == null) return;
        this.Send(damageReceiver, other);


    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    protected virtual void Send(DamageReceiver damageReceiver, Collider collider) {
        damageReceiver.Deduct(this.damage);
        
    }

    protected virtual void LoadRigidbody() {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
        Debug.Log(transform.name + ": LoadRigid ", gameObject);

    }
}
