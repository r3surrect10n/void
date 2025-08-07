using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _hpUI;
    [SerializeField] private Image _ammoUI;

    [SerializeField] private Text _pointsText;

    private PlayerCollect _playerCollect;

    private void OnEnable()
    {
        _playerCollect = GetComponent<PlayerCollect>();

        _playerCollect.AddScores += SetScoresUI;

        Health.PlayerSetUI += SetHPUI;
        Shooter.SetAmmoUI += SetAmmoUI;

    }

    private void OnDisable()
    {
        _playerCollect.AddScores -= SetScoresUI;

        Health.PlayerSetUI -= SetHPUI;
        Shooter.SetAmmoUI -= SetAmmoUI;
    }


    private void SetHPUI(float maxHP, float currentHP)
    {        
        if (currentHP > 0)
        {
            _hpUI.fillAmount = currentHP / maxHP;
        }
        else
        {
            _hpUI.fillAmount = currentHP;
        }
    }

    private void SetAmmoUI(float currentAmmo, float maxAmmo)
    { 
        if (currentAmmo > 0)
        {
            _ammoUI.fillAmount = currentAmmo / maxAmmo;
        }
        else
        {
            _ammoUI.fillAmount = currentAmmo;
        }
    }

    private void SetScoresUI(int scores)
    {
        _pointsText.text = $"{scores:D4}";
    }
}
