using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public GameObject ObjectPrefab = default;
    private Stack<GameObject> _objectsInPool = new Stack<GameObject>();

    public GameObject GetGameObjectFromPool()
    {
        if (_objectsInPool.Count > 0)
        {
            return _objectsInPool.Pop();
        }
        return CreateNewGameObject();
    }
    public GameObject CreateNewGameObject()
    {
        GameObject clone = GameObject.Instantiate(ObjectPrefab);
        clone.transform.name = ObjectPrefab.name;
        if (!clone.TryGetComponent(out ReturnGOToPool component))
        {
            component = clone.AddComponent<ReturnGOToPool>();
            component.ObjectPool = this;
        }
        return clone;
    }

    public void ReturnGameObjectToPool(GameObject go)
    {
        _objectsInPool.Push(go);
    }
}
