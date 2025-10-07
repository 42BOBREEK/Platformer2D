using UnityEngine;
using System;

public class ItemsCollector : MonoBehaviour
{
    public event Action<Medkit> FoundKit;

    public Medkit Kit { get; private set; }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<Coin>() != null)
        {
            Destroy(coll.gameObject);
        }
        else if(coll.gameObject.TryGetComponent<Medkit>(out Medkit kit))
        {
            FoundKit?.Invoke(kit);
        }
    }
}
