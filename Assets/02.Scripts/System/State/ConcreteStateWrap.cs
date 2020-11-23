using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateWrap : State  //★
{
    int currentTime = 0;
    const int oldTime = 3;

    public override void DoAction(ShipState state)
    {
        Debug.Log("Warp !!!");

        // 워프 중
        StartCoroutine(HandleWarp());
    }

    IEnumerator HandleWarp()
    {
        currentTime = 0;
        while(true)
        {
            currentTime++;
            if(currentTime > oldTime)
            {
                currentTime = 0;
                // 워프 중단
                GetComponent<StateMgr>().SetActionType(ShipState.STATE_STANDING);
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
