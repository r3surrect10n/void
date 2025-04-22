using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public float Move { get; private set; }
    public bool Jump {  get; private set; }
    public bool Shoot { get; private set; }

    private void Update()
    {
        Move = Input.GetAxis("Horizontal");
        Jump = Input.GetButtonDown("Jump");
        Shoot = Input.GetButtonDown("Fire1");
    }
}
