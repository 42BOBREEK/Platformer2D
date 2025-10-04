using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Destroy(gameObject);
        }
    }
}
