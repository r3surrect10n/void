using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public event Action<int> AddScores;   

    private Health _playerHealth;
    private PlayerUI _playerUI;

    private int _killScores = 0;

    private void OnEnable()
    {
        EnemyMovement.KillScores += CollectEnemyScores;
    }

    private void OnDisable()
    {
        EnemyMovement.KillScores -= CollectEnemyScores;
    }

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _playerUI = GetComponent<PlayerUI>();
    }

    private void Start()
    {
        _killScores = 0;
        AddScores?.Invoke(_killScores);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PowerUp>())
        {
            if (other.GetComponent<PowerUp>().PowerUpKind == "Health")
                _playerHealth.OnHealing();
        }
    }

    private void CollectEnemyScores()
    {
        _killScores += UnityEngine.Random.Range(250, 350);
        AddScores?.Invoke(_killScores);
    }
}
