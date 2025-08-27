using UnityEngine;

public class EnemySpotting : MonoBehaviour
{
    [SerializeField] private Transform _enemyHead;
    [SerializeField] private float _enemySpotDistance;
    [SerializeField] private LayerMask _playerLayer;

    private EnemyMovement _enemyMovement;
    private EnemyShooter _enemyShooter;
    
    private RaycastHit _enemyLookHit;

    private bool _playerSpotted = false;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyShooter = GetComponent<EnemyShooter>();
    }

    private void Update()
    {        

        Debug.DrawRay(_enemyHead.position, _enemyHead.forward * _enemySpotDistance, Color.red);

        if (!_playerSpotted)
        {
            if (Physics.Raycast(_enemyHead.position, _enemyHead.forward, out _enemyLookHit, _enemySpotDistance, _playerLayer))
            {
                if (_enemyShooter != null || _enemyMovement != null)
                {
                    _enemyMovement.OnPlayerSpotting();
                    _enemyShooter.EnemyStartShooting();
                    _playerSpotted = true;
                }
            }
        }
        else if (_playerSpotted && !Physics.Raycast(_enemyHead.position, _enemyHead.forward, out _enemyLookHit, _enemySpotDistance, _playerLayer))
        {
            _playerSpotted = false;
            _enemyMovement.OnPlayerMissing();
            _enemyShooter.EnemyStopShooting();
        }
    }
}
