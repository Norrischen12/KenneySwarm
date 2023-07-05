using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public GameObject[] boundaries = new GameObject[4];

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Start()
    {
        //left
        minX = boundaries[0].transform.position.x;
        //right
        maxX = boundaries[1].transform.position.x;
        //bot
        minY = boundaries[2].transform.position.y;
        //top
        maxY = boundaries[3].transform.position.y;
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired camera position
            Vector3 desiredPosition = player.transform.position;

            // Clamp the camera position within the specified boundaries
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, 1);

            // Set the camera's position
            transform.position = clampedPosition;
        }
    }
}
