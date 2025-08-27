using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _stepSounds;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _reloadSound;

    [SerializeField] private float _stepCooldown;
    private float _currentStep;

    private Rigidbody _player;
    private GroundChecker _grChecker;

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

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
        _grChecker = GetComponent<GroundChecker>();

        _currentStep = _stepCooldown;
    }

    private void Update()
    {
        if (_player.linearVelocity.x != 0 && _grChecker.IsGrounded)
        {
            _currentStep -= Time.deltaTime;

            if (_currentStep <= 0)
            {
                int randomSound = Random.Range(0, _stepSounds.Length);
                _audioSource.PlayOneShot(_stepSounds[randomSound]);
                _currentStep = _stepCooldown;
            }
        }
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
