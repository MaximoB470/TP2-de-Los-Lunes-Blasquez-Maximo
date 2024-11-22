using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : IHealth
{
    public int maxHp;
    public int Life { get; set; }
    //Move to constructor
    public void Awake()
    { 
        Life = maxHp;
    }
    public void getDamage(int value) 
    {
        Life -= value;
    }
}
