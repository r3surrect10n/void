using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image _hpUI;
    [SerializeField] private Image _ammoUI;

    private void OnEnable()
    {
        Health.PlayerSetUI += SetHPUI;
    }

    private void OnDisable()
    {
        Health.PlayerSetUI -= SetHPUI;
    }


    private void SetHPUI(float maxHP, float currentHP)
    {
        Debug.Log(currentHP);

        if (currentHP > 0)
        {
            _hpUI.fillAmount = currentHP / maxHP;
        }
        else
        {
            _hpUI.fillAmount = currentHP;
        }
    }
}
