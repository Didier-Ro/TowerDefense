using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private WavesData _wavesData = default;
    [SerializeField] private Transform _spawnPoint = default;
    [SerializeField] private GameObject _weakEnemyPrefab = default;
    [SerializeField] private GameObject _midEnemyPrefab = default;
    [SerializeField] private GameObject _heavyEnemyPrefab = default;
    [SerializeField] private float _minimumSpawnDelay = 1;
    [SerializeField] private float _maximumSpawnDelay = 3;
    [SerializeField] private float _waitTimeBetweenWaves = 5;
    [SerializeField] private UnityEvent OnWavesEnd = default;
    private int _wavesNumber = default;

    private void Start()
    {
        StartCoroutine(CreateNewEnemies());
    }

    IEnumerator CreateNewEnemies()
    {
        while(_wavesNumber < _wavesData.Waves.Length && GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            yield return new WaitForSeconds(_waitTimeBetweenWaves);
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].WeakEnemies, _weakEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].MidEnemies, _midEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].HeavyEnemies, _heavyEnemyPrefab));

            while (GameManager.Instance.EnemyCount > 0)
            {
                yield return null;
            }

            _wavesNumber++;
        }

        OnWavesEnd?.Invoke();
    }

    IEnumerator SpawnEnemies(int enemyAmount, GameObject enemyPrefab)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_minimumSpawnDelay, _maximumSpawnDelay));
        }
    }
}