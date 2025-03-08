using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEffect : NewMonobehavior
{
    [SerializeField] protected ParticleSystem particleEffect;
    public ParticleSystem ParticleEffect => particleEffect;

    protected override void LoadComponents() {
       base.LoadComponents();
       this.LoadParticleSystem();
    }

    protected virtual void LoadParticleSystem() {
        if (this.particleEffect != null) return;
        this.particleEffect = GetComponent<ParticleSystem>();
        Debug.Log(transform.name + ": LoadParticleSystem ", gameObject);
    }

   
    public void PlayParticleSystem() {
        particleEffect.Play();
    }

}
