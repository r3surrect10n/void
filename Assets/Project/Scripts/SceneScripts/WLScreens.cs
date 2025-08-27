using UnityEngine;

public class WLScreens : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _loseClip;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private void OnEnable()
    {
        AnimationController.IsDead += PlayerDefeated;
    }

    private void OnDisable()
    {
       AnimationController.IsDead -= PlayerDefeated;
    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;
        _audioSource.PlayOneShot(_winClip);
        _winScreen.SetActive(true);
    }

    public void PlayerDefeated()
    {
        _audioSource.PlayOneShot(_loseClip);
        _loseScreen.SetActive(true);
    }
}
