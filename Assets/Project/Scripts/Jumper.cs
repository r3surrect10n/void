using System;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public static event Action OnJump;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float _impulseForce;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _animator.SetBool("OnPlatform", true);
            _animator.SetTrigger("Jumper");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            _animator.SetBool("OnPlatform", false);
    }

    public void ForceJump()
    {
        _audioSource.PlayOneShot(_jumpClip);
        _playerRb.AddForce(Vector3.up * _impulseForce, ForceMode.Impulse);
        OnJump?.Invoke();        
    }
}
