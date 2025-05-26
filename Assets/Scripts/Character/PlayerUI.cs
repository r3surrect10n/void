using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _hpUI;
    [SerializeField] private Image _ammoUI;

    private void OnEnable()
    {
        Health.PlayerIsDamaged += SetHPUI;
    }

    private void OnDisable()
    {
        Health.PlayerIsDamaged -= SetHPUI;
    }
    

    private void SetHPUI(float hp)
    {
        _hpUI.fillAmount = 1 - (1 / hp);
    }
}
