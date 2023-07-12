using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemies
{
    public int slimeHealth;
    public int slimeDamage;
    public int slimeMovementSpeed;
    public Slime(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(slimeDamage);
        this.setMovementSpeed(slimeMovementSpeed);
        this.setHealth(slimeHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
