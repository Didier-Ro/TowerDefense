using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen = default;
    [SerializeField] private GameObject _winScreen = default;

    public void ShowGameOverScreen()
    {
        if (GameManager.Instance.Winner)
        {
            _winScreen.SetActive(true);
        }
        else
        {
            _loseScreen.SetActive(true);
        }
    }

    public void SliderValueChange(float value)
    {
        GameManager.Instance.TimeSpeed = value;
    }
    public void RetryGame(string sceneName)
    {
        SceneLoader.LoadScene(sceneName);
    }
}
