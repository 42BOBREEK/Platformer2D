using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private int _attackDamage;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(((1 << coll.gameObject.layer) & _targetLayers) == 0)
            return;

        if(coll.gameObject.TryGetComponent<Health>(out Health target))
        {
            target.TakeDamage(_attackDamage);
        }
    }
}
