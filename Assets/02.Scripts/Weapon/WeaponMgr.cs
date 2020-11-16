using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{
    public static WeaponMgr _instance = null;

    CWeapon cWeapon;

    public GameObject missile;
    public GameObject laser;
    public GameObject railgun;
    public GameObject cannon;

    private GameObject battleShip;

    private int weaponTag = 0;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        if (_instance != this)
        {
            Destroy(_instance);
        }
    }

    private void Start()
    {
        cWeapon = new CWeapon();
    }

    public void SetShip(GameObject _battleShip)
    {
        battleShip = _battleShip;

        cWeapon.setWeapon(new Missile(missile, battleShip.transform));
    }

    public void ChangeWeapon()
    {
        if (weaponTag + 1 > 3) weaponTag = 0;
        else weaponTag++;

        switch(weaponTag)
        {
            case 0:
                ChangeMissile();
                break;

            case 1:
                ChangeLaser();
                break;

            case 2:
                ChangeRailgun();
                break;

            case 3:
                ChangeCannon();
                break;
        }
    }

    public void ChangeMissile()
    {
        Debug.Log("무기 교체 : 미사일");
        cWeapon.setWeapon(new Missile(missile, battleShip.transform));
    }

    public void ChangeLaser()
    {
        Debug.Log("무기 교체 : 레이저");
        cWeapon.setWeapon(new Laser(laser, battleShip.transform));
    }

    public void ChangeRailgun()
    {
        Debug.Log("무기 교체 : 레일건");
        cWeapon.setWeapon(new Railgun(railgun, battleShip.transform));
    }

    public void ChangeCannon()
    {
        Debug.Log("무기 교체 : 캐논");
        cWeapon.setWeapon(new Cannon(cannon, battleShip.transform));
    }

    public void Fire()
    {
        cWeapon.Shoot();
    }
}
