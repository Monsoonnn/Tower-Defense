using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
public class ItemProfileSO : ScriptableObject {

    public InvCodeName InvCodeName;
    public ItemCode itemCodeName;
    public string itemName;
    public bool isStackable = false;

}