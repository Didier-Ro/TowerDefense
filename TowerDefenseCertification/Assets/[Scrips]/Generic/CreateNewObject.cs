using UnityEngine;


public class CreateNewObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab = default;
    private Transform _spawnPoint = default;
    [SerializeField] private bool _usesSpawnPoint = default;
    [Range(0, 1)] [SerializeField] private float _chance = 1;

    public void NewObject()
    {
        if (Random.value < _chance)
        {
            if (_usesSpawnPoint)
            {
                Instantiate(_objectPrefab, _spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_objectPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
