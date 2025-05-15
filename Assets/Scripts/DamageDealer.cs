using System.Collections;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _damageTick;

    private Coroutine _damagingCoroutine;

    private void Awake()
    {
        if (GetComponent<Bullet>() != null) 
            _damage = Random.Range(15, 25);            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>())
            collision.gameObject.GetComponent<Health>().TakingDamage(_damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _damagingCoroutine = StartCoroutine(Damaging(other));
            Debug.Log("Enter");
        }
                //other.GetComponent<Health>().TakingDamage(_damage);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<PlayerMovement>())
        {
            Debug.Log("exit");
            StopCoroutine(_damagingCoroutine);
        }
    }

    private IEnumerator Damaging(Collider player)
    {
        while (true)
        {
            player.GetComponent<Health>().TakingDamage(_damage);
            yield return new WaitForSeconds(_damageTick);            
        }        
    }
}
