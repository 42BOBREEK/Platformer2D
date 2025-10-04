using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private string _isRunningBool;
    [SerializeField] private string _isFallingBool;

    private Animator _animator;

    private void Awake()
    {
        _animator =  GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_isRunningBool, (_player.IsRunning && !_player.IsFalling));
        _animator.SetBool(_isFallingBool, _player.IsFalling);
    }

    private void OnEnable()
    {
        _player.Jumped += SetJumpedTrigger;
    }

    private void OnDisable()
    {
        _player.Jumped -= SetJumpedTrigger;
    }

    private void SetJumpedTrigger()
    {
        _animator.SetTrigger("Jumped");
    }
}
