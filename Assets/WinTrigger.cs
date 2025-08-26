using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private WLScreens _wlScreens;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInput>())
            _wlScreens.LevelComplete();
    }
}
