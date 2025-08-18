using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool _doorStatus;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && _doorStatus)
            _animator.SetBool("IsOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            _animator.SetBool("IsOpen", false);
    }

    public void UnlockDoor()
    {
        if (!_doorStatus)
            _doorStatus = !_doorStatus;
    }
}
