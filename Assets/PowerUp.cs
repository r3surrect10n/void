using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private string _powerUpKind;


    public string PowerUpKind => _powerUpKind;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollect>())
        {
            _audioSource.PlayOneShot(_clip);
            Destroy(gameObject);
        }
    }
}
