using UnityEngine;

public class MagicAbility : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private LayerMask _targetLayers; 
    [SerializeField] private float _maximumDamagePerFrame;
    [SerializeField] private float _abilityRadius;

    private Collider2D[] _hits = new Collider2D[10];

    private void OnTriggerStay2D(Collider2D coll)
    {
        float closestDistance = float.MaxValue;
        Collider2D closestObject = null;

        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, _abilityRadius, _hits, _targetLayers);

        if (hitCount == 0)
            return;

        for(int i = 0; i < hitCount; i++)
        {
            Collider2D hit = _hits[i];

            if(hit == null)
                continue;

            float distanceToHit = Vector2.Distance(transform.position, hit.transform.position);

            if (distanceToHit < closestDistance)
            {
                closestDistance = distanceToHit;

                closestObject = hit;
            }
        }

        if (closestObject != null && closestObject.TryGetComponent(out Health target))
        {
            StealHealth(target);
        }
    }

    private void StealHealth(Health target)
    {
        float newTargetHealth = Mathf.MoveTowards(target.Current, target.Minimum, _maximumDamagePerFrame);

        float healthToDrain = target.Current - newTargetHealth;

        target.TakeDamage(healthToDrain);

        _health.Heal(healthToDrain);
    }
}
