using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public int durability { get; set; }


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


}
