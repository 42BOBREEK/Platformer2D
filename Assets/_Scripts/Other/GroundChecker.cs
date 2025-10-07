using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, _checkRadius, _groundLayer);
    }
}
