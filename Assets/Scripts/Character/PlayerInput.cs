using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> Move;
    public static event Action Jump;
    public static event Action Fire;

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        Move?.Invoke(movement);

        if (Input.GetButtonDown("Jump"))        
            Jump?.Invoke();

        if (Input.GetButtonDown("Fire1"))
            Fire?.Invoke();
    }
}
