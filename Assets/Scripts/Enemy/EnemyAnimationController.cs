using System;
using UnityEngine;


public class EnemyAnimationController : MonoBehaviour
{
    public static event Action IsReloaded;

    private Animator _animC;    
    private EnemyMovement _enMovement; 
    private Health _health;    

    private void OnEnable()
    {
        
        //PlayerInput.Fire += AnimOnShot;        
        //Health.PlayerIsDamaged += AnimOnHit;
        //Shooter.NoAmmo += AnimOnReload;
    }

    private void OnDisable()
    {
        
        //PlayerInput.Fire -= AnimOnShot;
        
        //Health.PlayerIsDamaged -= AnimOnHit;
        //Shooter.NoAmmo -= AnimOnReload;
    }

    private void Awake()
    {        
        _animC = GetComponent<Animator>();
        _enMovement = GetComponentInParent<EnemyMovement>(); 
        _health = GetComponentInParent<Health>();
    }

    private void Start()
    {
        _animC.SetBool("IsScope", true);
    }

    private void Update()
    {
        _animC.SetFloat("Speed", Mathf.Abs(_enMovement.EnemySpeed.x));        
        //_animC.SetBool("IsScope", _plInput.Scope);        
        
        if (_health.EnemyIsDead)
            AnimOnDead();

    }

    //private void AnimOnShot()
    //{
    //    if (_plInput.Scope)
    //        _animC.SetTrigger("Shot");
    //}
    
    private void AnimOnDead()
    {        
        _animC.SetLayerWeight(2, 0);
        _animC.SetBool("IsDead", true);        
    }

    private void AnimOnHit()
    {
        _animC.SetTrigger("IsHitted");
    }

    private void AnimOnReload()
    {
        _animC.SetTrigger("IsReloading");
    }

    private void ReloadComlete()
    {
        IsReloaded?.Invoke();
    }
}
