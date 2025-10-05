using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private bool _isFacingRight = true;

    public void FlipSprite(float horizontalAxis)
    {
        if(_isFacingRight == true && horizontalAxis < 0f 
                || _isFacingRight == false && horizontalAxis > 0f)
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0, -180, 0);
        }
    }
}
