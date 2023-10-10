using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool OPinstance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 5;

    [SerializeField] private GameObject bulletPrefab;

    private void Awake(){
        if (OPinstance == null) {
            OPinstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj); //add object to pool
        }
    }

    public GameObject GetPooledObject(){
        for (int i = 0; i < pooledObjects.Count; i++) {
            if(!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
