using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateVoyage : State  //★
{
    public override void DoAction(ShipState state)
    {
        Debug.Log("Voyage !!!");
    }
}
