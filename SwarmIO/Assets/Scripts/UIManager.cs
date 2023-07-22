using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public RectTransform HPPivot;
    public RectTransform MNPivot;
    public TMP_Text myTextMeshPro;
    public PlayerController player;
    public TMP_Text key_Text;

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
    public void updatName()
    {
        string text = player.GetCurrentWeaponName();
        Debug.Log(text);
        if (text == "BoomerangWeapon")
        {
            text = "Boomerang";
        }
        else if (text == "GunWeapon")
        {
            text = "Pistol";
        }
        else if (text == "SniperWeapon")
        {
            text = "Rifle";
        }
        myTextMeshPro.text = text;
    }
    public void updateKey(int keyNum)
    {
        key_Text.text = keyNum.ToString();
    }
}
