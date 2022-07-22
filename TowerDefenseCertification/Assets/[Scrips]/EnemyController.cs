using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.EnemyCount++;
    }

    private void OnDisable()
    {
        GameManager.Instance.EnemyCount--;
    }
}
