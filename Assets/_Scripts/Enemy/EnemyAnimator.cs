using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    public static readonly int Jumped = Animator.StringToHash(nameof(Jumped));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetJumpedTrigger()
    {
        _animator.SetTrigger(Jumped);
    }
}
