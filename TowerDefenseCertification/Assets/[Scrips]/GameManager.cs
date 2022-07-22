using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int _enemyCount = default;
    [SerializeField] private float _timeSpeed = 1;
    [SerializeField] private UnityEvent OnGameOver = default;
    private bool _gameOver = default;
    private bool _winner = default;
    
    public enum GameState
    {
        Playing,
        GameOver
    }

    private GameState _currentGameState;

    public GameState CurrentGameState
    {
        get => _currentGameState;
        set => _currentGameState = value;
    }

    public bool Winner
    {
        get => _winner;
        set => _winner = value;
    }

    public bool GameOver
    {
        get => _gameOver;
        set
        {
            _gameOver = value;
            CurrentGameState = GameState.GameOver;
            OnGameOver?.Invoke();
        }
    }
    public int EnemyCount
    {
        get => _enemyCount;
        set => _enemyCount = value;
    }

    public float TimeSpeed
    {
        get => _timeSpeed;
        set => _timeSpeed = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Time.timeScale = _timeSpeed;
    }
}