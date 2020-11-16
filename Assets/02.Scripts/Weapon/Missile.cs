using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IWeapon
{
    private Transform battleship;
    private GameObject obj;
    private Transform tr;
    private Rigidbody rb;

    Vector3 perp;

    public Missile(GameObject _obj, Transform _tr)
    {
        obj = _obj;
        tr = _tr;
    }

    public void Shoot()
    {
        Debug.Log("미사일 발사");
        battleship = BattleShip._instance.GetTransform();

        perp = BattleShip._instance.GetPerp();

        GameObject _obj = Instantiate(obj, battleship.position, obj.transform.rotation);

        _obj.transform.LookAt(perp);

        _obj.transform.Rotate(90, 0, 0);

        _obj.GetComponent<Rigidbody>().AddForce(perp * 500.0f);
    }
}