using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.05f;
    private Vector3 velocity = Vector3.zero;

    public bool cameraFollow = false;

    private static CameraController instance;
    public static CameraController GetInstance()
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
    }

    void Update()
    {
        if (cameraFollow)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
