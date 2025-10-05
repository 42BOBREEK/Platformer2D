using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.2f, _groundLayer);
    }
}
