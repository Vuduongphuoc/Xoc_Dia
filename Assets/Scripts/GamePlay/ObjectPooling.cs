using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public static SpriteRenderer objSprite;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public List<GameObject> poolBotObjects = new List<GameObject>();

    private int amountBotPool = 150;
    private int amountToPool = 50;

    public GameObject coinPrefabs;
    public GameObject[] botcoinPrefabs;
    public Transform[] botcoinPos;
    //public static SpriteRenderer coinPrefabsSprite;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < amountToPool; i++)
        { 
            GameObject obj = Instantiate(coinPrefabs);
            obj.SetActive(false);
            pooledObjects.Add(obj); 
        }
        for(int i = 0; i <= amountBotPool;i++)
        {
            for(int y = 0; y < botcoinPrefabs.Length && y < botcoinPos.Length; y++)
            {
                GameObject objs = Instantiate(botcoinPrefabs[y], botcoinPos[y].position,Quaternion.identity);
                objs.SetActive(false);
                poolBotObjects.Add(objs);
            }
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i =0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    public GameObject GetBotPooledObject()
    {
        for (int i = 0; i < poolBotObjects.Count; i++)
        {
            if (!poolBotObjects[i].activeInHierarchy)
            {
                return poolBotObjects[i];
            }
        }
        return null;
    }
}
