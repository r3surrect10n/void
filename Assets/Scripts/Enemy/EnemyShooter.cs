using System;
using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{ 
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
        Health.PlayerIsDead += EnemyStopShooting;
    }

    private void OnDisable()
    {
        Health.PlayerIsDead -= EnemyStopShooting;
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

    public void EnemyStopShooting()
    {
        if (!_enHealth.EnemyIsDead)
            StopCoroutine(_shooterCoroutine);
    }

    private void OnShoot()
    {
        GunMuzzle();

        _enAnimC.SetTrigger("Shot");

        EnemyBullet newBullet = Instantiate(_bullet, _shootPoint.transform.position, Quaternion.identity);
        newBullet.BulletInitialize(_bulletSpeed, _enMovement.BeforeStopEnemyDirection);         
    }

    private void GunMuzzle()
    {
        foreach (ParticleSystem partSys in _muzzlePS)            
            partSys.Play();
    }    

    private IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootCD);

            if (!_enHealth.EnemyIsDead)
                OnShoot();
            else
                Destroy(this);
        }        
    }    
}
