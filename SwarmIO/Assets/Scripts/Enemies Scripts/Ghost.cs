using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemies
{
    public int ghostHealth;
    public int ghostDamage;
    public int ghostMovementSpeed;
    [SerializeField]
    public GameObject HPPivot;

    public Ghost(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(ghostDamage);
        this.setMovementSpeed(ghostMovementSpeed);
        this.setHealth(ghostHealth);
        this.setOriginalHP(ghostHealth);
        this.setHPPivot(HPPivot);
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX = this.getHPScaleX();
        HPPivot.transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
