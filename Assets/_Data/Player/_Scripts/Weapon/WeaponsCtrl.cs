using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCtrl : NewMonobehavior
{
    [SerializeField] private List<WeaponAbstact> weapons = new List<WeaponAbstact>();

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadWeapons();
    }

    private void LoadWeapons() {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform) { 
            WeaponAbstact weaponAbstact = child.GetComponent<WeaponAbstact>();
            if (weaponAbstact == null) continue;
            this.weapons.Add(weaponAbstact);
        }
        Debug.Log(transform.name + ": LoadWeapons ", gameObject);
    }

    public virtual WeaponAbstact GetCurrentWeapon() {
        return weapons[0];
    }


}
