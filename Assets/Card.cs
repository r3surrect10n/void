using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private DoorTrigger _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollect>())
        {
            _door.UnlockDoor();
            Destroy(gameObject);
        }
    }
}
