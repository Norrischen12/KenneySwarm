using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public int durability;


    //Constructor
    public Weapons(int durability)
    {
        this.durability = durability;
    }

    //Methods
    public void usedDurability(int used)
    {
        this.durability -= used;
    }





    //Getters Setters
    public int getDurability()
    {
        return this.durability;
    }

    public void setDurability(int durability)
    {
        this.durability = durability;
    }
}
