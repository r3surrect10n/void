using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Material _hpMat;

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
        Color32 hpColor = new Color32(0xFF, 0x00, 0x00, 0xFF); // Красный цвет
        //_hpMat.material.GetColor(0);
        Debug.Log(_hpMat);
    }
}
