using System;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _stepSounds;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _reloadSound;

    [SerializeField] private float _stepCooldown;

    private void OnEnable()
    {
        PlayerInput.Fire += PlayShootSound;
        Shooter.NoAmmo += PlayReloadSound;
    }

    private void OnDisable()
    {
        PlayerInput.Fire -= PlayShootSound;
        Shooter.NoAmmo -= PlayReloadSound;
    }

    private void PlayShootSound()
    {
        _audioSource.PlayOneShot(_shootSound);
    }
    private void PlayReloadSound()
    {
        _audioSource.PlayOneShot(_reloadSound);
    }
}
