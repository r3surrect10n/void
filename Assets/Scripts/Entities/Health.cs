using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action EnemyIsDead;
    public static event Action PlayerIsDead;
    public static event Action PlayerIsDamaged;
    public static event Action<float, float> PlayerSetUI;

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
                PlayerIsDamaged?.Invoke();
        }
        else
        {
            _currentHealth = 0;
            OnDeath();
        }

        if (gameObject.GetComponent<PlayerMovement>())    
            PlayerSetUI?.Invoke(_maxHealth, _currentHealth);
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
