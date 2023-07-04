using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private bool stopCameraMovement;

    private void Start()
    {
        stopCameraMovement = false;
    }
    private void LateUpdate()
    {
        if (player != null && !stopCameraMovement)
        {
            this.transform.position = player.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            stopCameraMovement = true;
            Debug.Log("11");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            stopCameraMovement = true;
            Debug.Log("22");
        }
    }
}
