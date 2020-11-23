using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateStand : State  //★
{
    public override void DoAction(ShipState state)
    {
        Debug.Log("Stand !!!");
    }
}
