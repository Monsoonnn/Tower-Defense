using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class GrenadesDamageSender : DamageSender {

    [SerializeField] protected EffectCtrl effectCtrl;
    [SerializeField] protected SphereCollider sphereCollider;


    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadExplosionCtrl();
    }

    protected virtual void LoadSphereCollider() {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider ", gameObject);

    }

    protected virtual void LoadExplosionCtrl() {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.GetComponentInParent<ExplosionCtrl>();
        Debug.Log(transform.name + ": LoadExplosionCtrl ", gameObject);
    }

    protected override void Send( DamageReceiver damageReceiver ) {
        base.Send(damageReceiver);
        StartCoroutine(PlayEffectThenDespawn());

    }
   
    private IEnumerator PlayEffectThenDespawn() {
        effectCtrl.DespawnEffect.PlayParticleSystem();

        
        float effectDuration = effectCtrl.DespawnEffect.ParticleEffect.main.duration;

        yield return new WaitForSeconds(effectDuration);

        
        effectCtrl.Despawn.DoDespawn();
    }
}
