using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private int _clickButtonNumber;
    [SerializeField] private KeyCode _castKey;

    public float HorizontalInput { get; private set; }
    public event Action Clicked;
    public event Action CastClicked;
    public event Action JumpClicked;

    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw(Horizontal);

        if (Input.GetMouseButtonDown(_clickButtonNumber))
        {
            Clicked?.Invoke();
        }

        if (Input.GetButtonDown(Jump))
        {
            JumpClicked?.Invoke();
        }

        if(Input.GetKeyDown(_castKey))
        {
            CastClicked?.Invoke();
        }
    }
}
