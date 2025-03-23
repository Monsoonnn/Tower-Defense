using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPicker : NewMonobehavior {
   
    [SerializeField] protected SphereCollider sphereCollider;

    private void OnTriggerEnter( Collider collider ) {

        if(collider.transform.parent == null) return;

        ItemDropCtrl itemDropCtrl = collider.transform.parent.GetComponent<ItemDropCtrl>();
        if(itemDropCtrl == null) return;
        itemDropCtrl.Despawn.DoDespawn();
        Debug.Log("ItemPick: " + itemDropCtrl.ItemCode);
    }

    private void OnTriggerExit( Collider collider ) {
        
    }

    protected override void LoadComponents() {
        base.LoadComponents();
      
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider() {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider ", gameObject);

    }


}


