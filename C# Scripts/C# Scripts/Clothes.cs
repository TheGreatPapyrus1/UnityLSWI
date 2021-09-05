using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEditor;

public class Clothes : MonoBehaviour
{

    [SerializeField] string designation;
    [SerializeField] Sprite icon;
    [SerializeField] int price = 5;

    [SerializeField] Sprite leg;
    [SerializeField] Sprite body;
    [SerializeField] Sprite crotch;
    [SerializeField] Sprite arm;

    public string GetDesignation()
    {
        return designation;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public int GetPrice()
    {
        return price;
    }


    public string GetClothesType()
    {
        return type;
    }

    public Sprite GetLeg()
    {
        return leg;
    }

    public Sprite GetArm()
    {
        return arm;
    }

    public Sprite GetBody()
    {
        return body;
    }

    public Sprite GetCrotch()
    {
        return crotch;
    }


}
