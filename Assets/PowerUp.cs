using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private string _powerUpKind;

    public string PowerUpKind => _powerUpKind;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollect>())
            Destroy(gameObject);
    }
}
