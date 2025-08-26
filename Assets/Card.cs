using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private DoorTrigger _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollect>())
        {
            _audioSource.PlayOneShot(_clip);
            _door.UnlockDoor();
            Destroy(gameObject);
        }
    }
}
