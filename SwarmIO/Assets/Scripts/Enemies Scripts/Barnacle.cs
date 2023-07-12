using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barnacle : Enemies
{

    public int barnacleHealth;
    public int barnacleDamage;
    public int barnacleMovementSpeed;

    public Barnacle(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(barnacleDamage);
        this.setMovementSpeed(barnacleMovementSpeed);
        this.setHealth(barnacleHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
