using UnityEngine;

public class ApplyPhysicsMat : MonoBehaviour
{
    [Header("0 - Player default material\n1 - Player idle material")]
    [SerializeField] private PhysicsMaterial[] _phMats;

    [Header("Seconds of jump material")]
    [SerializeField] private float _secondsOfJumpMat;
        
    private PlayerMovement _plMovement;
    private GroundChecker _grChecker;
    private Collider _plCol;   

    private void Awake()
    {
        _plMovement = GetComponent<PlayerMovement>();
        _grChecker = GetComponent<GroundChecker>();
        _plCol = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (_grChecker.IsGrounded && _plMovement.PlayerSpeed.x == 0)
            _plCol.material = _phMats[1];
        else
            _plCol.material = _phMats[0];
    }
}
