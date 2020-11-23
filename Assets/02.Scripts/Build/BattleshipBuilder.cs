using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipBuilder : MonoBehaviour, IShipBuilder
{
    public GameObject parentOfShip;
    public GameObject body;
    public GameObject lWing;
    public GameObject rWing;

    private Ship _ship;

    public Ship GetShip()
    {
        return _ship;
    }

    public void MakeBattleship()
    {
        GameObject obj = Instantiate(parentOfShip) as GameObject;
        _ship = obj.GetComponent<Ship>();
        _ship.SetShipType(ShipType.Battleship);

        // 오브젝트 태그 플레이어로 변경
        obj.tag = "Player";

        // 카메라 타겟 obj로 변경
        CameraMgr.instance.SetTarget(obj.transform);

        // 카메라 기준축 변경
        CameraMgr.instance.LockTarget(obj.transform);

        // 배틀쉽의 무기 설정
        GetComponent<WeaponMgr>().SetShip(obj);

        obj.AddComponent<BattleShip>();

        // 배틀쉽 FSM 설정★
        obj.AddComponent<StateMgr>();

        // 플레이어 쉽 싱글톤
        DontDestroyOnLoad(obj);
    }

    public void BuildBody()
    {
        _ship.AddPart(body, Vector3.zero);
    }

    public void BuildWing()
    {
        _ship.AddPart(lWing, lWing.transform.localPosition);
        _ship.AddPart(rWing, rWing.transform.localPosition);
    }
}
