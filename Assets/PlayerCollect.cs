using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private Health _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PowerUp>())
        {
            if (other.GetComponent<PowerUp>().PowerUpKind == "Health")
                _playerHealth.OnHealing();
        }
    }
}
