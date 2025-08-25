using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void OnEnable()
    {
        Resume();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Pause()
    {
        PauseMenu(0f, true);
    }

    public void Resume()
    {
        PauseMenu(1f, false);
    }

    private void PauseMenu(float timeScale, bool isPause)
    {
        Time.timeScale = timeScale;
        _pauseMenu.SetActive(isPause);
    }
}
