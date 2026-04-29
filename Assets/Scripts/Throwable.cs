using UnityEngine;
using UnityEngine.InputSystem;

public class Throwable : MonoBehaviour
{
    int accel = 10;
    Rigidbody2D rb;
    HingeJoint2D hj;

    private float initialDist;
    private static Throwable instance;
    public static Throwable GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();

        initialDist = transform.position.x;
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed && !CameraController.GetInstance().cameraFollow)
        {
            Debug.Log("Key Pressed");
            AddForceToObject();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !CameraController.GetInstance().cameraFollow)
        {
            hj.enabled = false;
            CameraController.GetInstance().cameraFollow = true;
        }
    }

    public float GetDistance()
    {
        return Mathf.Max(0, transform.position.x - initialDist);
    }

    public void AddForceToObject()
    {
        rb.AddForce(new Vector2(CalculateForce() * transform.right.x, 0), ForceMode2D.Force);
    }

    public float CalculateForce()
    {
        return rb.mass * accel;
    }
}
