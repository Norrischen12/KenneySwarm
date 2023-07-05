using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Entity
{

    public PlayerController(int health, int movementSpeed) : base(health, movementSpeed)
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical) * movementSpeed * Time.deltaTime;
        this.transform.position += movement;
        this.setHealth(3);

    }
}
