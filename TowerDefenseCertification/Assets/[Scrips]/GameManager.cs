using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private float _timeSpeed = 1;
    [SerializeField] private UnityEvent OnGameOver = default;
    [SerializeField] private GameState _gameState = default;
    private bool _gameOver = default;
    private bool _winner = default;
    
    

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
            _gameState.CurrentGameState = GameState.GameStateEnum.GameOver;
            OnGameOver?.Invoke();
        }
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

    private void OnDisable()
    {
        _gameState.CurrentGameState = GameState.GameStateEnum.Playing;
    }
}