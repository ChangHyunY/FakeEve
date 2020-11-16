using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaldariFactory : RaceFactory
{
    public GameObject caracal;
    public int poolSize = 10;       // Object Pool Size
    GameObject[] enemyPool;
    
    public override UnitBuilding makeUnitBuilding()
    {
        enemyPool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; ++i)
        {
            enemyPool[i] = Instantiate(caracal) as GameObject;
            enemyPool[i].name = "Caracal_" + i;
            enemyPool[i].SetActive(false);
        }

        // 생성방식 오브젝트 풀 방식으로 변경
        //Instantiate(caracal, caracal.transform.localPosition, caracal.transform.localRotation);

        StartCoroutine(SpawnManager(poolSize, enemyPool));

        return new Caracal();
    }
}
