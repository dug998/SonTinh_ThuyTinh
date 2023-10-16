using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string _name;
    public GameObject _obj;
    public int _count;
    public int _scale;
    public List<GameObject> actives = new List<GameObject>();
    public Queue<GameObject> deactives = new Queue<GameObject>();

    public void InitPool(Transform container, Dictionary<int, int> dicClones)
    {
        for (int i = 0; i < _count; i++)
        {
            SpawnClone(container, dicClones);
        }
    }
    void SpawnClone(Transform container, Dictionary<int, int> dicClones)
    {
        GameObject clone = Object.Instantiate(_obj, container);
        clone.transform.localScale = Vector3.one * _scale;
        clone.gameObject.SetActive(false);
        deactives.Enqueue(clone);
        dicClones.Add(clone.GetHashCode(), GetHashCode());

    }
    public void Return(GameObject go)
    {
        go.SetActive(false);
        actives.Remove(go);
        deactives.Enqueue(go);
    }
    public void OnDestroy()
    {

    }
}
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public Dictionary<int, int> dicClones = new Dictionary<int, int>();
    private List<Pool> pools = new List<Pool>();

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        
        foreach(Pool pool in pools)
        {
            pool.InitPool(transform, dicClones);
        }
    }
}
