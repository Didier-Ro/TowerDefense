using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen = default;
    [SerializeField] private GameObject _winScreen = default;
    [SerializeField] private Button[] _weaponButtons = default;
    [SerializeField] private TMP_Text _goldAmountText = default;
    [SerializeField] private ResourceData _resourceData = default;

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

    public void CheckIfEnoughGoldForWeapon(int _currentGoldAmount)
    {
        for (int i = 0; i < 3; i++)
        {
            _weaponButtons[i].interactable = false;
        }
        
        if (_currentGoldAmount >= _resourceData.WeaponsCosts[2].WeaponCost)
        {
            for (int i = 0; i < 3; i++)
            {
                _weaponButtons[i].interactable = true;
            }
        }
        else if (_currentGoldAmount >= _resourceData.WeaponsCosts[1].WeaponCost)
        {
            for (int i = 0; i < 2; i++)
            {
                _weaponButtons[i].interactable = true;
            }
        }
        else if (_currentGoldAmount >= _resourceData.WeaponsCosts[0].WeaponCost)
        {
            _weaponButtons[0].interactable = true;
        }
    }

    public void UpdateGoldAmountUI(int currentGoldAmount)
    {
        _goldAmountText.text = $"Gold: {currentGoldAmount}";
    }
}
