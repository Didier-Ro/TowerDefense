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
    [SerializeField] private GameState _gameState = default;
    private int _wavesNumber = default;
    private ObjectPool _weakEnemyPool = default;

    private void Start()
    {
        _weakEnemyPool = new ObjectPool();
        _weakEnemyPool.ObjectPrefab = _weakEnemyPrefab;
        StartCoroutine(CreateNewEnemies());
    }

    IEnumerator CreateNewEnemies()
    {
        while(_wavesNumber < _wavesData.Waves.Length && _gameState.CurrentGameState == GameState.GameStateEnum.Playing)
        {
            yield return new WaitForSeconds(_waitTimeBetweenWaves);
            /*StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].WeakEnemies, _weakEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].MidEnemies, _midEnemyPrefab));
            StartCoroutine(SpawnEnemies(_wavesData.Waves[_wavesNumber].HeavyEnemies, _heavyEnemyPrefab));*/
            StartCoroutine(SpawnEnemiesFromPool(_wavesData.Waves[_wavesNumber].WeakEnemies, _weakEnemyPool));

            while (_gameState.EnemyCount > 0)
            {
                yield return null;
            }

            _wavesNumber++;
        }

        if (!GameManager.Instance.GameOver)
        {
            OnWavesEnd?.Invoke();
        }

    }

    IEnumerator SpawnEnemiesFromPool(int enemyAmount, ObjectPool objectPool)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject enemy = objectPool.GetGameObjectFromPool();
            enemy.transform.position = _spawnPoint.position;
            enemy.SetActive(true);
            yield return new WaitForSeconds(Random.Range(_minimumSpawnDelay, -_maximumSpawnDelay));
        }
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