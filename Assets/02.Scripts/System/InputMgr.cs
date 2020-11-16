using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InputMgr : MonoBehaviour
{
    private static InputMgr _instance = null;

    private WeaponMgr weaponMgr = null;

    private bool bFlag = false;

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
        weaponMgr = GetComponent<WeaponMgr>();
    }

    private void Update()
    {
        // 마우스 휠 이동시 확대, 축소
        CameraMgr.instance.Zoom();

        // 마우스 좌측 입력시 카메라 회전
        if(Input.GetMouseButton(0))
        {
            CameraMgr.instance.Rotate();
        }

        // Tab 입력시 무기 교체
        if(bFlag && Input.GetKeyUp(KeyCode.Tab))
        {
            WeaponMgr._instance.ChangeWeapon();
        }

        //// 마우스 오른쪽 버튼 입력시 탄약 발사
        //if (bFlag && Input.GetMouseButtonUp(1))
        //{
        //    WeaponMgr._instance.Fire();
        //}

        // Q 입력시 함선 팩션 변경
        if(bFlag && Input.GetKeyUp(KeyCode.Q))
        {
            FactoryMethodUse._instance.ChangFactory();
        }

        // Space 입력시 적대 함선 소환
        if(bFlag && Input.GetKeyUp(KeyCode.Space))
        {
            FactoryMethodUse._instance.makeUnit();
        }
    }

    
    //////////////////////////////////////////////////////////////////
    //
    // UI Function
    //
    public void Undocking()
    {
        bFlag ^= true;

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Docking()
    {
        bFlag ^= true;

        
    }

    public void Fire()
    {
        WeaponMgr._instance.Fire();
    }
}
