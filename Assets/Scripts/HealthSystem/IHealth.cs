using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    int Life { get; set; }
    void getDamage(int value);
    void Awake();
}
