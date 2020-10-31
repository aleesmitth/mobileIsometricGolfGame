using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCoinGrabText : MonoBehaviour {
    public GameObject prefab;
    public Transform parent;
    public int initialPoolSize;
    public static PoolCoinGrabText instance;
    private readonly Queue<GameObject> queue = new Queue<GameObject>();

    private void Awake() {
        this.MakeSingleton();
    }
    
    private void MakeSingleton() {
        if (instance == null) {
            instance = this;
        }
        else if(instance!=this)
            Destroy(gameObject);
    }

    public GameObject Get() {
        if (queue.Count == 0) {
            Grow();
        }
        GameObject depooledObject = queue.Dequeue();
        while(depooledObject == null) {
            if (queue.Count == 0) {
                Grow();
            }

            depooledObject = queue.Dequeue();
        }

        depooledObject.SetActive(true);
        depooledObject.transform.SetParent(parent, false);
        return depooledObject;
    }

    public void DestroyObject(GameObject pooledObject) {
        pooledObject.SetActive(false);
        queue.Enqueue(pooledObject);
    }

    private void Grow() {
        for (int i = queue.Count; i < initialPoolSize; i++) {
            GameObject pooledObject = Instantiate(prefab);
            pooledObject.SetActive(false);
            queue.Enqueue(pooledObject);
        }
    }
}