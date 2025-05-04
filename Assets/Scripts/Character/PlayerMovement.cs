using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float _moveSpeed;
    [SerializeField, Range(0, 20)] private float _jumpPower;

    private GroundChecker _grChecker;
    private Rigidbody _rb;

    public float PlayerSpeed { get; private set; }

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

        PlayerSpeed = _rb.linearVelocity.x;
    }

    private void OnJump()
    {
        if (_grChecker.IsGrounded)
            _rb.AddForce(_rb.linearVelocity.x, _jumpPower, _rb.linearVelocity.z, ForceMode.Impulse);
    }

    private void Rotation(float direction)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, direction >= 0 ? 0 : 180, transform.rotation.z);
    }
}
