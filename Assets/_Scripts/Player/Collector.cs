using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<Coin>() != null)
        {
            Destroy(coll.gameObject);
        }
        else if(coll.gameObject.TryGetComponent<Medkit>(out Medkit kit))
        {
            GetComponent<PlayerHealth>().Heal(kit.HealthToHeal);
        }
    }
}
