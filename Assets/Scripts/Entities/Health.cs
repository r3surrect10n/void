using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action EnemyIsDead;
    public static event Action PlayerIsDead;

    [SerializeField] private float _maxHealth;

    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;    
    }

    public void TakingDamage(float damage)
    {
        if (_currentHealth > damage)
            _currentHealth -= damage;
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
            PlayerIsDead?.Invoke();        
        else if (GetComponent<Bullet>())
            EnemyIsDead?.Invoke();
        else 
            Destroy(gameObject);
    }
}
