using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> Move;
    public static event Action Jump;
    public static event Action Fire;

    public bool Scope {  get; private set; }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        Move?.Invoke(movement);

        if (Input.GetButtonDown("Jump"))        
            Jump?.Invoke();

        if (Input.GetButtonDown("Fire1"))
            Fire?.Invoke();

        RMBHeld();
    }

    private void RMBHeld()
    {
        if (Input.GetButton("Fire2"))
        {
            Scope = true;
            Debug.Log(Scope);
        }
        else
            Scope = false;
            
    }
}
