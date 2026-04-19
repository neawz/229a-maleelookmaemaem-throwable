using UnityEngine;
using UnityEngine.InputSystem;

public class AddForce : MonoBehaviour
{
    int accel = 10;
    Rigidbody2D rb;
    HingeJoint2D hj;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            Debug.Log("Key Pressed");
            AddForceToObject();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            hj.enabled = false;
        }
    }

    public void AddForceToObject()
    {
        rb.AddForce(new Vector2(CalculateForce() * transform.right.x, 0), ForceMode2D.Force);
    }

    public float CalculateForce()
    {
        Debug.Log("Calculated");
        var f = rb.mass * accel;
        return f;
    }
}
