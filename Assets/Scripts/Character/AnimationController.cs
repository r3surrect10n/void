using UnityEngine;


public class AnimationController : MonoBehaviour
{
    private Animator _animC;
    private GroundChecker _grChecker;
    private PlayerMovement _plMovement;

    private void Awake()
    {
        _animC = GetComponentInChildren<Animator>();
        _plMovement = GetComponent<PlayerMovement>();
        _grChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        _animC.SetFloat("Speed", Mathf.Abs(_plMovement.PlayerSpeed));
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void AnimationMove(float direction)
    {

    }
}
