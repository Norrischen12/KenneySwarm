using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemies
{
    public int slimeHealth;
    public int slimeDamage;
    public int slimeMovementSpeed;
    [SerializeField]
    public GameObject HPPivot;
    public Slime(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(slimeDamage);
        this.setMovementSpeed(slimeMovementSpeed);
        this.setHealth(slimeHealth);
        this.setOriginalHP(slimeHealth);
        this.setHPPivot(HPPivot);
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = this.getHPScaleX();
        HPPivot.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
