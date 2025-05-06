using UnityEngine;


public class AnimationController : MonoBehaviour
{
    
    private Animator _animC;
    private GroundChecker _grChecker;
    private PlayerInput _plInput;
    private PlayerMovement _plMovement;

    private const float _nearZero = -0.1f; 

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

        Debug.Log("—корость по у" + _plMovement.PlayerSpeed.y);

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

    private void OnEnable()
    {
        PlayerInput.Jump += AnimOnJump;
        //PlayerInput.Fire += AnimOnAttack;
    }

    private void OnDisable()
    {
        PlayerInput.Jump += AnimOnJump;
        //PlayerInput.Fire += AnimOnAttack;
    }

    private void AnimOnJump()
    {
        _animC.SetBool("IsJump", true);
    }

    /*private void AnimOnAttack()
    {
        _animC.SetBool("Attack", true);
    }

    private void OnAttackStart()
    {
        _animC.SetBool("Attacking", true);
    }

    private void OnAttackEnd()
    {
        _animC.SetBool("Attack", false);
        _animC.SetBool("Attacking", false);
    }*/   
}
