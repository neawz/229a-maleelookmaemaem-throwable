using UnityEngine;

public class CheckGround : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            GameManager.GetInstance().GameOver();
            Debug.Log("Ground Hit");
        }
    }
}
