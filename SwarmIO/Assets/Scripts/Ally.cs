using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Entity
{
    //Attributes
    public Transform player;


    //Constructor
    public Ally(int health, int movementSpeed) : base(health, movementSpeed)
    {
    }

    private void Update()
    {
        follow();
    }

    //Methods
    public void follow()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * this.movementSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }










}
