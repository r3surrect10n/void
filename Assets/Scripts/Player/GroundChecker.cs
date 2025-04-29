using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkerTransform;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField, Range(0, 1)] private float _checkerRadius;    

    public bool IsGrounded {  get; private set; }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(_checkerTransform.position, _checkerRadius, _groundLayer);        
    }

    private void OnDrawGizmos()
    {
        if (IsGrounded)
            Gizmos.color = Color.yellow;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawSphere(_checkerTransform.position, _checkerRadius);        
    }
}
