using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;

    [Header("Speed and direction settings")]
    [SerializeField, Range(0, 20)] private float _moveSpeed;
    [SerializeField] private float _startDirection;

    private Rigidbody _rb;        

    public Vector2 EnemySpeed { get; private set; }
    public float EnemyDirection {  get; private set; }    

    private void OnEnable()
    {               
        Health.EnemyIsDead += OnDead;
    }

    private void OnDisable()
    {               
        Health.EnemyIsDead -= OnDead;
    }

    private void Awake()
    {        
        _rb = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        EnemyDirection = _startDirection;
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        if (EnemyDirection != 0)
        {
            _rb.linearVelocity = new Vector2(_moveSpeed * EnemyDirection, _rb.linearVelocity.y);
            Rotation();
        } 
        else
            _rb.linearVelocity = new Vector2(Vector2.zero.x, _rb.linearVelocity.y);

        EnemySpeed = _rb.linearVelocity;
    }   

    private void Rotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, EnemyDirection >= 0 ? 0 : 180, transform.rotation.z);        
    }    

    private void OnDead()
    {
        _rb.linearVelocity = new Vector2(Vector2.zero.x, _rb.linearVelocity.y);
        _rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }

    public void OnRotation()
    {
        EnemyDirection = -EnemyDirection;
    }
}
