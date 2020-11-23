using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipState
{
    STATE_STANDING,
    STATE_VOYAGE,
    STATE_WARP
}

public class StateMgr : MonoBehaviour   //★
{
    private ShipState shipState;

    // Concrete 클래스들의 접근점(추상 클래스)
    private State state;

    // 상태 클래스 교환
    public void SetActionType(ShipState _shipState)
    {
        // 현재 상태 저장
        this.shipState = _shipState;

        Component c = gameObject.GetComponent<State>() as Component;

        if(c != null)
        {
            Destroy(c);
        }

        switch(_shipState)
        {
            case ShipState.STATE_STANDING:
                state = gameObject.AddComponent<ConcreteStateStand>();
                state.DoAction(_shipState);
                break;

            case ShipState.STATE_VOYAGE:
                state = gameObject.AddComponent<ConcreteStateVoyage>();
                state.DoAction(_shipState);
                break;

            case ShipState.STATE_WARP:
                state = gameObject.AddComponent<ConcreteStateWrap>();
                state.DoAction(_shipState);
                break;

            default:
                break;
        }
    }

    private void Start()
    {
        SetActionType(ShipState.STATE_STANDING);
    }

    private void Update()
    {
        switch(shipState)
        {
            case ShipState.STATE_STANDING:
                if(Input.GetKeyUp(KeyCode.X))
                {
                    SetActionType(ShipState.STATE_VOYAGE);
                }
                if(Input.GetKeyUp(KeyCode.S))
                {
                    SetActionType(ShipState.STATE_WARP);
                }
                break;

            case ShipState.STATE_VOYAGE:
                if(Input.GetKeyUp(KeyCode.W))
                {
                    SetActionType(ShipState.STATE_STANDING);
                }
                if(Input.GetKeyUp(KeyCode.S))
                {
                    SetActionType(ShipState.STATE_WARP);
                }
                break;

            case ShipState.STATE_WARP:
                // 워프 종료 후 STATE_STANDING
                break;

            default:
                break;
        }
    }
}
