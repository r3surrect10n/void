using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void Awake()
    {
        _damage = Random.Range(10, 25);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
            collision.gameObject.GetComponent<Health>().TakingDamage(_damage);
    }
}
