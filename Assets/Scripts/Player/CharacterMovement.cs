using UnityEngine;

[RequireComponent (typeof(CharacterInput))]
[RequireComponent (typeof(GroundChecker))]
[RequireComponent (typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _moveSpeed;
    [SerializeField, Range(0, 100)] private float _jumpPower;
    [SerializeField, Range(0, 15)] private float _gravity;

    private CharacterInput _chInput;
    private GroundChecker _grChecker;
    private Rigidbody _rb;

    [SerializeField] private Transform _wallCheckerTop;
    [SerializeField] private Transform _wallCheckerBot;
    [SerializeField] private LayerMask _wallsLayer;
    private bool _isWallFwd;

    private void Awake()
    {
        _chInput = GetComponent<CharacterInput>();
        _grChecker = GetComponent<GroundChecker>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isWallFwd = Physics.CheckCapsule(_wallCheckerTop.position, _wallCheckerBot.position, 0.7f, _wallsLayer);
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
            Rotation(_chInput.Move);
        }        
    }

    private void Rotation(float direction)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x,direction >= 0 ? 0 : 180, transform.rotation.z);        
    }

    private void Jump()
    {
        if (_grChecker.IsGrounded && _chInput.Jump)
            _rb.AddForce(_rb.linearVelocity.x, _jumpPower, _rb.linearVelocity.z, ForceMode.VelocityChange);
        else
            _rb.AddForce(_rb.linearVelocity.x, -_gravity, _rb.linearVelocity.z, ForceMode.Acceleration);
    }

    private void OnDrawGizmos()
    {
        if (_isWallFwd)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawSphere(transform.position, 0.7f);
    }
}
