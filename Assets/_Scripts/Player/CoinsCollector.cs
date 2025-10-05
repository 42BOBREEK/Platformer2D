using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<Coin>() != null)
        {
            Destroy(coll.gameObject);
        }
    }
}
