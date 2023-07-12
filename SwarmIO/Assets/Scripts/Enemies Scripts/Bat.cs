using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemies
{
    public int batHealth;
    public int batDamage;
    public int batMovementSpeed;
    [SerializeField]
    public GameObject HPPivot;


    public Bat(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(batDamage);
        this.setMovementSpeed(batMovementSpeed);
        this.setHealth(batHealth);
        this.setOriginalHP(batHealth);
        this.setHPPivot(HPPivot);
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = this.getHPScaleX();
        HPPivot.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
