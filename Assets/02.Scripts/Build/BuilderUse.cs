using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderUse : MonoBehaviour
{
    // 게임 시작 시 유저 쉽 생성
    private void Start()
    {
        Engineer engineer = new Engineer();

        // TODO:추후 로그를 남겨 유저쉽 판단 후 생성
        BattleshipBuilder battleshipBuilder = GetComponent<BattleshipBuilder>();
        battleshipBuilder.MakeBattleship();

        // 빌더를 통해 구성해야 할 제품을 입력받아 제품을 구성한다.
        engineer.Construct(battleshipBuilder);

        // 최종 생상된 제품을 반환한다.
        Ship battleship = battleshipBuilder.GetShip();
        Debug.Log(battleship.GetPartsList());
    }
}