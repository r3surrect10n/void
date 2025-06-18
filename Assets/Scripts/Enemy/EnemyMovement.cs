using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyMovement : MonoBehaviour
{  
    [Header("Speed and direction settings")]
    [SerializeField, Range(0, 20)] private float _moveSpeed;
    [SerializeField] private float _startDirection;

    [SerializeField] private float _enemyCheckingTime;

    private Health _enemyHealth;
    private Rigidbody _rb;        

    public Vector2 EnemySpeed { get; private set; }
    public float EnemyDirection {  get; private set; }

    private void Awake()
    {        
        _rb = GetComponent<Rigidbody>(); 
        _enemyHealth = GetComponent<Health>();
    }

    private void Start()
    {
        EnemyDirection = _startDirection;
    }

    private void Update()
    {
        if (_enemyHealth.EnemyIsDead)
            OnDead();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    //public void OnRotation()
    //{
    //    EnemyDirection = -EnemyDirection;
    //}

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stopper>())
            StartCoroutine(OnRotation());
    }

    private IEnumerator OnRotation()
    {
        float enemyCurrentDirection = EnemyDirection;
        EnemyDirection = 0;

        yield return new WaitForSeconds(_enemyCheckingTime);

        EnemyDirection = -enemyCurrentDirection;

        StopCoroutine(OnRotation());
    }

}
