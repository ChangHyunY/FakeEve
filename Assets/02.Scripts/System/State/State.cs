using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// State 추상 클래스
public abstract class State : MonoBehaviour
{
    public abstract void DoAction(ShipState state);
}
