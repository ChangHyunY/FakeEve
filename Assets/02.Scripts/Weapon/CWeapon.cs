using UnityEngine;

public class CWeapon
{
    // 접근점
    private IWeapon weapon;

    // 무기 교체
    public void setWeapon (IWeapon weapon)
    {
        this.weapon = weapon;
    }

    // 인터페이스 함수
    public void Shoot()
    {
        weapon.Shoot();
    }
}
