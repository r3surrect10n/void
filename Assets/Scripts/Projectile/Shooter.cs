using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public static event Action NoAmmo;

    [Header ("GO and Script settings")]
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _bulletMuzzle;
    [SerializeField] private Bullet _bullet;

    [Header ("Bullet settings")]
    [SerializeField, Range(-100, 100)] private float _bulletSpeed;

    private PlayerInput _plInput;
    private PlayerMovement _plMovement;

    private ParticleSystem[] _muzzlePS;

    [SerializeField] private int _ammo;
    private int _currentAmmo;    

    private void OnEnable()
    {
        PlayerInput.Fire += OnShoot;
        AnimationController.IsReloaded += OnReloadComplete;
    }

    private void OnDisable()
    {
        PlayerInput.Fire -= OnShoot;
        AnimationController.IsReloaded -= OnReloadComplete;
    }

    private void Awake()
    {
        _plInput = GetComponent<PlayerInput>();
        _plMovement = GetComponent<PlayerMovement>();

        _muzzlePS = _bulletMuzzle.GetComponentsInChildren<ParticleSystem>();

        _currentAmmo = _ammo;
    }

    private void OnShoot()
    {        
         if (_plInput.Scope)
         {
             GunMuzzle();

             Bullet newBullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
             newBullet.BulletInitialize(_bulletSpeed, _plMovement.PlayerRotation);

            _currentAmmo--;

            if (_currentAmmo == 0)
                NoAmmo?.Invoke();
         }
    }

    private void GunMuzzle()
    {
        foreach (ParticleSystem partSys in _muzzlePS)            
            partSys.Play();
    }

    private void OnReloadComplete()
    {
        _currentAmmo = _ammo;
    }
}
