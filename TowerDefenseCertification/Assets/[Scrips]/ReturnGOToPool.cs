using UnityEngine;

public class ReturnGOToPool : MonoBehaviour
{
    public ObjectPool ObjectPool;

    public void OnDisable()
    {
        ObjectPool.ReturnGameObjectToPool(gameObject);
    }
}
