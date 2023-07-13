using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform HPPivot;
    public RectTransform MNPivot;
    public void setHP(float hpPoint)
    {
        Vector3 newHP = HPPivot.localScale;
        newHP.x = hpPoint;
        HPPivot.localScale = newHP;
    }
    public void setMN(float mn)
    {
        Vector3 newMN = MNPivot.localScale;
        newMN.x = mn;
        MNPivot.localScale = newMN;
    }
}
