using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/CreateGameState")]
public class GameState : ScriptableObject
{
    public enum GameStateEnum
    {
        Playing,
        GameOver
    }

    public GameStateEnum CurrentGameState;

    [SerializeField] private int _enemyCount = default;

    public int EnemyCount
    {
        get => _enemyCount;
        set => _enemyCount = value;
    }
}
