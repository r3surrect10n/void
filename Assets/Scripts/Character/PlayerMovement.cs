using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed settings")]
    [SerializeField, Range(0, 20)] private float _moveSpeed;

    [Header("Jump settings")]
    [SerializeField, Range(0, 20)] private float _jumpPower;
    [SerializeField, Range(0, 2)] private float _jumpCooldown;

    private GroundChecker _grChecker;
    private Rigidbody _rb;

    private bool _isReadyToJump;

    public Vector2 PlayerSpeed { get; private set; }

    private void Update()
    {        
        
    }

    private void OnEnable()
    {
        PlayerInput.Move += OnMove;
        PlayerInput.Jump += OnJump;        
    }

    private void OnDisable()
    {
        PlayerInput.Move -= OnMove;
        PlayerInput.Jump -= OnJump;
    }

    private void Awake()
    {
        _grChecker = GetComponent<GroundChecker>();
        _rb = GetComponent<Rigidbody>();

        _isReadyToJump = true;
    }

    private void OnMove(float direction)
    {
        if (direction != 0)
        {
            _rb.linearVelocity = new Vector2(_moveSpeed * direction, _rb.linearVelocity.y);
            Rotation(direction);
        } 
        else
            _rb.linearVelocity = new Vector2(Vector2.zero.x, _rb.linearVelocity.y);

        PlayerSpeed = _rb.linearVelocity;
    }

    private void OnJump()
    {
        if (_grChecker.IsGrounded && _isReadyToJump)
        {
            _rb.AddForce(_rb.linearVelocity.x, _jumpPower, _rb.linearVelocity.z, ForceMode.Impulse);
            StartCoroutine(JumpCD());
        }
    }

    private void Rotation(float direction)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, direction >= 0 ? 0 : 180, transform.rotation.z);
    }

    private IEnumerator JumpCD()
    {
        _isReadyToJump = false;
        yield return new WaitForSeconds(_jumpCooldown);
        _isReadyToJump = true;
        StopCoroutine(JumpCD());
    }
}
