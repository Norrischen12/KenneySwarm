using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void entityConstructor()
    {
        // Use the Assert class to test conditions
        Entity test = new Entity(10, 2);
        Assert.AreEqual(test.getHealth(), 10);
        Assert.AreEqual(test.getMovementSpeed(), 2);
    }
}