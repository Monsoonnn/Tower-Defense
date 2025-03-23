using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemIventory 
{
    public int itemID;
    public string itemName;
    public ItemProfileSO itemProfile;
    public int itemCount;

    /*public ItemIventory() { 
        this.itemID = UnityEngine.Random.Range(0, 999999);
    }*/

    public virtual bool Deduct( int number ) { 
        if(this.itemCount < number) return false;
        this.itemCount -= number;
        return true;
    }



}
