using Unity.Mathematics;
using UnityEngine;

public class CreateNewObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab = default;

    public void NewObject()
    {
        Instantiate(_objectPrefab, transform.position, quaternion.identity);
    }
}
