
using UnityEngine;

public class CrosshairPointer : NewMonobehavior
{
    protected float maxDistance = 100f;
    protected Collider hitObj;
    [SerializeField] LayerMask layerMask = -1;

    protected virtual void Update() {
        this.Pointing();
    }

    protected virtual void Pointing() { 
        Vector3 screencenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screencenter);
        if (Physics.Raycast(ray, out RaycastHit hit, this.maxDistance, this.layerMask)) {
            this.transform.position = hit.point;
            this.hitObj = hit.collider;
           /* Debug.Log(hit.collider.name);*/
        }
    }

    
}
