using System;
using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public static event Action NoAmmo;
    public static event Action<float, float> SetAmmoUI;

    [Header("GO and Script settings")]
    [SerializeField] private Animator _enAnimC;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private GameObject _bulletMuzzle;
    [SerializeField] private EnemyBullet _bullet;

    [Header ("Bullet settings")]
    [SerializeField, Range(-100, 100)] private float _bulletSpeed;
    [SerializeField] private float _shootCD;
    [SerializeField] private int _ammo;
        
    private EnemyMovement _enMovement;    
    private Health _enHealth;

    private ParticleSystem[] _muzzlePS;

    private int _currentAmmo;
    private Coroutine _shooterCoroutine;

    private void OnEnable()
    {
        Health.PlayerIsDead += PlayerIsDead;
    }

    private void OnDisable()
    {
        Health.PlayerIsDead -= PlayerIsDead;
    }

    private void Awake()
    {        
        _enMovement = GetComponent<EnemyMovement>();
        _enHealth = GetComponent<Health>();

        _muzzlePS = _bulletMuzzle.GetComponentsInChildren<ParticleSystem>();

        _currentAmmo = _ammo;
    }

    public void EnemyStartShooting()
    {
        _shooterCoroutine = StartCoroutine(EnemyShooting());
    }

    private void OnShoot()
    {      
         
        GunMuzzle();

        _enAnimC.SetTrigger("Shot");

        EnemyBullet newBullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
        newBullet.BulletInitialize(_bulletSpeed, _enMovement.BeforeStopEnemyDirection);

        _currentAmmo--;        

        if (_currentAmmo == 0)
        { }
         
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

    private IEnumerator EnemyShooting()
    {
        while (!_enHealth.EnemyIsDead)
        {
            yield return new WaitForSeconds(_shootCD);
            OnShoot();
        }

        StopCoroutine(_shooterCoroutine);
    }

    private void PlayerIsDead()
    {
        Debug.Log("KILL");
        StopCoroutine(_shooterCoroutine);
    }
}
