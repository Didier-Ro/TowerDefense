using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameState _gameState = default;
    private void OnEnable()
    {
        _gameState.EnemyCount++;
    }

    private void OnDisable()
    {
        _gameState.EnemyCount--;
    }
}
