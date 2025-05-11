using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header ("GO and Script settings")]
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _bulletMuzzle;
    [SerializeField] private Bullet _bullet;

    [Header ("Bullet settings")]
    [SerializeField, Range(-100, 100)] private float _bulletSpeed;

    private PlayerInput _plInput;
    private PlayerMovement _plMovement;

    private ParticleSystem[] _muzzlePS;

    private void OnEnable()
    {
        PlayerInput.Fire += OnShoot;
    }

    private void OnDisable()
    {
        PlayerInput.Fire -= OnShoot;
    }

    private void Awake()
    {
        _plInput = GetComponent<PlayerInput>();
        _plMovement = GetComponent<PlayerMovement>();

        _muzzlePS = _bulletMuzzle.GetComponentsInChildren<ParticleSystem>();
    }

    private void OnShoot()
    {
        if (_plInput.Scope)
        {
            GunMuzzle();            
            
            Bullet newBullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
            newBullet.BulletInitialize(_bulletSpeed, _plMovement.PlayerRotation);            
        }
    }

    private void GunMuzzle()
    {
        foreach (ParticleSystem partSys in _muzzlePS)            
            partSys.Play();
    }
}
