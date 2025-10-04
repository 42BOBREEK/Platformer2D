using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private Animator _animator;
    
    private void Awake()
    {
        _enemy = GetComponent<EnemyMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemy.Jumped += SetJumpedTrigger; 
    }

    private void OnDisable()
    {
        _enemy.Jumped -= SetJumpedTrigger; 
    }

    private void SetJumpedTrigger()
    {
        _animator.SetTrigger("Jumped");
    }
}
