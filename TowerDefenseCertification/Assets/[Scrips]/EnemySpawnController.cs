using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private WavesData _wavesData = default;
    [SerializeField] private Transform _spawnPoint = default;
    [SerializeField] private GameObject _weakEnemyPrefab = default;
    [SerializeField] private GameObject _midEnemyPrefab = default;
    [SerializeField] private GameObject _heavyEnemyPrefab = default;
    private int _wavesNumber = default;

    private void Start()
    {
        StartCoroutine(CreateNewEnemies());
    }

    IEnumerator CreateNewEnemies()
    {
        while(_wavesNumber < _wavesData.Waves.Length)
        {
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].WeakEnemies, _weakEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].MidEnemies, _midEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].HeavyEnemies, _heavyEnemyPrefab));
            yield return new WaitForSeconds(5);
            _wavesNumber++;
        }
    }

    IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }
}
