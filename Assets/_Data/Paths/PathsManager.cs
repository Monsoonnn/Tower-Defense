using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : SingletonCtrl<PathsManager> {
    [SerializeField] protected List<Path> paths = new();

    protected override void Awake() {
        base.Awake();
    }

    protected override void LoadComponents() {
        base.LoadComponents();
        this.LoadPaths();
    }
    
    protected virtual void LoadPaths() {
        if (this.paths.Count > 0) return;

        foreach (Transform child in transform) {

            Path path = child.GetComponent<Path>();
            path.LoadPoints();
            paths.Add(path);

        }

        Debug.Log(transform.name + ": LoadPaths ", gameObject);
    }

    public virtual Path GetPath(int index) {         
        return paths[index];
    }
}
