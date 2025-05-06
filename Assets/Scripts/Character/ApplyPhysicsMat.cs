using UnityEngine;

public class ApplyPhysicsMat : MonoBehaviour
{
    [Header("0 - Player move material\n1 - Player jump material\n2 - Player idle material")]
    [SerializeField] private PhysicsMaterial[] _phMats;
        
    private PlayerMovement _plMovement;
    private GroundChecker _grChecker;
    private Collider _plCol;
    

    private void Awake()
    {
        _plMovement = GetComponent<PlayerMovement>();
        _grChecker = GetComponent<GroundChecker>();
        _plCol = GetComponent<Collider>();
    }

    private void Update()
    {
        /*if (_grChecker.IsGrounded)
        {
            _plCol.material = _phMats[0];

            if (_plMovement.PlayerSpeed.x == 0)
                _plCol.material = _phMats[2];
        }
        else if (Mathf.Abs(_plMovement.PlayerSpeed.y) > 0)
            _plCol.material = _phMats[1];*/

        if (!_grChecker.IsGrounded)
            _plCol.material = _phMats[1];
        else
        {
            if (_plMovement.PlayerSpeed.x == 0)
                _plCol.material = _phMats[2];
            else
                _plCol.material = _phMats[0];            
        }
    }
}
