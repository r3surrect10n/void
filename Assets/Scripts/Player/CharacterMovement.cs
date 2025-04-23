using UnityEngine;

[RequireComponent (typeof(CharacterInput))]
[RequireComponent (typeof(GroundChecker))]
[RequireComponent (typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _moveSpeed;
    [SerializeField, Range(0, 100)] private float _jumpPower;

    private CharacterInput _chInput;
    private GroundChecker _grChecker;
    private Rigidbody _rb;

    private void Awake()
    {
        _chInput = GetComponent<CharacterInput>();
        _grChecker = GetComponent<GroundChecker>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();        
    }

    private void Move()
    {
        if (_chInput.Move != 0)
        {
            _rb.linearVelocity = new Vector2(_moveSpeed * _chInput.Move, _rb.linearVelocity.y);
        }        
    }

    private void Jump()
    {
        if (_grChecker.IsGrounded && _chInput.Jump)
            _rb.AddForce(0f, _jumpPower, 0f, ForceMode.VelocityChange);
    }
}
