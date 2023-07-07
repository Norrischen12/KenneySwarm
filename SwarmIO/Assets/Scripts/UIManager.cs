using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform HPPivot;
    public void setHP(float hpPoint)
    {
        Vector3 newHP = HPPivot.localScale;
        newHP.x = hpPoint;
        HPPivot.localScale = newHP;
    }
}
