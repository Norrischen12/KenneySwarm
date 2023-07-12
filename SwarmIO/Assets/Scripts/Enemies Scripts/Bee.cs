using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemies
{
    public int beeHealth;
    public int beeDamage;
    public int beeMovementSpeed;
    [SerializeField]
    public GameObject HPPivot;
    public Bee(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(beeDamage);
        this.setMovementSpeed(beeMovementSpeed);
        this.setHealth(beeHealth);
        this.setOriginalHP(beeHealth);
        this.setHPPivot(HPPivot);
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = this.getHPScaleX();
        HPPivot.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
