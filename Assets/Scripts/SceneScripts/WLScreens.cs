using UnityEngine;

public class WLScreens : MonoBehaviour
{
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
        _winScreen.SetActive(true);
    }

    public void PlayerDefeated()
    {
        _loseScreen.SetActive(true);
    }
}
