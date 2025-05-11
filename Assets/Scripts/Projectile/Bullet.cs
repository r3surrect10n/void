using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] private GameObject _bulletHit;
    [SerializeField] private GameObject _bullet;    

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.linearVelocity = Vector3.zero;
        SetParticles();
        Destroy(gameObject, 1f);
    }

    public void BulletInitialize(float firePower, float direction)
    {
        _rb.linearVelocity = new Vector2(firePower * Mathf.Sign(direction), _rb.linearVelocity.y);
    }

    private void SetParticles()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        _bullet.SetActive(false);
        _bulletHit.SetActive(true);
    }
}
