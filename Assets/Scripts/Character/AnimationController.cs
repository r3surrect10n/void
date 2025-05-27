using System;
using UnityEngine;


public class AnimationController : MonoBehaviour
{
    public static event Action IsReloaded;

    private Animator _animC;
    private GroundChecker _grChecker;
    private PlayerInput _plInput;
    private PlayerMovement _plMovement;    

    private const float _nearZero = -0.1f;

    private void OnEnable()
    {
        PlayerInput.Jump += AnimOnJump;
        PlayerInput.Fire += AnimOnShot;
        Health.PlayerIsDead += AnimOnDead;
        Health.PlayerIsDamaged += AnimOnHit;
        Shooter.NoAmmo += AnimOnReload;
    }

    private void OnDisable()
    {
        PlayerInput.Jump -= AnimOnJump;
        PlayerInput.Fire -= AnimOnShot;
        Health.PlayerIsDead -= AnimOnDead;
        Health.PlayerIsDamaged -= AnimOnHit;
        Shooter.NoAmmo -= AnimOnReload;
    }

    private void Awake()
    {        
        _animC = GetComponent<Animator>();
        _plInput = GetComponentInParent<PlayerInput>();
        _plMovement = GetComponentInParent<PlayerMovement>();
        _grChecker = GetComponentInParent<GroundChecker>();        
    }

    private void Update()
    {
        _animC.SetFloat("Speed", Mathf.Abs(_plMovement.PlayerSpeed.x));
        _animC.SetBool("IsGrounded", _grChecker.IsGrounded);
        _animC.SetBool("IsScope", _plInput.Scope);        

        switch (_plMovement.PlayerSpeed.y)
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

    private void AnimOnJump()
    {
        _animC.SetBool("IsJump", true);
    }

    private void AnimOnShot()
    {
        if (_plInput.Scope)
            _animC.SetTrigger("Shot");
    }
    
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
