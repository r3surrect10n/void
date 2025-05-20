using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action EnemyIsDead;
    public static event Action PlayerIsDead;
    public static event Action<float> PlayerIsDamaged;

    [SerializeField] private float _maxHealth;

    private float _currentHealth;   

    private void Awake()
    {
        _currentHealth = _maxHealth;    
    }

    public void TakingDamage(float damage)
    {
        if (_currentHealth > damage)
        {
            _currentHealth -= damage;

            if (gameObject.GetComponent<PlayerMovement>())
                PlayerIsDamaged?.Invoke(_currentHealth);
        }
        else
        {
            _currentHealth = 0;
            OnDeath();
        }
    }

    public void OnHealing(float healing)
    {
        _currentHealth += healing;
    }

    private void OnDeath()
    {
        if (GetComponent<PlayerMovement>())
        {
            PlayerIsDead?.Invoke();
        }
        else if (GetComponent<Bullet>())
            EnemyIsDead?.Invoke();
        else 
            Destroy(gameObject);
    }
}
