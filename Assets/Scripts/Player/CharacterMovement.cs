using UnityEngine;

[RequireComponent (typeof(CharacterInput))]
[RequireComponent (typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _moveSpeed;
    [SerializeField, Range(0, 100)] private float _jumpPower;

    private CharacterInput _chInput;
    private Rigidbody _rb;

    private void Awake()
    {
        _chInput = GetComponent<CharacterInput>();
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
