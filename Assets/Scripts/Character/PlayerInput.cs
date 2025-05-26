using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static event Action<float> Move;
    public static event Action Jump;
    public static event Action Fire;

    private bool _canShoot;

    public bool Scope {  get; private set; }

    private void OnEnable()
    {
        Shooter.NoAmmo += CantShoot;
        AnimationController.IsReloaded += CanShoot;
    }

    private void OnDisable()
    {
        Shooter.NoAmmo -= CantShoot;
        AnimationController.IsReloaded -= CanShoot;
    }

    private void Awake()
    {
        _canShoot = true;
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        Move?.Invoke(movement);

        if (Input.GetButtonDown("Jump"))        
            Jump?.Invoke();

        if (_canShoot)
        {
            if (Input.GetButtonDown("Fire1"))
                Fire?.Invoke();
        }

        RMBHeld();
    }

    private void RMBHeld()
    {
        if (Input.GetButton("Fire2"))                   
            Scope = true;
        else
            Scope = false;
    }

    private void CanShoot()
    {
        _canShoot = true;
    }

    private void CantShoot()
    {
        _canShoot = false;
    }
}
