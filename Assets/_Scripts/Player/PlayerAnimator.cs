using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    public static readonly int IsFalling = Animator.StringToHash(nameof(IsFalling));
    public static readonly int Jumped = Animator.StringToHash(nameof(Jumped));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetRunningBool(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }

    public void SetFallingBool(bool isFalling)
    {
        _animator.SetBool(IsFalling, isFalling);
    }

    public void SetJumpedTrigger()
    {
        _animator.SetTrigger(Jumped);
    }
}
