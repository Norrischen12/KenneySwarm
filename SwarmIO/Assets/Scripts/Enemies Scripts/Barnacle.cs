using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barnacle : Enemies
{

    public int barnacleHealth;
    public int barnacleDamage;
    public int barnacleMovementSpeed;
    [SerializeField]
    public GameObject HPPivot;

    public Barnacle(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(barnacleDamage);
        this.setMovementSpeed(barnacleMovementSpeed);
        this.setHealth(barnacleHealth);
        this.setOriginalHP(barnacleHealth);
        this.setHPPivot(HPPivot);
    }
    private void Update()
    {
        float scaleX = this.getHPScaleX();
        HPPivot.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
