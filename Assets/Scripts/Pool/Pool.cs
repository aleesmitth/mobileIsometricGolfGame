using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    public GameObject prefab;
    public int initialPoolSize;
    private readonly Queue<GameObject> queue = new Queue<GameObject>();

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