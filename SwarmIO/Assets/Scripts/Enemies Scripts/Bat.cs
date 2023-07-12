using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemies
{
    public int batHealth;
    public int batDamage;
    public int batMovementSpeed;


    public Bat(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(batDamage);
        this.setMovementSpeed(batMovementSpeed);
        this.setHealth(batHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
