using System;
using UnityEngine;


public class EnemyAnimationController : MonoBehaviour
{
    public static event Action IsReloaded;

    private Animator _animC;    
    private EnemyMovement _enMovement;    

    private const float _nearZero = -0.1f;

    private void OnEnable()
    {
        
        //PlayerInput.Fire += AnimOnShot;
        Health.EnemyIsDead += AnimOnDead;
        //Health.PlayerIsDamaged += AnimOnHit;
        //Shooter.NoAmmo += AnimOnReload;
    }

    private void OnDisable()
    {
        
        //PlayerInput.Fire -= AnimOnShot;
        Health.EnemyIsDead -= AnimOnDead;
        //Health.PlayerIsDamaged -= AnimOnHit;
        //Shooter.NoAmmo -= AnimOnReload;
    }

    private void Awake()
    {        
        _animC = GetComponent<Animator>();
        _enMovement = GetComponentInParent<EnemyMovement>();            
    }

    private void Update()
    {
        _animC.SetFloat("Speed", Mathf.Abs(_enMovement.EnemySpeed.x));        
        //_animC.SetBool("IsScope", _plInput.Scope);        

        switch (_enMovement.EnemySpeed.y)
        {
            case < _nearZero:
                _animC.SetBool("FreeFall", true);
                _animC.SetBool("IsJump", false);
                break;
            case > _nearZero:
                _animC.SetBool("FreeFall", false);
                break;
            default: break;
        }            
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
