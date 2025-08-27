using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void OnEnable()
    {
        Application.targetFrameRate = 90;

        if (SceneManager.GetActiveScene().name == "GameScene")
            Resume();
        else
            Time.timeScale = 1f;
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

    public void Quit()
    {
        Application.Quit();
    }

    private void PauseMenu(float timeScale, bool isPause)
    {
        Time.timeScale = timeScale;
        _pauseMenu.SetActive(isPause);
    }
}
