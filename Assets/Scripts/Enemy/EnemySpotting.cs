using UnityEngine;

public class EnemySpotting : MonoBehaviour
{
    [SerializeField] private GameObject _enemyHead;
    [SerializeField] private float _enemySpotDistance;
    [SerializeField] private LayerMask _playerLayer;

    private Ray _enemyLook;
    private RaycastHit _enemyLookHit;

    private void Update()
    {
        

        if (Physics.Raycast(_enemyLook, _enemySpotDistance, _playerLayer))
        {

        }
    }
}
