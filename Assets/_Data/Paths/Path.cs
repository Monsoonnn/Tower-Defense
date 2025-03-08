using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path : NewMonobehavior {
    [SerializeField] public List<Point> points = new();


    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints() {
        if (this.points.Count > 0) return;

        foreach (Transform child in transform) {

            Point point = child.GetComponent<Point>();
            point.LoadNextPoint();
            points.Add(point);

        }

        Debug.Log(transform.name + ": LoadPoints ", gameObject);
    }

    public virtual Point GetPoint( int index ) {
        return points[index];
    }


}
